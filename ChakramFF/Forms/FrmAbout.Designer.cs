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
            PicAppLogo = new System.Windows.Forms.PictureBox();
            BtnOk = new System.Windows.Forms.Button();
            RtbAbout = new System.Windows.Forms.RichTextBox();
            PanMainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicAppLogo).BeginInit();
            SuspendLayout();
            // 
            // PanMainContainer
            // 
            PanMainContainer.Controls.Add(RtbAbout);
            PanMainContainer.Controls.Add(BtnOk);
            PanMainContainer.Controls.Add(PicAppLogo);
            PanMainContainer.Size = new System.Drawing.Size(618, 503);
            // 
            // PicAppLogo
            // 
            PicAppLogo.Image = Properties.Resources.LogoApp;
            PicAppLogo.Location = new System.Drawing.Point(43, 29);
            PicAppLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            PicAppLogo.Name = "PicAppLogo";
            PicAppLogo.Size = new System.Drawing.Size(528, 123);
            PicAppLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            PicAppLogo.TabIndex = 9;
            PicAppLogo.TabStop = false;
            // 
            // BtnOk
            // 
            BtnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            BtnOk.BackColor = System.Drawing.Color.DarkSlateBlue;
            BtnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BtnOk.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            BtnOk.ForeColor = System.Drawing.Color.LightSteelBlue;
            BtnOk.Location = new System.Drawing.Point(498, 454);
            BtnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            BtnOk.Name = "BtnOk";
            BtnOk.Size = new System.Drawing.Size(73, 37);
            BtnOk.TabIndex = 15;
            BtnOk.Text = "OK";
            BtnOk.UseVisualStyleBackColor = false;
            // 
            // RtbAbout
            // 
            RtbAbout.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            RtbAbout.BackColor = System.Drawing.Color.FromArgb(23, 30, 36);
            RtbAbout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            RtbAbout.Font = new System.Drawing.Font("Segoe UI", 9F);
            RtbAbout.ForeColor = System.Drawing.Color.White;
            RtbAbout.Location = new System.Drawing.Point(43, 164);
            RtbAbout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            RtbAbout.Name = "RtbAbout";
            RtbAbout.ReadOnly = true;
            RtbAbout.Size = new System.Drawing.Size(529, 281);
            RtbAbout.TabIndex = 18;
            RtbAbout.Text = resources.GetString("RtbAbout.Text");
            RtbAbout.LinkClicked += RtbAbout_LinkClicked;
            // 
            // FrmAbout
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            CancelButton = BtnOk;
            ClientSize = new System.Drawing.Size(634, 561);
            FormTitle = "About ChakramFF";
            Name = "FrmAbout";
            Load += FrmAbout_Load;
            PanMainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PicAppLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.PictureBox PicAppLogo;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.RichTextBox RtbAbout;
    }
}
