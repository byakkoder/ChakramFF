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
    partial class FrmBase
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBase));
            this.PanRight = new System.Windows.Forms.Panel();
            this.PanLeft = new System.Windows.Forms.Panel();
            this.PanUp = new System.Windows.Forms.Panel();
            this.PanUpRight = new System.Windows.Forms.Panel();
            this.PanUpLeft = new System.Windows.Forms.Panel();
            this.PanDown = new System.Windows.Forms.Panel();
            this.PanDownRight = new System.Windows.Forms.Panel();
            this.PanDownLeft = new System.Windows.Forms.Panel();
            this.PanTitle = new System.Windows.Forms.Panel();
            this.LblTitle = new System.Windows.Forms.Label();
            this.BtnMinimize = new System.Windows.Forms.Button();
            this.BtnMaximize = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.PanMainContainer = new System.Windows.Forms.Panel();
            this.FormToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.PanUp.SuspendLayout();
            this.PanDown.SuspendLayout();
            this.PanTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanRight
            // 
            this.PanRight.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.PanRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanRight.Location = new System.Drawing.Point(790, 10);
            this.PanRight.Name = "PanRight";
            this.PanRight.Size = new System.Drawing.Size(10, 430);
            this.PanRight.TabIndex = 0;
            this.PanRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanResize_MouseDown);
            this.PanRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanRight_MouseMove);
            this.PanRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanResize_MouseUp);
            // 
            // PanLeft
            // 
            this.PanLeft.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.PanLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanLeft.Location = new System.Drawing.Point(0, 10);
            this.PanLeft.Name = "PanLeft";
            this.PanLeft.Size = new System.Drawing.Size(10, 430);
            this.PanLeft.TabIndex = 1;
            this.PanLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanResize_MouseDown);
            this.PanLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanLeft_MouseMove);
            this.PanLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanResize_MouseUp);
            // 
            // PanUp
            // 
            this.PanUp.Controls.Add(this.PanUpRight);
            this.PanUp.Controls.Add(this.PanUpLeft);
            this.PanUp.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.PanUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanUp.Location = new System.Drawing.Point(0, 0);
            this.PanUp.Name = "PanUp";
            this.PanUp.Size = new System.Drawing.Size(800, 10);
            this.PanUp.TabIndex = 2;
            this.PanUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanResize_MouseDown);
            this.PanUp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanUp_MouseMove);
            this.PanUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanResize_MouseUp);
            // 
            // PanUpRight
            // 
            this.PanUpRight.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.PanUpRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanUpRight.Location = new System.Drawing.Point(790, 0);
            this.PanUpRight.Name = "PanUpRight";
            this.PanUpRight.Size = new System.Drawing.Size(10, 10);
            this.PanUpRight.TabIndex = 1;
            this.PanUpRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanResize_MouseDown);
            this.PanUpRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanUpRight_MouseMove);
            this.PanUpRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanResize_MouseUp);
            // 
            // PanUpLeft
            // 
            this.PanUpLeft.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.PanUpLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanUpLeft.Location = new System.Drawing.Point(0, 0);
            this.PanUpLeft.Name = "PanUpLeft";
            this.PanUpLeft.Size = new System.Drawing.Size(10, 10);
            this.PanUpLeft.TabIndex = 0;
            this.PanUpLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanResize_MouseDown);
            this.PanUpLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanUpLeft_MouseMove);
            this.PanUpLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanResize_MouseUp);
            // 
            // PanDown
            // 
            this.PanDown.Controls.Add(this.PanDownRight);
            this.PanDown.Controls.Add(this.PanDownLeft);
            this.PanDown.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.PanDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanDown.Location = new System.Drawing.Point(0, 440);
            this.PanDown.Name = "PanDown";
            this.PanDown.Size = new System.Drawing.Size(800, 10);
            this.PanDown.TabIndex = 3;
            this.PanDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanResize_MouseDown);
            this.PanDown.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanDown_MouseMove);
            this.PanDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanResize_MouseUp);
            // 
            // PanDownRight
            // 
            this.PanDownRight.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.PanDownRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanDownRight.Location = new System.Drawing.Point(790, 0);
            this.PanDownRight.Name = "PanDownRight";
            this.PanDownRight.Size = new System.Drawing.Size(10, 10);
            this.PanDownRight.TabIndex = 1;
            this.PanDownRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanResize_MouseDown);
            this.PanDownRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanDownRight_MouseMove);
            this.PanDownRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanResize_MouseUp);
            // 
            // PanDownLeft
            // 
            this.PanDownLeft.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.PanDownLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanDownLeft.Location = new System.Drawing.Point(0, 0);
            this.PanDownLeft.Name = "PanDownLeft";
            this.PanDownLeft.Size = new System.Drawing.Size(10, 10);
            this.PanDownLeft.TabIndex = 0;
            this.PanDownLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanResize_MouseDown);
            this.PanDownLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanDownLeft_MouseMove);
            this.PanDownLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanResize_MouseUp);
            // 
            // PanTitle
            // 
            this.PanTitle.Controls.Add(this.LblTitle);
            this.PanTitle.Controls.Add(this.BtnMinimize);
            this.PanTitle.Controls.Add(this.BtnMaximize);
            this.PanTitle.Controls.Add(this.BtnClose);
            this.PanTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanTitle.Location = new System.Drawing.Point(10, 10);
            this.PanTitle.Name = "PanTitle";
            this.PanTitle.Size = new System.Drawing.Size(780, 56);
            this.PanTitle.TabIndex = 4;
            this.PanTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanTitle_MouseDown);
            this.PanTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanTitle_MouseMove);
            this.PanTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanTitle_MouseUp);
            // 
            // LblTitle
            // 
            this.LblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(7, 11);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(629, 35);
            this.LblTitle.TabIndex = 3;
            this.LblTitle.Text = "ChakramFF";
            this.LblTitle.DoubleClick += new System.EventHandler(this.LblTitle_DoubleClick);
            this.LblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanTitle_MouseDown);
            this.LblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanTitle_MouseMove);
            this.LblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanTitle_MouseUp);
            // 
            // BtnMinimize
            // 
            this.BtnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnMinimize.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMinimize.Image = global::ChakramFF.Properties.Resources.minimize_icon_16;
            this.BtnMinimize.Location = new System.Drawing.Point(642, 6);
            this.BtnMinimize.Name = "BtnMinimize";
            this.BtnMinimize.Size = new System.Drawing.Size(40, 40);
            this.BtnMinimize.TabIndex = 2;
            this.FormToolTip.SetToolTip(this.BtnMinimize, "Minimize");
            this.BtnMinimize.UseVisualStyleBackColor = true;
            this.BtnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // BtnMaximize
            // 
            this.BtnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMaximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnMaximize.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMaximize.Image = global::ChakramFF.Properties.Resources.maximize_icon_16;
            this.BtnMaximize.Location = new System.Drawing.Point(688, 6);
            this.BtnMaximize.Name = "BtnMaximize";
            this.BtnMaximize.Size = new System.Drawing.Size(40, 40);
            this.BtnMaximize.TabIndex = 1;
            this.FormToolTip.SetToolTip(this.BtnMaximize, "Maximize");
            this.BtnMaximize.UseVisualStyleBackColor = true;
            this.BtnMaximize.Click += new System.EventHandler(this.BtnMaximize_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Image = global::ChakramFF.Properties.Resources.close_icon_16;
            this.BtnClose.Location = new System.Drawing.Point(734, 6);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(40, 40);
            this.BtnClose.TabIndex = 0;
            this.FormToolTip.SetToolTip(this.BtnClose, "Close");
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // PanMainContainer
            // 
            this.PanMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanMainContainer.Location = new System.Drawing.Point(10, 66);
            this.PanMainContainer.Name = "PanMainContainer";
            this.PanMainContainer.Size = new System.Drawing.Size(780, 374);
            this.PanMainContainer.TabIndex = 5;
            // 
            // FrmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.PanMainContainer);
            this.Controls.Add(this.PanTitle);
            this.Controls.Add(this.PanLeft);
            this.Controls.Add(this.PanRight);
            this.Controls.Add(this.PanUp);
            this.Controls.Add(this.PanDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBase";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.PanUp.ResumeLayout(false);
            this.PanDown.ResumeLayout(false);
            this.PanTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanRight;
        private System.Windows.Forms.Panel PanLeft;
        private System.Windows.Forms.Panel PanUp;
        private System.Windows.Forms.Panel PanUpRight;
        private System.Windows.Forms.Panel PanUpLeft;
        private System.Windows.Forms.Panel PanDown;
        private System.Windows.Forms.Panel PanDownRight;
        private System.Windows.Forms.Panel PanDownLeft;
        private System.Windows.Forms.Panel PanTitle;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnMinimize;
        private System.Windows.Forms.Button BtnMaximize;
        protected System.Windows.Forms.Panel PanMainContainer;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.ToolTip FormToolTip;
    }
}