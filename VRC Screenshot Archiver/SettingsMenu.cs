using System;
using System.Windows.Forms;

namespace VRC_Screenshot_Archiver
{
    public partial class SettingsMenu : Form
    {
        /// <summary>
        /// The grouping settings for archiving screenshots
        /// </summary>
        public Grouping GroupSettings { get; private set; }

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
        /// <param name="settings">The grouping settings</param>
        public SettingsMenu(Grouping settings)
        {
            InitializeComponent();

            YearCheckBox.Checked = settings.HasFlag(Grouping.ByYear);
            MonthCheckBox.Checked = settings.HasFlag(Grouping.ByMonth);
            DayCheckBox.Checked = settings.HasFlag(Grouping.ByDay);
            GroupSettings = settings;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.GroupSettings = (int)GroupSettings;
            Properties.Settings.Default.Save();

            DialogResult = DialogResult.OK;
        }

        #region Checkbox changed event methods

        private void YearCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GroupSettings ^= Grouping.ByYear;
        }

        private void MonthCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GroupSettings ^= Grouping.ByMonth;
        }

        private void DayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GroupSettings ^= Grouping.ByDay;
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
