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
    partial class FrmMediaInfo
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
            this.MediaInfoVisualizer = new ChakramFF.MediaInfoVisualizer();
            this.SuspendLayout();
            // 
            // PanMainContainer
            // 
            this.PanMainContainer.Size = new System.Drawing.Size(1060, 464);
            // 
            // MediaInfoVisualizer
            // 
            this.MediaInfoVisualizer.AutoScroll = true;
            this.MediaInfoVisualizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(53)))));
            this.MediaInfoVisualizer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MediaInfoVisualizer.Location = new System.Drawing.Point(10, 66);
            this.MediaInfoVisualizer.Name = "MediaInfoVisualizer";
            this.MediaInfoVisualizer.Size = new System.Drawing.Size(1060, 464);
            this.MediaInfoVisualizer.TabIndex = 6;
            // 
            // FrmMediaInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.ClientSize = new System.Drawing.Size(1080, 540);
            this.Controls.Add(this.MediaInfoVisualizer);
            this.FormTitle = "Media Info.";
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.MinimumSize = new System.Drawing.Size(1080, 540);
            this.Name = "FrmMediaInfo";
            this.Resizable = true;
            this.Controls.SetChildIndex(this.PanMainContainer, 0);
            this.Controls.SetChildIndex(this.MediaInfoVisualizer, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private MediaInfoVisualizer MediaInfoVisualizer;
    }
}
