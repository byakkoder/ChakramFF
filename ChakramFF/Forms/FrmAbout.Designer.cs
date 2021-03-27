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
    partial class FrmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            this.PicAppLogo = new System.Windows.Forms.PictureBox();
            this.BtnOk = new System.Windows.Forms.Button();
            this.RtbAbout = new System.Windows.Forms.RichTextBox();
            this.PanMainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicAppLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // PanMainContainer
            // 
            this.PanMainContainer.Controls.Add(this.RtbAbout);
            this.PanMainContainer.Controls.Add(this.BtnOk);
            this.PanMainContainer.Controls.Add(this.PicAppLogo);
            this.PanMainContainer.Size = new System.Drawing.Size(706, 537);
            // 
            // PicAppLogo
            // 
            this.PicAppLogo.Image = global::ChakramFF.Properties.Resources.LogoApp;
            this.PicAppLogo.Location = new System.Drawing.Point(49, 31);
            this.PicAppLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PicAppLogo.Name = "PicAppLogo";
            this.PicAppLogo.Size = new System.Drawing.Size(604, 131);
            this.PicAppLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicAppLogo.TabIndex = 9;
            this.PicAppLogo.TabStop = false;
            // 
            // BtnOk
            // 
            this.BtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOk.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOk.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOk.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.BtnOk.Location = new System.Drawing.Point(569, 465);
            this.BtnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(83, 39);
            this.BtnOk.TabIndex = 15;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = false;
            // 
            // RtbAbout
            // 
            this.RtbAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RtbAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(36)))));
            this.RtbAbout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RtbAbout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.RtbAbout.ForeColor = System.Drawing.Color.White;
            this.RtbAbout.Location = new System.Drawing.Point(49, 175);
            this.RtbAbout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RtbAbout.Name = "RtbAbout";
            this.RtbAbout.ReadOnly = true;
            this.RtbAbout.Size = new System.Drawing.Size(603, 299);
            this.RtbAbout.TabIndex = 18;
            this.RtbAbout.Text = resources.GetString("RtbAbout.Text");
            this.RtbAbout.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RtbAbout_LinkClicked);
            // 
            // FrmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.CancelButton = this.BtnOk;
            this.ClientSize = new System.Drawing.Size(724, 598);
            this.FormTitle = "About ChakramFF";
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "FrmAbout";
            this.Load += new System.EventHandler(this.FrmAbout_Load);
            this.PanMainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicAppLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox PicAppLogo;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.RichTextBox RtbAbout;
    }
}
