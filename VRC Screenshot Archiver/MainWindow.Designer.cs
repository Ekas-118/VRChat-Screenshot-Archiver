
using System;
using System.IO;

namespace VRC_Screenshot_Archiver
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.BrowseDestination = new System.Windows.Forms.Button();
            this.SourcePath = new System.Windows.Forms.TextBox();
            this.DestinationPath = new System.Windows.Forms.TextBox();
            this.SourceLabel = new System.Windows.Forms.Label();
            this.DestinationLabel = new System.Windows.Forms.Label();
            this.BrowseSource = new System.Windows.Forms.Button();
            this.ArchiveButton = new System.Windows.Forms.Button();
            this.Textbox1 = new System.Windows.Forms.Label();
            this.Textbox2 = new System.Windows.Forms.Label();
            this.TitleBar = new System.Windows.Forms.Panel();
            this.MinimizeButton = new FontAwesome.Sharp.IconButton();
            this.CloseButton = new FontAwesome.Sharp.IconButton();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.GithubButton = new FontAwesome.Sharp.IconButton();
            this.SettingsButton = new FontAwesome.Sharp.IconButton();
            this.TitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // BrowseDestination
            // 
            this.BrowseDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseDestination.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(136)))), ((int)(((byte)(151)))));
            this.BrowseDestination.FlatAppearance.BorderSize = 0;
            this.BrowseDestination.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseDestination.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseDestination.ForeColor = System.Drawing.Color.White;
            this.BrowseDestination.Location = new System.Drawing.Point(540, 269);
            this.BrowseDestination.Name = "BrowseDestination";
            this.BrowseDestination.Size = new System.Drawing.Size(98, 27);
            this.BrowseDestination.TabIndex = 4;
            this.BrowseDestination.Text = "Browse...";
            this.BrowseDestination.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BrowseDestination.UseVisualStyleBackColor = false;
            this.BrowseDestination.Click += new System.EventHandler(this.BrowseDestination_Click);
            // 
            // SourcePath
            // 
            this.SourcePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SourcePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.SourcePath.Location = new System.Drawing.Point(238, 212);
            this.SourcePath.Name = "SourcePath";
            this.SourcePath.Size = new System.Drawing.Size(296, 26);
            this.SourcePath.TabIndex = 1;
            this.SourcePath.TabStop = false;
            // 
            // DestinationPath
            // 
            this.DestinationPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.DestinationPath.Location = new System.Drawing.Point(238, 269);
            this.DestinationPath.Name = "DestinationPath";
            this.DestinationPath.Size = new System.Drawing.Size(296, 26);
            this.DestinationPath.TabIndex = 3;
            this.DestinationPath.TabStop = false;
            // 
            // SourceLabel
            // 
            this.SourceLabel.AutoSize = true;
            this.SourceLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SourceLabel.ForeColor = System.Drawing.Color.White;
            this.SourceLabel.Location = new System.Drawing.Point(139, 215);
            this.SourceLabel.Name = "SourceLabel";
            this.SourceLabel.Size = new System.Drawing.Size(95, 19);
            this.SourceLabel.TabIndex = 4;
            this.SourceLabel.Text = "Source folder:";
            // 
            // DestinationLabel
            // 
            this.DestinationLabel.AutoSize = true;
            this.DestinationLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DestinationLabel.ForeColor = System.Drawing.Color.White;
            this.DestinationLabel.Location = new System.Drawing.Point(110, 273);
            this.DestinationLabel.Name = "DestinationLabel";
            this.DestinationLabel.Size = new System.Drawing.Size(124, 19);
            this.DestinationLabel.TabIndex = 5;
            this.DestinationLabel.Text = "Destination folder:";
            // 
            // BrowseSource
            // 
            this.BrowseSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(136)))), ((int)(((byte)(151)))));
            this.BrowseSource.FlatAppearance.BorderSize = 0;
            this.BrowseSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseSource.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseSource.ForeColor = System.Drawing.Color.White;
            this.BrowseSource.Location = new System.Drawing.Point(540, 212);
            this.BrowseSource.Name = "BrowseSource";
            this.BrowseSource.Size = new System.Drawing.Size(98, 27);
            this.BrowseSource.TabIndex = 2;
            this.BrowseSource.Text = "Browse...";
            this.BrowseSource.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BrowseSource.UseVisualStyleBackColor = false;
            this.BrowseSource.Click += new System.EventHandler(this.BrowseSource_Click);
            // 
            // ArchiveButton
            // 
            this.ArchiveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ArchiveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(209)))), ((int)(((byte)(237)))));
            this.ArchiveButton.FlatAppearance.BorderSize = 0;
            this.ArchiveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ArchiveButton.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ArchiveButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ArchiveButton.Location = new System.Drawing.Point(266, 343);
            this.ArchiveButton.Name = "ArchiveButton";
            this.ArchiveButton.Size = new System.Drawing.Size(241, 47);
            this.ArchiveButton.TabIndex = 5;
            this.ArchiveButton.Text = "Archive";
            this.ArchiveButton.UseVisualStyleBackColor = false;
            this.ArchiveButton.Click += new System.EventHandler(this.ArchiveButton_Click);
            // 
            // Textbox1
            // 
            this.Textbox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Textbox1.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Textbox1.ForeColor = System.Drawing.Color.White;
            this.Textbox1.Location = new System.Drawing.Point(92, 405);
            this.Textbox1.Name = "Textbox1";
            this.Textbox1.Size = new System.Drawing.Size(592, 20);
            this.Textbox1.TabIndex = 11;
            this.Textbox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Textbox2
            // 
            this.Textbox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Textbox2.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Textbox2.ForeColor = System.Drawing.Color.White;
            this.Textbox2.Location = new System.Drawing.Point(92, 435);
            this.Textbox2.Name = "Textbox2";
            this.Textbox2.Size = new System.Drawing.Size(592, 20);
            this.Textbox2.TabIndex = 12;
            this.Textbox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleBar
            // 
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(209)))), ((int)(((byte)(237)))));
            this.TitleBar.Controls.Add(this.MinimizeButton);
            this.TitleBar.Controls.Add(this.CloseButton);
            this.TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBar.Location = new System.Drawing.Point(0, 0);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(767, 30);
            this.TitleBar.TabIndex = 13;
            this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            this.TitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);
            this.TitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseUp);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.FlatAppearance.BorderSize = 0;
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.MinimizeButton.IconColor = System.Drawing.Color.White;
            this.MinimizeButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.MinimizeButton.IconSize = 25;
            this.MinimizeButton.Location = new System.Drawing.Point(678, 0);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(45, 30);
            this.MinimizeButton.TabIndex = 2;
            this.MinimizeButton.TabStop = false;
            this.MinimizeButton.UseVisualStyleBackColor = true;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.CloseButton.IconColor = System.Drawing.Color.White;
            this.CloseButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.CloseButton.IconSize = 25;
            this.CloseButton.Location = new System.Drawing.Point(722, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Rotation = 90D;
            this.CloseButton.Size = new System.Drawing.Size(45, 30);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.TabStop = false;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(42, 82);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(681, 54);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "VRChat Screenshot Archiver";
            // 
            // GithubButton
            // 
            this.GithubButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.GithubButton.FlatAppearance.BorderSize = 0;
            this.GithubButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GithubButton.IconChar = FontAwesome.Sharp.IconChar.Github;
            this.GithubButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(209)))), ((int)(((byte)(237)))));
            this.GithubButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.GithubButton.Location = new System.Drawing.Point(0, 464);
            this.GithubButton.Name = "GithubButton";
            this.GithubButton.Size = new System.Drawing.Size(46, 48);
            this.GithubButton.TabIndex = 6;
            this.GithubButton.UseVisualStyleBackColor = false;
            this.GithubButton.Click += new System.EventHandler(this.GithubButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.SettingsButton.FlatAppearance.BorderSize = 0;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.SettingsButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(209)))), ((int)(((byte)(237)))));
            this.SettingsButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SettingsButton.IconSize = 40;
            this.SettingsButton.Location = new System.Drawing.Point(721, 464);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(46, 48);
            this.SettingsButton.TabIndex = 14;
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // MainWindow
            // 
            this.AcceptButton = this.ArchiveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(767, 507);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.GithubButton);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.TitleBar);
            this.Controls.Add(this.Textbox2);
            this.Controls.Add(this.Textbox1);
            this.Controls.Add(this.ArchiveButton);
            this.Controls.Add(this.BrowseSource);
            this.Controls.Add(this.BrowseDestination);
            this.Controls.Add(this.DestinationLabel);
            this.Controls.Add(this.SourceLabel);
            this.Controls.Add(this.DestinationPath);
            this.Controls.Add(this.SourcePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(767, 507);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VRC Screenshot Archiver";
            this.TitleBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button BrowseDestination;
        private System.Windows.Forms.TextBox SourcePath;
        private System.Windows.Forms.TextBox DestinationPath;
        private System.Windows.Forms.Label SourceLabel;
        private System.Windows.Forms.Label DestinationLabel;
        private System.Windows.Forms.Button BrowseSource;
        private System.Windows.Forms.Button ArchiveButton;
        private System.Windows.Forms.Label Textbox1;
        private System.Windows.Forms.Label Textbox2;
        private System.Windows.Forms.Panel TitleBar;
        private System.Windows.Forms.Label TitleLabel;
        private FontAwesome.Sharp.IconButton CloseButton;
        private FontAwesome.Sharp.IconButton MinimizeButton;
        private FontAwesome.Sharp.IconButton GithubButton;
        private FontAwesome.Sharp.IconButton SettingsButton;
    }
}

