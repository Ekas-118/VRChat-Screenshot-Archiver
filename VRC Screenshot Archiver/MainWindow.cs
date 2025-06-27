using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using VRC_Screenshot_Archiver.Library;
using VRC_Screenshot_Archiver.Properties;

namespace VRC_Screenshot_Archiver
{
    public partial class MainWindow : Form
    {
        private FolderGrouping _groupSettings;

        private int _mouseinX, _mouseinY, _mouseX, _mouseY;
        private bool _mouseDown = false;

        public MainWindow()
        {
            InitializeComponent();

            SetDirectories();

            _groupSettings = (FolderGrouping)Settings.Default.GroupSettings;
        }

        /// <summary>
        /// Retrieves directories from user settings and inserts them into source and destination folder textboxes
        /// </summary>
        private void SetDirectories()
        {
            string sourceDirectory = Settings.Default.SourceDirectory;
            string destinationDirectory = Settings.Default.DestinationDirectory;

            if (sourceDirectory == String.Empty)
            {
                // Pictures/VRChat
                SourcePath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "VRChat");
            }
            else
            {
                SourcePath.Text = sourceDirectory;
            }

            DestinationPath.Text = destinationDirectory;
        }

        private void UpdateStatusLabel(object sender, ArchiveProgress status)
        {
            if (!string.IsNullOrEmpty(status.ErrorMessage))
            {
                StatusLabel.Text = status.ErrorMessage;
            }
            else
            {
                StatusLabel.Text = status.Message;
            }
        }

        private void SaveDirectories(object sender, ArchiveSettings settings)
        {
            Settings.Default.SourceDirectory = settings.SourceDirectory;
            Settings.Default.DestinationDirectory = settings.DestinationDirectory;
            Settings.Default.Save();
        }

        private async void ArchiveButton_Click(object sender, EventArgs e)
        {
            ArchiveButton.Enabled = SettingsButton.Enabled = false;

            Progress<ArchiveProgress> progress = new Progress<ArchiveProgress>();
            progress.ProgressChanged += UpdateStatusLabel;

            ArchiveSettings settings = new ArchiveSettings()
            {
                SourceDirectory = SourcePath.Text,
                DestinationDirectory = DestinationPath.Text,
                GroupingSettings = _groupSettings
            };

            var archiver = new Archiver(progress, settings);
            archiver.DirectoriesValidated += SaveDirectories;

            await archiver.ArchiveAsync();

            ArchiveButton.Enabled = SettingsButton.Enabled = true;
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            using (SettingsMenu sm = new SettingsMenu(_groupSettings))
            {
                if (sm.ShowDialog() == DialogResult.OK)
                {
                    _groupSettings = sm.GroupSettings;
                }
            }
        }

        private void GithubButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Ekas-118/VRChat-Screenshot-Archiver");
        }

        private void BrowseDestination_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                InitialDirectory = DestinationPath.Text
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                DestinationPath.Text = dialog.FileName;
            }
        }

        private void BrowseSource_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                InitialDirectory = SourcePath.Text
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                SourcePath.Text = dialog.FileName;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDown = true;
            _mouseinX = MousePosition.X - Bounds.X;
            _mouseinY = MousePosition.Y - Bounds.Y;
        }

        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDown)
            {
                _mouseX = MousePosition.X - _mouseinX;
                _mouseY = MousePosition.Y - _mouseinY;

                SetDesktopLocation(_mouseX, _mouseY);
            }
        }

        private void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }
    }
}
