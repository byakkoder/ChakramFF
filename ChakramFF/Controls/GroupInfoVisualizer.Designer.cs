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
    partial class GroupInfoVisualizer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblGroupTitle = new System.Windows.Forms.Label();
            this.ObjectDataVisualizer = new ChakramFF.ObjectVisualizer();
            this.SuspendLayout();
            // 
            // LblGroupTitle
            // 
            this.LblGroupTitle.AutoSize = true;
            this.LblGroupTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGroupTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.LblGroupTitle.Location = new System.Drawing.Point(37, 32);
            this.LblGroupTitle.Name = "LblGroupTitle";
            this.LblGroupTitle.Size = new System.Drawing.Size(114, 28);
            this.LblGroupTitle.TabIndex = 13;
            this.LblGroupTitle.Text = "Group Title";
            // 
            // ObjectDataVisualizer
            // 
            this.ObjectDataVisualizer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ObjectDataVisualizer.AutoScroll = true;
            this.ObjectDataVisualizer.AutoSize = true;
            this.ObjectDataVisualizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(53)))));
            this.ObjectDataVisualizer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ObjectDataVisualizer.Location = new System.Drawing.Point(42, 76);
            this.ObjectDataVisualizer.Name = "ObjectDataVisualizer";
            this.ObjectDataVisualizer.Size = new System.Drawing.Size(824, 381);
            this.ObjectDataVisualizer.TabIndex = 14;
            // 
            // GroupInfoVisualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(53)))));
            this.Controls.Add(this.ObjectDataVisualizer);
            this.Controls.Add(this.LblGroupTitle);
            this.Name = "GroupInfoVisualizer";
            this.Size = new System.Drawing.Size(909, 487);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblGroupTitle;
        private ObjectVisualizer ObjectDataVisualizer;
    }
}
