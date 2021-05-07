using System;
using System.IO;
using System.Text.RegularExpressions;

namespace VRC_Screenshot_Archiver
{
    /// <summary>
    /// Class for archiving VRChat screenshots
    /// </summary>
    public static class Archiver
    {
        /// <summary>
        /// Regex for filtering VRChat screenshot files
        /// </summary>
        private static readonly Regex _regex = new Regex("^VRChat_[0-9]{3,4}x[0-9]{3,4}_[0-9]{4}-[0-9]{2}-[0-9]{2}_[0-9]{2}-[0-9]{2}-[0-9]{2}.[0-9]{3}.png$");

        /// <summary>
        /// Archives VRChat screenshots by moving them to another destination and grouping them into folders by date
        /// </summary>
        /// <param name="source">Screenshot folder path</param>
        /// <param name="destination">Destination folder path</param>
        /// <param name="form">The main window</param>
        public static void Archive(string source, string destination, Sorting settings, MainWindow form)
        {
            // Check if entered directories are valid
            if (Directory.Exists(source) && Directory.Exists(destination))
            {
                form.SetTextbox1("");
                form.SetTextbox2("");
                // Save entered directories to directories.txt
                Userdata.SaveDirectories(source, destination);
                // Get all file paths from given source directory
                string[] files;
                try
                {
                    files = Directory.GetFiles(source, "*VRChat_*.png");
                }
                catch
                {
                    form.SetTextbox1("Invalid source path.");
                    return;
                }
                form.SetTextbox2(files.Length + " images found.");
                // If the source directory contains files...
                if (files.Length != 0)
                {
                    form.SetTextbox1("0 images moved.");
                    int moved = 0;
                    int failed = 0;
                    foreach (string i in files)
                    {
                        // Get the filename with extension
                        string filename = Path.GetFileName(i);
                        // If the file is a VRChat screenshot...
                        if (_regex.IsMatch(filename))
                        {
                            // Extract date from filename
                            string date = filename.Remove(0, 17).Remove(10);
                            // Prepare the directories for sorting
                            string dateFolders = string.Empty;
                            if (settings.HasFlag(Sorting.ByYear))
                                dateFolders = Path.Combine(dateFolders, $"{date.Remove(4)}");
                            if (settings.HasFlag(Sorting.ByMonth))
                                dateFolders = Path.Combine(dateFolders, $"{date.Remove(7)}");
                            if (settings.HasFlag(Sorting.ByDay))
                                dateFolders = Path.Combine(dateFolders, $"{date}");

                            // Create a new directory for the current screenshot (if it does not exist already)
                            string destPath = Path.Combine(destination, dateFolders, filename);
                            try
                            {
                                Directory.CreateDirectory(Path.Combine(destination, dateFolders));
                            }
                            catch
                            {
                                failed++;
                                form.SetTextbox1(moved + " images moved. " + failed + " failed.");
                                continue;
                            }
                            // Move screenshot to destination
                            try
                            {
                                File.Move(i, destPath);
                                moved++;
                            }
                            catch
                            { failed++; }
                            form.SetTextbox1(moved + " images moved. " + (failed > 0 ? failed + " failed." : ""));
                        }
                    }
                    // Open the destination folder
                    System.Diagnostics.Process.Start(destination);
                }
            }
            else
                form.SetTextbox1("Invalid path(s).");
        }
    }
}
