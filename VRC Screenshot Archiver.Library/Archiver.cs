using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace VRC_Screenshot_Archiver.Library
{
    /// <summary>
    /// Class for archiving VRChat screenshots
    /// </summary>
    public class Archiver
    {
        /// <summary>
        /// Old VRChat screenshot filename format <br/>
        /// VRChat_RESXxRESY_YYYY-MM-DD_hh-mm-ss.###.png
        /// </summary>
        private readonly Regex _oldFileRegex = new Regex("^VRChat_[0-9]{3,4}x[0-9]{3,4}_((([0-9]{4})-[0-9]{2})-[0-9]{2})_[0-9]{2}-[0-9]{2}-[0-9]{2}.[0-9]{3}.png$");

        private ArchiveProgress _progress;

        private readonly IProgress<ArchiveProgress> _progressProvider;
        private readonly ArchiveSettings _settings;

        public event EventHandler<ArchiveSettings> DirectoriesValidated;

        public Archiver(IProgress<ArchiveProgress> progressProvider, ArchiveSettings settings)
        {
            _progressProvider = progressProvider;
            _settings = settings;
        }

        /// <summary>
        /// Archives VRChat screenshots by moving them to another destination and grouping them into folders by date (if specified by grouping settings)
        /// </summary>
        public async Task ArchiveAsync()
        {
            _progress = new ArchiveProgress();

            if (ValidateDirectories() == false)
            {
                return;
            }

            IEnumerable<string> subFolders = Directory.GetDirectories(_settings.SourceDirectory);

            List<string> files;
            try
            {
                files = await GetAllFilesAsync(subFolders);
            }
            catch
            {
                _progress.ErrorMessage = "Invalid source path.";
                return;
            }
            finally
            {
                _progressProvider.Report(_progress);
            }

            if (files.Count == 0)
            {
                return;
            }

            await MoveScreenshots(files);

            RemoveEmptySubfolders(subFolders);

            // Open the destination folder
            Process.Start(_settings.DestinationDirectory);
        }

        private bool ValidateDirectories()
        {
            if (!Directory.Exists(_settings.SourceDirectory) || !Directory.Exists(_settings.DestinationDirectory))
            {
                _progress.ErrorMessage = "Invalid path(s).";
                _progressProvider.Report(_progress);
                return false;
            }

            DirectoriesValidated?.Invoke(this, _settings);
            return true;
        }

        private async Task MoveScreenshots(List<string> files)
        {
            await Task.Run(() => Parallel.ForEach(files, (file) =>
            {
                string filename = Path.GetFileName(file);

                var match = _oldFileRegex.Match(filename);

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
                    Interlocked.Increment(ref _progress.FilesFailed);
                    _progressProvider.Report(_progress);
                    return;
                }

                MoveFile(file, destPath);

                _progressProvider.Report(_progress);
            }));
        }

        private async Task<List<string>> GetAllFilesAsync(IEnumerable<string> subFolders)
        {
            const string imageFileFormat = "*VRChat_*.png";

            return await Task.Run(() =>
            {
                var rootFiles = Directory.GetFiles(_settings.SourceDirectory, imageFileFormat);
                _progress.ImagesFound += rootFiles.Length;
                _progressProvider.Report(_progress);

                var uniqueFiles = new ConcurrentDictionary<string, string>(rootFiles
                    .Select(path => new KeyValuePair<string, string>(Path.GetFileName(path), path)));

                subFolders.AsParallel()
                    .ForAll(sub =>
                    {
                        var files = Directory.GetFiles(sub, imageFileFormat);
                        Interlocked.Add(ref _progress.ImagesFound, files.Length);
                        _progressProvider.Report(_progress);

                        foreach (var filePath in files)
                        {
                            string filename = Path.GetFileName(filePath);
                            uniqueFiles.TryAdd(filename, filePath);
                        }
                    });

                return uniqueFiles.Values.ToList();
            });
        }

        private void MoveFile(string file, string destPath)
        {
            try
            {
                File.Move(file, destPath);
                Interlocked.Increment(ref _progress.FilesMoved);
            }
            catch
            {
                Interlocked.Increment(ref _progress.FilesFailed);
            }
        }

        private string GetDateFolders(Match match)
        {
            string dateFolders = string.Empty;
            if (_settings.GroupingSettings.HasFlag(FolderGrouping.ByYear))
            {
                dateFolders = Path.Combine(dateFolders, $"{match.Groups[3].Value}"); // yyyy
            }
            if (_settings.GroupingSettings.HasFlag(FolderGrouping.ByMonth))
            {
                dateFolders = Path.Combine(dateFolders, $"{match.Groups[2].Value}"); // yyyy-mm
            }
            if (_settings.GroupingSettings.HasFlag(FolderGrouping.ByDay))
            {
                dateFolders = Path.Combine(dateFolders, $"{match.Groups[1].Value}"); // yyyy-mm-dd
            }
            return dateFolders;
        }

        private void RemoveEmptySubfolders(IEnumerable<string> subFolders)
        {
            try
            {
                subFolders.AsParallel()
                    .Where(path => Directory.GetFileSystemEntries(path).Length == 0)
                    .ForAll(Directory.Delete);
            }
            catch { }
        }
    }
}
