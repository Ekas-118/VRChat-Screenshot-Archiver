using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRC_Screenshot_Archiver
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            // Set the source and destination folder textbox values
            SetDirectories();
        }

        /// <summary>
        /// Retrieves directories from directories.txt and inserts them into source and destination folder textboxes
        /// </summary>
        private void SetDirectories()
        {
            string[] directories = Userdata.GetDirectories();
            SourcePath.Text = directories[0];
            DestinationPath.Text = directories[1];
        }

        /// <summary>
        /// Sets the text in Textbox1
        /// </summary>
        /// <param name="value">The value to insert</param>
        public void SetTextbox1(string value)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Textbox1.Text = value;
            });
        }

        /// <summary>
        /// Sets the text in Textbox2
        /// </summary>
        /// <param name="value">The value to insert</param>
        public void SetTextbox2(string value)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Textbox2.Text = value;
            });
        }

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

        private async void ArchiveButton_Click(object sender, EventArgs e)
        {
            ArchiveButton.Enabled = false;
            await Task.Run(() => Archiver.ArchiveAsync(SourcePath.Text, DestinationPath.Text, this));
            ArchiveButton.Enabled = true;
        }

    }
}
