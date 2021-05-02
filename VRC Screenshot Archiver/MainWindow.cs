using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

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
        /// Mouse location variables for moving the window
        /// </summary>
        int mouseinX, mouseinY, mouseX, mouseY;
        /// <summary>
        /// True while the left mouse button is clicked down
        /// </summary>
        bool mouseDown = false;

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

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void titleBar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseinX = MousePosition.X - Bounds.X;
            mouseinY = MousePosition.Y - Bounds.Y;
        }

        private void titleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - mouseinX;
                mouseY = MousePosition.Y - mouseinY;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void titleBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
