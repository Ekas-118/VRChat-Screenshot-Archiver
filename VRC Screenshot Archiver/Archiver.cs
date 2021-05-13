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
        /// Archives VRChat screenshots by moving them to another destination and grouping them into folders by date (if specified by grouping settings)
        /// </summary>
        /// <param name="source">Screenshot folder path</param>
        /// <param name="destination">Destination folder path</param>
        /// <param name="settings">Grouping settings</param>
        /// <param name="form">The main window</param>
        public static void Archive(string source, string destination, Grouping settings, MainWindow form)
        {
            // If entered directories are valid...
            if (Directory.Exists(source) && Directory.Exists(destination))
            {
                // Clear out textboxes
                form.SetTextbox1("");
                form.SetTextbox2("");

                // Save entered directories to user settings
                Properties.Settings.Default.SourceDirectory = source;
                Properties.Settings.Default.DestinationDirectory = destination;
                Properties.Settings.Default.Save();

                string[] files;
                try
                {
                    // Get the files of the source directory that are likely to be screenshots
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

                            // Prepare the directories for grouping
                            string dateFolders = string.Empty;
                            if (settings.HasFlag(Grouping.ByYear))
                                dateFolders = Path.Combine(dateFolders, $"{date.Remove(4)}");
                            if (settings.HasFlag(Grouping.ByMonth))
                                dateFolders = Path.Combine(dateFolders, $"{date.Remove(7)}");
                            if (settings.HasFlag(Grouping.ByDay))
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
            // If entered directories are invalid...
            else
                form.SetTextbox1("Invalid path(s).");
        }
    }
}
