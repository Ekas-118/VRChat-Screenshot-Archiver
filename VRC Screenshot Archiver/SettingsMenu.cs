﻿using System;
using System.Windows.Forms;

namespace VRC_Screenshot_Archiver
{
    public partial class SettingsMenu : Form
    {
        public Sorting SortSettings { get; private set; }

        public SettingsMenu(Sorting settings)
        {
            InitializeComponent();
            // Set checkbox values
            YearCheckBox.Checked = settings.HasFlag(Sorting.ByYear);
            MonthCheckBox.Checked = settings.HasFlag(Sorting.ByMonth);
            DayCheckBox.Checked = settings.HasFlag(Sorting.ByDay);
            SortSettings = settings;
        }

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

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            // Save settings to settings.txt
            Userdata.SaveSettings(SortSettings);
            DialogResult = DialogResult.OK;
        }

        #region Checkbox changed event methods

        private void YearCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SortSettings ^= Sorting.ByYear;
        }

        private void MonthCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SortSettings ^= Sorting.ByMonth;
        }

        private void DayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SortSettings ^= Sorting.ByDay;
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