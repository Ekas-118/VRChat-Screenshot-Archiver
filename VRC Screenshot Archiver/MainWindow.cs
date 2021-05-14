using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VRC_Screenshot_Archiver
{
    public partial class MainWindow : Form
    {
        /// <summary>
        /// The screenshot grouping settings
        /// </summary>
        private Grouping _groupSettings;

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
        public MainWindow()
        {
            InitializeComponent();

            // Set the source and destination folder textbox values
            SetDirectories();

            // Get the grouping settings
            _groupSettings = (Grouping)Properties.Settings.Default.GroupSettings;
        }

        /// <summary>
        /// Retrieves directories from user settings and inserts them into source and destination folder textboxes
        /// </summary>
        private void SetDirectories()
        {
            string sourceDirectory = Properties.Settings.Default.SourceDirectory;
            string destinationDirectory = Properties.Settings.Default.DestinationDirectory;

            // If no setting exists...
            if(sourceDirectory == String.Empty)
                // Set source path to Pictures/VRChat
                SourcePath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "VRChat");
            // Otherwise... 
            else
                // Set source folder to the one specified in user settings
                SourcePath.Text = sourceDirectory;

            // Set destination folder
            DestinationPath.Text = destinationDirectory;
        }

        /// <summary>
        /// Sets the text in the status label
        /// </summary>
        /// <param name="value">The value to insert</param>
        public void UpdateStatus(string[] value)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                StatusLabel.Text = value[0] + '\n' + value[1];
            });
        }

        private async void ArchiveButton_Click(object sender, EventArgs e)
        {
            ArchiveButton.Enabled = SettingsButton.Enabled = false;
            await Task.Run(() => Archiver.Archive(SourcePath.Text, DestinationPath.Text, _groupSettings, this));
            ArchiveButton.Enabled = SettingsButton.Enabled = true;
        }

        #region GitHub and settings menu methods

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            // Open the settings window
            SettingsMenu sm = new SettingsMenu(_groupSettings);
            if (sm.ShowDialog() == DialogResult.OK)
            {
                _groupSettings = sm.GroupSettings;
            }
        }

        private void GithubButton_Click(object sender, EventArgs e)
        {
            // Open the GitHub repository of this application in a browser
            System.Diagnostics.Process.Start("https://github.com/Ekas-118/VRChat-Screenshot-Archiver");
        }

        #endregion

        #region Browse button methods

        private void BrowseDestination_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                DestinationPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void BrowseSource_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SourcePath.Text = folderBrowserDialog1.SelectedPath;
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
