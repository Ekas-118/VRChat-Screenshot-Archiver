
namespace VRC_Screenshot_Archiver
{
    partial class SettingsMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleBar = new System.Windows.Forms.Panel();
            this.CloseButton = new FontAwesome.Sharp.IconButton();
            this.YearCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.OKButton = new System.Windows.Forms.Button();
            this.DayCheckBox = new System.Windows.Forms.CheckBox();
            this.MonthCheckBox = new System.Windows.Forms.CheckBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TitleBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleBar
            // 
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(209)))), ((int)(((byte)(237)))));
            this.TitleBar.Controls.Add(this.CloseButton);
            this.TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBar.Location = new System.Drawing.Point(0, 0);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(264, 20);
            this.TitleBar.TabIndex = 14;
            this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            this.TitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);
            this.TitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseUp);
            // 
            // CloseButton
            // 
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.CloseButton.IconColor = System.Drawing.Color.White;
            this.CloseButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.CloseButton.IconSize = 20;
            this.CloseButton.Location = new System.Drawing.Point(219, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Rotation = 90D;
            this.CloseButton.Size = new System.Drawing.Size(45, 20);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.TabStop = false;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // YearCheckBox
            // 
            this.YearCheckBox.AutoSize = true;
            this.YearCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.YearCheckBox.FlatAppearance.BorderSize = 5;
            this.YearCheckBox.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.YearCheckBox.ForeColor = System.Drawing.Color.White;
            this.YearCheckBox.Location = new System.Drawing.Point(81, 131);
            this.YearCheckBox.Name = "YearCheckBox";
            this.YearCheckBox.Size = new System.Drawing.Size(105, 23);
            this.YearCheckBox.TabIndex = 15;
            this.YearCheckBox.TabStop = false;
            this.YearCheckBox.Text = "Sort by year";
            this.YearCheckBox.UseVisualStyleBackColor = true;
            this.YearCheckBox.CheckedChanged += new System.EventHandler(this.YearCheckBox_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.panel1.Controls.Add(this.OKButton);
            this.panel1.Controls.Add(this.DayCheckBox);
            this.panel1.Controls.Add(this.MonthCheckBox);
            this.panel1.Controls.Add(this.TitleLabel);
            this.panel1.Controls.Add(this.TitleBar);
            this.panel1.Controls.Add(this.YearCheckBox);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 348);
            this.panel1.TabIndex = 16;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(209)))), ((int)(((byte)(237)))));
            this.OKButton.FlatAppearance.BorderSize = 0;
            this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKButton.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.OKButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OKButton.Location = new System.Drawing.Point(56, 276);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(152, 47);
            this.OKButton.TabIndex = 17;
            this.OKButton.TabStop = false;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = false;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // DayCheckBox
            // 
            this.DayCheckBox.AutoSize = true;
            this.DayCheckBox.FlatAppearance.BorderSize = 0;
            this.DayCheckBox.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.DayCheckBox.ForeColor = System.Drawing.Color.White;
            this.DayCheckBox.Location = new System.Drawing.Point(81, 189);
            this.DayCheckBox.Name = "DayCheckBox";
            this.DayCheckBox.Size = new System.Drawing.Size(100, 23);
            this.DayCheckBox.TabIndex = 18;
            this.DayCheckBox.TabStop = false;
            this.DayCheckBox.Text = "Sort by day";
            this.DayCheckBox.UseVisualStyleBackColor = true;
            this.DayCheckBox.CheckedChanged += new System.EventHandler(this.DayCheckBox_CheckedChanged);
            // 
            // MonthCheckBox
            // 
            this.MonthCheckBox.AutoSize = true;
            this.MonthCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.MonthCheckBox.FlatAppearance.BorderSize = 5;
            this.MonthCheckBox.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.MonthCheckBox.ForeColor = System.Drawing.Color.White;
            this.MonthCheckBox.Location = new System.Drawing.Point(81, 160);
            this.MonthCheckBox.Name = "MonthCheckBox";
            this.MonthCheckBox.Size = new System.Drawing.Size(117, 23);
            this.MonthCheckBox.TabIndex = 17;
            this.MonthCheckBox.TabStop = false;
            this.MonthCheckBox.Text = "Sort by month";
            this.MonthCheckBox.UseVisualStyleBackColor = true;
            this.MonthCheckBox.CheckedChanged += new System.EventHandler(this.MonthCheckBox_CheckedChanged);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(70, 52);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(124, 32);
            this.TitleLabel.TabIndex = 16;
            this.TitleLabel.Text = "Settings";
            // 
            // SettingsMenu
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(266, 350);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsMenu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingsMenu";
            this.TitleBar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitleBar;
        private FontAwesome.Sharp.IconButton CloseButton;
        private System.Windows.Forms.CheckBox YearCheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.CheckBox DayCheckBox;
        private System.Windows.Forms.CheckBox MonthCheckBox;
        private System.Windows.Forms.Button OKButton;
    }
}