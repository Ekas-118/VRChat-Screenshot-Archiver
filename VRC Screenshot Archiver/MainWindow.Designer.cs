
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BrowseSource = new System.Windows.Forms.Button();
            this.ArchiveButton = new System.Windows.Forms.Button();
            this.Textbox1 = new System.Windows.Forms.Label();
            this.Textbox2 = new System.Windows.Forms.Label();
            this.titleBar = new System.Windows.Forms.Panel();
            this.minimizeButton = new FontAwesome.Sharp.IconButton();
            this.closeButton = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.githubButton = new FontAwesome.Sharp.IconButton();
            this.titleBar.SuspendLayout();
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
            this.BrowseDestination.TabIndex = 1;
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
            this.SourcePath.TabIndex = 2;
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
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(139, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source folder:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(110, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Destination folder:";
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
            this.BrowseSource.TabIndex = 6;
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
            this.ArchiveButton.TabIndex = 8;
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
            this.Textbox1.Size = new System.Drawing.Size(592, 17);
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
            this.Textbox2.Size = new System.Drawing.Size(592, 17);
            this.Textbox2.TabIndex = 12;
            this.Textbox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(209)))), ((int)(((byte)(237)))));
            this.titleBar.Controls.Add(this.minimizeButton);
            this.titleBar.Controls.Add(this.closeButton);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(767, 30);
            this.titleBar.TabIndex = 13;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseDown);
            this.titleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseMove);
            this.titleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseUp);
            // 
            // minimizeButton
            // 
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.minimizeButton.IconColor = System.Drawing.Color.White;
            this.minimizeButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.minimizeButton.IconSize = 25;
            this.minimizeButton.Location = new System.Drawing.Point(678, 0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(45, 30);
            this.minimizeButton.TabIndex = 2;
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.closeButton.IconColor = System.Drawing.Color.White;
            this.closeButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.closeButton.IconSize = 25;
            this.closeButton.Location = new System.Drawing.Point(722, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Rotation = 90D;
            this.closeButton.Size = new System.Drawing.Size(45, 30);
            this.closeButton.TabIndex = 0;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(42, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(681, 54);
            this.label3.TabIndex = 14;
            this.label3.Text = "VRChat Screenshot Archiver";
            // 
            // githubButton
            // 
            this.githubButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.githubButton.FlatAppearance.BorderSize = 0;
            this.githubButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.githubButton.IconChar = FontAwesome.Sharp.IconChar.Github;
            this.githubButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(209)))), ((int)(((byte)(237)))));
            this.githubButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.githubButton.Location = new System.Drawing.Point(0, 464);
            this.githubButton.Name = "githubButton";
            this.githubButton.Size = new System.Drawing.Size(46, 48);
            this.githubButton.TabIndex = 15;
            this.githubButton.UseVisualStyleBackColor = false;
            this.githubButton.Click += new System.EventHandler(this.githubButton_Click);
            // 
            // MainWindow
            // 
            this.AcceptButton = this.ArchiveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(767, 507);
            this.Controls.Add(this.githubButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.titleBar);
            this.Controls.Add(this.Textbox2);
            this.Controls.Add(this.Textbox1);
            this.Controls.Add(this.ArchiveButton);
            this.Controls.Add(this.BrowseSource);
            this.Controls.Add(this.BrowseDestination);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DestinationPath);
            this.Controls.Add(this.SourcePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(767, 507);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VRC Screenshot Archiver";
            this.titleBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button BrowseDestination;
        private System.Windows.Forms.TextBox SourcePath;
        private System.Windows.Forms.TextBox DestinationPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BrowseSource;
        private System.Windows.Forms.Button ArchiveButton;
        private System.Windows.Forms.Label Textbox1;
        private System.Windows.Forms.Label Textbox2;
        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton closeButton;
        private FontAwesome.Sharp.IconButton minimizeButton;
        private FontAwesome.Sharp.IconButton githubButton;
    }
}

