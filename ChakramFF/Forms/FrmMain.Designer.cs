/*********************************************************************************
 Copyright (C) 2021-present John García
 
 This file is part of ChakramFF.

 ChakramFF is free software: you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation, either version 3 of the License, or
 (at your option) any later version.
 
 ChakramFF is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.
 
 You should have received a copy of the GNU General Public License
 along with this program.  If not, see https://www.gnu.org/licenses/.

 For more details, see README.md.
 *********************************************************************************/

namespace ChakramFF
{
    partial class FrmMain
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
            this.PanContent = new System.Windows.Forms.Panel();
            this.PanSideBar = new System.Windows.Forms.Panel();
            this.PanMenu = new System.Windows.Forms.Panel();
            this.BtnAbout = new System.Windows.Forms.Button();
            this.BtnSettings = new System.Windows.Forms.Button();
            this.BtnMerge = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.PanLine = new System.Windows.Forms.Panel();
            this.PanLogo = new System.Windows.Forms.Panel();
            this.PicAppLogo = new System.Windows.Forms.PictureBox();
            this.PanSideBar.SuspendLayout();
            this.PanMenu.SuspendLayout();
            this.PanLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicAppLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // PanMainContainer
            // 
            this.PanMainContainer.Margin = new System.Windows.Forms.Padding(1);
            this.PanMainContainer.Size = new System.Drawing.Size(1027, 494);
            // 
            // PanContent
            // 
            this.PanContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanContent.Location = new System.Drawing.Point(272, 53);
            this.PanContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanContent.Name = "PanContent";
            this.PanContent.Padding = new System.Windows.Forms.Padding(4);
            this.PanContent.Size = new System.Drawing.Size(764, 494);
            this.PanContent.TabIndex = 6;
            // 
            // PanSideBar
            // 
            this.PanSideBar.Controls.Add(this.PanMenu);
            this.PanSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanSideBar.Location = new System.Drawing.Point(9, 53);
            this.PanSideBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanSideBar.Name = "PanSideBar";
            this.PanSideBar.Padding = new System.Windows.Forms.Padding(4);
            this.PanSideBar.Size = new System.Drawing.Size(263, 494);
            this.PanSideBar.TabIndex = 5;
            // 
            // PanMenu
            // 
            this.PanMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(53)))));
            this.PanMenu.Controls.Add(this.BtnAbout);
            this.PanMenu.Controls.Add(this.BtnSettings);
            this.PanMenu.Controls.Add(this.BtnMerge);
            this.PanMenu.Controls.Add(this.BtnExit);
            this.PanMenu.Controls.Add(this.PanLine);
            this.PanMenu.Controls.Add(this.PanLogo);
            this.PanMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanMenu.Location = new System.Drawing.Point(4, 4);
            this.PanMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanMenu.Name = "PanMenu";
            this.PanMenu.Size = new System.Drawing.Size(255, 486);
            this.PanMenu.TabIndex = 0;
            // 
            // BtnAbout
            // 
            this.BtnAbout.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnAbout.FlatAppearance.BorderSize = 0;
            this.BtnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAbout.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.BtnAbout.Image = global::ChakramFF.Properties.Resources.info_icon;
            this.BtnAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAbout.Location = new System.Drawing.Point(0, 210);
            this.BtnAbout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(255, 57);
            this.BtnAbout.TabIndex = 5;
            this.BtnAbout.Text = " About";
            this.BtnAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAbout.UseVisualStyleBackColor = true;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // BtnSettings
            // 
            this.BtnSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnSettings.FlatAppearance.BorderSize = 0;
            this.BtnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.BtnSettings.Image = global::ChakramFF.Properties.Resources.settings_icon;
            this.BtnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSettings.Location = new System.Drawing.Point(0, 153);
            this.BtnSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSettings.Name = "BtnSettings";
            this.BtnSettings.Size = new System.Drawing.Size(255, 57);
            this.BtnSettings.TabIndex = 2;
            this.BtnSettings.Text = " Settings";
            this.BtnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSettings.UseVisualStyleBackColor = true;
            this.BtnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // BtnMerge
            // 
            this.BtnMerge.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnMerge.FlatAppearance.BorderSize = 0;
            this.BtnMerge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMerge.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMerge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.BtnMerge.Image = global::ChakramFF.Properties.Resources.merge_icon_24;
            this.BtnMerge.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMerge.Location = new System.Drawing.Point(0, 96);
            this.BtnMerge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnMerge.Name = "BtnMerge";
            this.BtnMerge.Size = new System.Drawing.Size(255, 57);
            this.BtnMerge.TabIndex = 8;
            this.BtnMerge.Text = " Merge Files";
            this.BtnMerge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMerge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnMerge.UseVisualStyleBackColor = true;
            this.BtnMerge.Click += new System.EventHandler(this.BtnMerge_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnExit.FlatAppearance.BorderSize = 0;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.BtnExit.Image = global::ChakramFF.Properties.Resources.exit_icon;
            this.BtnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExit.Location = new System.Drawing.Point(0, 429);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(255, 57);
            this.BtnExit.TabIndex = 4;
            this.BtnExit.Text = " Exit";
            this.BtnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // PanLine
            // 
            this.PanLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanLine.BackColor = System.Drawing.Color.Silver;
            this.PanLine.Location = new System.Drawing.Point(12, 423);
            this.PanLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanLine.Name = "PanLine";
            this.PanLine.Size = new System.Drawing.Size(232, 1);
            this.PanLine.TabIndex = 3;
            // 
            // PanLogo
            // 
            this.PanLogo.Controls.Add(this.PicAppLogo);
            this.PanLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanLogo.Location = new System.Drawing.Point(0, 0);
            this.PanLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanLogo.Name = "PanLogo";
            this.PanLogo.Size = new System.Drawing.Size(255, 96);
            this.PanLogo.TabIndex = 7;
            // 
            // PicAppLogo
            // 
            this.PicAppLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicAppLogo.Image = global::ChakramFF.Properties.Resources.LogoApp;
            this.PicAppLogo.Location = new System.Drawing.Point(8, 7);
            this.PicAppLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PicAppLogo.Name = "PicAppLogo";
            this.PicAppLogo.Size = new System.Drawing.Size(239, 80);
            this.PicAppLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicAppLogo.TabIndex = 0;
            this.PicAppLogo.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(1045, 555);
            this.Controls.Add(this.PanContent);
            this.Controls.Add(this.PanSideBar);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.MinimumSize = new System.Drawing.Size(960, 432);
            this.Name = "FrmMain";
            this.Resizable = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Controls.SetChildIndex(this.PanMainContainer, 0);
            this.Controls.SetChildIndex(this.PanSideBar, 0);
            this.Controls.SetChildIndex(this.PanContent, 0);
            this.PanSideBar.ResumeLayout(false);
            this.PanMenu.ResumeLayout(false);
            this.PanLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicAppLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanContent;
        private System.Windows.Forms.Panel PanSideBar;
        private System.Windows.Forms.Panel PanMenu;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Panel PanLine;
        private System.Windows.Forms.Button BtnSettings;
        private System.Windows.Forms.Button BtnAbout;
        private System.Windows.Forms.Panel PanLogo;
        private System.Windows.Forms.PictureBox PicAppLogo;
        private System.Windows.Forms.Button BtnMerge;
    }
}