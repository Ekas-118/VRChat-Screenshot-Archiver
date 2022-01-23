using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VRC_Screenshot_Archiver.Library
{
    /// <summary>
    /// Class for archiving VRChat screenshots
    /// </summary>
    public class Archiver
    {
        /// <summary>
        /// Regex for filtering VRChat screenshot files
        /// VRChat_RESXxRESY_YYYY-MM-DD_hh-mm-ss.###.png
        /// </summary>
        private readonly Regex _regex = new Regex("^VRChat_[0-9]{3,4}x[0-9]{3,4}_((([0-9]{4})-[0-9]{2})-[0-9]{2})_[0-9]{2}-[0-9]{2}-[0-9]{2}.[0-9]{3}.png$");
        private readonly ArchiveProgress _report = new ArchiveProgress();

        private readonly IProgress<ArchiveProgress> _progress;
        private readonly ArchiveSettings _settings;

        public event EventHandler<ArchiveSettings> DirectoriesValidated;

        public Archiver(IProgress<ArchiveProgress> progress, ArchiveSettings settings)
        {
            _progress = progress;
            _settings = settings;
        }

        /// <summary>
        /// Archives VRChat screenshots by moving them to another destination and grouping them into folders by date (if specified by grouping settings)
        /// </summary>
        /// <param name="progress">Status information of the method progress</param>
        /// <param name="source">Screenshot folder path</param>
        /// <param name="destination">Destination folder path</param>
        /// <param name="settings">Grouping settings</param>
        public async Task ArchiveAsync()
        {
            // Reset status
            _progress.Report(_report);

            if (!Directory.Exists(_settings.SourceDirectory) || !Directory.Exists(_settings.DestinationDirectory))
            {
                _report.ErrorMessage = "Invalid path(s).";
                _progress.Report(_report);
                return;
            }

            OnDirectoriesValidated();

            List<string> subFolders = new List<string>(Directory.GetDirectories(_settings.SourceDirectory));

            List<string> files;
            try
            {
                files = GetAllFiles(subFolders);
            }
            catch
            {
                _report.ErrorMessage = "Invalid source path.";
                return;
            }
            finally
            {
                _progress.Report(_report);
            }

            if (files.Count == 0)
            {
                return;
            }

            await MoveScreenshots(files);

            RemoveEmptySubfolders(subFolders);

            // Open the destination folder
            System.Diagnostics.Process.Start(_settings.DestinationDirectory);
        }

        private async Task MoveScreenshots(List<string> files)
        {
            await Task.Run(() => Parallel.ForEach(files, (file) =>
            {
                string filename = Path.GetFileName(file);

                var match = _regex.Match(filename);

                if (!match.Success)
                {
                    return;
                }

                string dateFolders = GetDateFolders(match);

                string destPath = Path.Combine(_settings.DestinationDirectory, dateFolders, filename);
                try
                {
                    Directory.CreateDirectory(Path.Combine(_settings.DestinationDirectory, dateFolders));
                }
                catch
                {
                    lock (_report)
                    {
                        _report.FilesFailed++;
                    }
                    _progress.Report(_report);
                    return;
                }

                MoveFile(file, destPath);

                _progress.Report(_report);
            }));
        }

        private List<string> GetAllFiles(List<string> subFolders)
        {
            List<string> files = Directory.GetFiles(_settings.SourceDirectory, "*VRChat_*.png").ToList();
            foreach (string src in subFolders)
            {
                files.AddRange(Directory.GetFiles(src, "*VRChat_*.png"));
            }
            _report.ImagesFound = files.Count;
            return files;
        }

        private void MoveFile(string file, string destPath)
        {
            try
            {
                File.Move(file, destPath);
                lock (_report)
                {
                    _report.FilesMoved++;
                }
            }
            catch
            {
                lock (_report)
                {
                    _report.FilesFailed++;
                }
            }
        }

        private string GetDateFolders(Match match)
        {
            string dateFolders = string.Empty;
            if (_settings.GroupingSettings.HasFlag(Grouping.ByYear))
                dateFolders = Path.Combine(dateFolders, $"{match.Groups[3].Value}"); // yyyy
            if (_settings.GroupingSettings.HasFlag(Grouping.ByMonth))
                dateFolders = Path.Combine(dateFolders, $"{match.Groups[2].Value}"); // yyyy-mm
            if (_settings.GroupingSettings.HasFlag(Grouping.ByDay))
                dateFolders = Path.Combine(dateFolders, $"{match.Groups[1].Value}"); // yyyy-mm-dd
            return dateFolders;
        }

        private void RemoveEmptySubfolders(List<string> subFolders)
        {
            foreach (string subFolder in subFolders)
            {
                if (Directory.GetFileSystemEntries(subFolder).Length == 0)
                {
                    Directory.Delete(subFolder);
                }
            }
        }

        private void OnDirectoriesValidated()
        {
            DirectoriesValidated?.Invoke(this, _settings);
        }
    }
}
