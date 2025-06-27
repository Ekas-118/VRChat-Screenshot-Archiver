using System;
using System.Windows.Forms;
using VRC_Screenshot_Archiver.Library;
using VRC_Screenshot_Archiver.Properties;

namespace VRC_Screenshot_Archiver
{
    public partial class SettingsMenu : Form
    {
        public FolderGrouping GroupSettings { get; private set; }

        private int _mouseinX, _mouseinY, _mouseX, _mouseY;
        private bool _mouseDown = false;

        public SettingsMenu(FolderGrouping settings)
        {
            InitializeComponent();

            YearCheckBox.Checked = settings.HasFlag(FolderGrouping.ByYear);
            MonthCheckBox.Checked = settings.HasFlag(FolderGrouping.ByMonth);
            DayCheckBox.Checked = settings.HasFlag(FolderGrouping.ByDay);
            GroupSettings = settings;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Settings.Default.GroupSettings = (int)GroupSettings;
            Settings.Default.Save();

            DialogResult = DialogResult.OK;
        }

        private void YearCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GroupSettings ^= FolderGrouping.ByYear;
        }

        private void MonthCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GroupSettings ^= FolderGrouping.ByMonth;
        }

        private void DayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GroupSettings ^= FolderGrouping.ByDay;
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
