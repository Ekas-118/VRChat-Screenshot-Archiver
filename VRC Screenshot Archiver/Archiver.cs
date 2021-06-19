using System;
using System.IO;
using System.Text.RegularExpressions;

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
        private readonly Regex _regex = new Regex("^VRChat_[0-9]{3,4}x[0-9]{3,4}_((([0-9]{4})-[0-9]{2})-[0-9]{2})_[0-9]{2}-[0-9]{2}-[0-9]{2}.[0-9]{3}.png$");

        /// <summary>
        /// Event that gets raised when the archiving status changes
        /// </summary>
        public event EventHandler<string[]> StatusUpdated;

        /// <summary>
        /// Archives VRChat screenshots by moving them to another destination and grouping them into folders by date (if specified by grouping settings)
        /// </summary>
        /// <param name="source">Screenshot folder path</param>
        /// <param name="destination">Destination folder path</param>
        /// <param name="settings">Grouping settings</param>
        public void Archive(string source, string destination, Grouping settings)
        {
            // The status of the process
            var status = new string[2];

            // Check whether entered directories exist
            if (!Directory.Exists(source) || !Directory.Exists(destination))
            {
                status[0] = "Invalid path(s).";
                OnStatusUpdated(status);
                return;
            }

            // Reset status
            OnStatusUpdated(status);

            // Save entered directories to user settings
            Properties.Settings.Default.SourceDirectory = source;
            Properties.Settings.Default.DestinationDirectory = destination;
            Properties.Settings.Default.Save();

            // Try to get the files from the source directory that are likely to be screenshots
            string[] files;
            try
            {
                files = Directory.GetFiles(source, "*VRChat_*.png");
            }
            catch
            {
                status[0] = "Invalid source path.";
                OnStatusUpdated(status);
                return;
            }

            status[1] = $"{files.Length} images found.";
            OnStatusUpdated(status);

            // Check whether the source directory contains files
            if (files.Length == 0)
            {
                return;
            }

            status[0] = "0 images moved.";
            OnStatusUpdated(status);

            int moved = 0;
            int failed = 0;
            foreach (string i in files)
            {
                // Get the filename with extension
                string filename = Path.GetFileName(i);

                var match = _regex.Match(filename);

                // Check whether the file is a VRChat screenshot
                if (!match.Success)
                {
                    continue;
                }

                // Prepare the directories for grouping
                string dateFolders = string.Empty;
                if (settings.HasFlag(Grouping.ByYear))
                    dateFolders = Path.Combine(dateFolders, $"{match.Groups[3].Value}"); // yyyy
                if (settings.HasFlag(Grouping.ByMonth))
                    dateFolders = Path.Combine(dateFolders, $"{match.Groups[2].Value}"); // yyyy-mm
                if (settings.HasFlag(Grouping.ByDay))
                    dateFolders = Path.Combine(dateFolders, $"{match.Groups[1].Value}"); // yyyy-mm-dd

                // Try to create a new directory for the current screenshot (if it does not exist already)
                string destPath = Path.Combine(destination, dateFolders, filename);
                try
                {
                    Directory.CreateDirectory(Path.Combine(destination, dateFolders));
                }
                catch
                {
                    failed++;
                    status[0] = $"{moved} images moved. {failed} failed.";
                    OnStatusUpdated(status);
                    continue;
                }

                // Try to move screenshot to destination
                try
                {
                    File.Move(i, destPath);
                    moved++;
                }
                catch
                {
                    failed++;
                }

                status[0] = $"{moved} images moved.{(failed > 0 ? $" {failed} failed." : "")}";
                OnStatusUpdated(status);
            }

            // Open the destination folder
            System.Diagnostics.Process.Start(destination);
        }

        /// <summary>
        /// Raises the StatusUpdated event
        /// </summary>
        /// <param name="status">The archiving process status</param>
        protected virtual void OnStatusUpdated(string[] status)
        {
            StatusUpdated?.Invoke(this, status);
        }
    }
}
