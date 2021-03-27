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
    partial class FrmSettings
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
            this.FbdFFmpegPath = new System.Windows.Forms.FolderBrowserDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnFFmpegPath = new System.Windows.Forms.Button();
            this.TxtFFmpegPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCleanSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(69, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(529, 1);
            this.panel2.TabIndex = 15;
            // 
            // BtnFFmpegPath
            // 
            this.BtnFFmpegPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnFFmpegPath.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnFFmpegPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFFmpegPath.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFFmpegPath.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.BtnFFmpegPath.Location = new System.Drawing.Point(604, 72);
            this.BtnFFmpegPath.Name = "BtnFFmpegPath";
            this.BtnFFmpegPath.Size = new System.Drawing.Size(93, 49);
            this.BtnFFmpegPath.TabIndex = 14;
            this.BtnFFmpegPath.Text = "Select...";
            this.BtnFFmpegPath.UseVisualStyleBackColor = false;
            this.BtnFFmpegPath.Click += new System.EventHandler(this.BtnFFmpegPath_Click);
            // 
            // TxtFFmpegPath
            // 
            this.TxtFFmpegPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFFmpegPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(53)))));
            this.TxtFFmpegPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtFFmpegPath.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFFmpegPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.TxtFFmpegPath.Location = new System.Drawing.Point(194, 83);
            this.TxtFFmpegPath.Name = "TxtFFmpegPath";
            this.TxtFFmpegPath.ReadOnly = true;
            this.TxtFFmpegPath.Size = new System.Drawing.Size(404, 27);
            this.TxtFFmpegPath.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.label2.Location = new System.Drawing.Point(62, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 28);
            this.label2.TabIndex = 12;
            this.label2.Text = "FFmpeg Path";
            // 
            // BtnCleanSettings
            // 
            this.BtnCleanSettings.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnCleanSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCleanSettings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCleanSettings.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.BtnCleanSettings.Location = new System.Drawing.Point(67, 200);
            this.BtnCleanSettings.Name = "BtnCleanSettings";
            this.BtnCleanSettings.Size = new System.Drawing.Size(219, 49);
            this.BtnCleanSettings.TabIndex = 16;
            this.BtnCleanSettings.Text = "Clear Settings";
            this.BtnCleanSettings.UseVisualStyleBackColor = false;
            this.BtnCleanSettings.Click += new System.EventHandler(this.BtnCleanSettings_Click);
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(759, 294);
            this.ControlBox = false;
            this.Controls.Add(this.BtnCleanSettings);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.BtnFFmpegPath);
            this.Controls.Add(this.TxtFFmpegPath);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog FbdFFmpegPath;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnFFmpegPath;
        private System.Windows.Forms.TextBox TxtFFmpegPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCleanSettings;
    }
}