using System;
using System.Windows.Forms;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace VRC_Screenshot_Archiver
{
    public partial class MainWindow : Form
    {
        /// <summary>
        /// The screenshot grouping settings
        /// </summary>
        private Grouping _groupSettings;

        private Archiver _archiver;

        #region Window drag variables

        /// <summary>
        /// Mouse location variables for moving the window
        /// </summary>
        private int _mouseinX, _mouseinY, _mouseX, _mouseY;
        /// <summary>
        /// True while the left mouse button is clicked down
        /// </summary>
        private bool _mouseDown = false;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow(Archiver archiver)
        {
            InitializeComponent();

            SetDirectories();

            _groupSettings = (Grouping)Properties.Settings.Default.GroupSettings;

            _archiver = archiver;
        }

        /// <summary>
        /// Retrieves directories from user settings and inserts them into source and destination folder textboxes
        /// </summary>
        private void SetDirectories()
        {
            string sourceDirectory = Properties.Settings.Default.SourceDirectory;
            string destinationDirectory = Properties.Settings.Default.DestinationDirectory;

            if (sourceDirectory == String.Empty)
                // Set source path to Pictures/VRChat unless specified otherwise in user settings
                SourcePath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "VRChat");
            else
                // Set source folder to the one specified in user settings
                SourcePath.Text = sourceDirectory;

            // Set destination folder
            DestinationPath.Text = destinationDirectory;
        }

        /// <summary>
        /// Updates the status label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="status"></param>
        private void UpdateStatus(object sender, ArchiveProgress status)
        {
            // If there is an error message, display it
            if (!string.IsNullOrEmpty(status.ErrorMessage))
            {
                StatusLabel.Text = status.ErrorMessage;
            }
            // otherwise, display the normal info
            else
            {
                StatusLabel.Text = status.Message;
            }
        }

        private async void ArchiveButton_Click(object sender, EventArgs e)
        {
            ArchiveButton.Enabled = SettingsButton.Enabled = false;

            Progress<ArchiveProgress> progress = new Progress<ArchiveProgress>();
            progress.ProgressChanged += UpdateStatus;

            await _archiver.ArchiveAsync(progress, SourcePath.Text, DestinationPath.Text, _groupSettings);

            ArchiveButton.Enabled = SettingsButton.Enabled = true;
        }

        #region GitHub and settings button methods

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
            System.Diagnostics.Process.Start("https://github.com/Ekas-118/VRChat-Screenshot-Archiver");
        }

        #endregion

        #region Browse button methods

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

        #endregion

        #region Control button methods

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Window drag methods

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

                this.SetDesktopLocation(_mouseX, _mouseY);
            }
        }

        private void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }

        #endregion
    }
}
