using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VRC_Screenshot_Archiver
{
    /// <summary>
    /// Class for archiving VRChat screenshots
    /// </summary>
    public class Archiver
    {
        /// <summary>
        /// Regex for filtering VRChat screenshot files
        /// </summary>
        private static readonly Regex _regex = new Regex("^VRChat_[0-9]{3,4}x[0-9]{3,4}_((([0-9]{4})-[0-9]{2})-[0-9]{2})_[0-9]{2}-[0-9]{2}-[0-9]{2}.[0-9]{3}.png$");

        /// <summary>
        /// Archives VRChat screenshots by moving them to another destination and grouping them into folders by date (if specified by grouping settings)
        /// </summary>
        /// <param name="progress">Status information of the method progress</param>
        /// <param name="source">Screenshot folder path</param>
        /// <param name="destination">Destination folder path</param>
        /// <param name="settings">Grouping settings</param>
        public async Task ArchiveAsync(IProgress<ArchiveProgress> progress, string source, string destination, Grouping settings)
        {
            // Progress status to report
            ArchiveProgress report = new ArchiveProgress();
            List<string> subFolders = new List<string>();

            // Reset status
            progress.Report(report);

            // Check whether entered directories exist
            if (!Directory.Exists(source) || !Directory.Exists(destination))
            {
                report.ErrorMessage = "Invalid path(s).";
                progress.Report(report);
                return;
            }

            // Save entered directories to user settings
            Properties.Settings.Default.SourceDirectory = source;
            Properties.Settings.Default.DestinationDirectory = destination;
            Properties.Settings.Default.Save();

            // Add subdirectories of source folder
            subFolders.AddRange(Directory.GetDirectories(source));

            // Get the files from the source directory that are likely to be screenshots
            List<string> files;
            try
            {
                files = Directory.GetFiles(source, "*VRChat_*.png").ToList();

                foreach (string src in subFolders)
                {
                    files.AddRange(Directory.GetFiles(src, "*VRChat_*.png"));
                }
            }
            catch
            {
                report.ErrorMessage = "Invalid source path.";
                progress.Report(report);
                return;
            }

            report.ImagesFound = files.Count;
            progress.Report(report);

            // Check whether the source directory contains files
            if (files.Count == 0)
            {
                return;
            }

            // Loop through each file and move it if it is a VRChat screenshot
            await Task.Run(() => Parallel.ForEach(files, (file) =>
            {
                // Get the filename with extension
                string filename = Path.GetFileName(file);

                var match = _regex.Match(filename);

                // Check whether the file is a VRChat screenshot
                if (!match.Success)
                {
                    return;
                }

                // Prepare the directories for grouping
                string dateFolders = string.Empty;
                if (settings.HasFlag(Grouping.ByYear))
                    dateFolders = Path.Combine(dateFolders, $"{match.Groups[3].Value}"); // yyyy
                if (settings.HasFlag(Grouping.ByMonth))
                    dateFolders = Path.Combine(dateFolders, $"{match.Groups[2].Value}"); // yyyy-mm
                if (settings.HasFlag(Grouping.ByDay))
                    dateFolders = Path.Combine(dateFolders, $"{match.Groups[1].Value}"); // yyyy-mm-dd

                // Create a new directory for the current screenshot (if it does not exist already)
                string destPath = Path.Combine(destination, dateFolders, filename);
                try
                {
                    Directory.CreateDirectory(Path.Combine(destination, dateFolders));
                }
                catch
                {
                    lock (report)
                    {
                        report.FilesFailed++;
                    }
                    progress.Report(report);
                    return;
                }

                // Move screenshot to destination
                try
                {
                    File.Move(file, destPath);
                    lock (report)
                    {
                        report.FilesMoved++;
                    }
                }
                catch
                {
                    lock (report)
                    {
                        report.FilesFailed++;
                    }
                }

                progress.Report(report);
            }));

            // Remove empty subfolders from source
            foreach (string subFolder in subFolders)
            {
                if (Directory.GetFileSystemEntries(subFolder).Length == 0)
                {
                    Directory.Delete(subFolder);
                }
            }

            // Open the destination folder
            System.Diagnostics.Process.Start(destination);
        }
    }
}
