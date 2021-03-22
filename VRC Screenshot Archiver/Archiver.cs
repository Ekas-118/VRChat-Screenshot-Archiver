using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
        private static Regex reg = new Regex("^VRChat_[0-9]{3,4}x[0-9]{3,4}_[0-9]{4}-[0-9]{2}-[0-9]{2}_[0-9]{2}-[0-9]{2}-[0-9]{2}.[0-9]{3}.png$");
        /// <summary>
        /// Archives VRChat screenshots by moving them to another destination and grouping them into folders by date
        /// </summary>
        /// <param name="source">Screenshot folder path</param>
        /// <param name="destination">Destination folder path</param>
        /// <param name="form">The main window</param>
        public static async void ArchiveAsync(string source, string destination, MainWindow form)
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
                    form.SetTextbox1("0 images moved. 0 failed.");
                    int moved = 0;
                    int failed = 0;
                    foreach (string i in files)
                    {
                        // Get the filename with extension
                        string filename = Path.GetFileName(i);
                        // If the file is a VRChat screenshot...
                        if (reg.IsMatch(filename))
                        {
                            // Extract date from filename
                            string date = filename.Remove(0, 17).Remove(10);
                            // Create a new directory for a specific date (if it does not exist already)
                            string destPath = Path.Combine(destination, date, filename);
                            //string destPath2 = Path.Combine(destination, date, filename);
                            try
                            {
                                Directory.CreateDirectory(Path.Combine(destination, date));
                            }
                            catch
                            {
                                failed++;
                                form.SetTextbox1(moved + " images moved. " + failed + " failed.");
                                continue; 
                            }
                            // Move file to destination
                            try
                            {
                                File.Move(i, destPath);
                                moved++;
                            }
                            catch
                            { failed++; }
                            form.SetTextbox1(moved + " images moved. " + failed + " failed.");
                        }
                    }
                    MessageBox.Show("Your screenshots have been moved!");
                }
            }
            else
                form.SetTextbox1("Invalid path(s).");
        }
    }
}
