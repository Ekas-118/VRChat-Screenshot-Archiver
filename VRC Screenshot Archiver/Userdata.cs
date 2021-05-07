using System;
using System.IO;

namespace VRC_Screenshot_Archiver
{
    /// <summary>
    /// Class for working with userdata files
    /// </summary>
    public static class Userdata
    {
        /// <summary>
        /// Returns the Userdata folder path
        /// </summary>
        public static string UserdataPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "VRC Screenshot Archiver\\Userdata");
        /// <summary>
        /// Returns the directories.txt file path
        /// </summary>
        public static string DirectoriesPath { get; } = Path.Combine(UserdataPath, "directories.txt");
        
        /// <summary>
        /// Returns the settings.txt file path
        /// </summary>
        public static string SettingsPath { get; } = Path.Combine(UserdataPath, "settings.txt");

        /// <summary>
        /// Gets the contents of the directories.txt file
        /// </summary>
        /// <returns></returns>
        public static string[] GetDirectories()
        {
            if (File.Exists(DirectoriesPath))
            {
                var directories = File.ReadAllLines(DirectoriesPath);
                // If we find 2 directories, return them. Otherwise, return an empty array
                return directories.Length == 2 ? directories : new string[2];
            }
            else
            {
                // Create directory and text file
                Directory.CreateDirectory(UserdataPath);
                File.Create(DirectoriesPath);
                return new string[2];
            }
        }

        /// <summary>
        /// Takes the entered directories and saves them to directories.txt
        /// </summary>
        /// <param name="source">The source directory path</param>
        /// <param name="destination">The destination directory path</param>
        public static void SaveDirectories(string source, string destination)
        {
            // If directories.txt does not exist, create it
            if (!File.Exists(DirectoriesPath))
                File.Create(DirectoriesPath);

            File.WriteAllText(DirectoriesPath, source + "\n" + destination);
        }

        /// <summary>
        /// Gets the contents of the settings.txt file
        /// </summary>
        /// <returns></returns>
        public static Sorting GetSettings()
        {
            if (File.Exists(SettingsPath))
            {
                var settings = File.ReadAllText(SettingsPath).ToCharArray();
                // If we find a int value, return it. Otherwise, return a default value
                return settings.Length == 1 & Char.IsDigit(settings[0]) ? (Sorting)(int)Char.GetNumericValue(settings[0]) : Sorting.ByDay;
            }
            else
            {
                // Create directory and text file
                Directory.CreateDirectory(UserdataPath);
                File.Create(SettingsPath).Dispose();
                File.WriteAllText(SettingsPath, ((int)Sorting.ByDay).ToString());
                return Sorting.ByDay;
            }
        }

        /// <summary>
        /// Takes the entered directories and saves them to settings.txt
        /// </summary>
        /// <param name="settings">The sorting settings</param>
        public static void SaveSettings(Sorting settings)
        {
            // If settings.txt does not exist, create it
            if (!File.Exists(SettingsPath))
                File.Create(SettingsPath);

            File.WriteAllText(SettingsPath, ((int)settings).ToString());
        }

    }
}
