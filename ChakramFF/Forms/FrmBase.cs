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

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ChakramFF
{
    public partial class FrmBase : Form
    {
        #region Fields
        
        private Point _startPoint;
        private bool _isResizing;
        private bool _isMoving;
        private bool _resizable;

        #endregion

        #region Properties

        [Category("Appareance"), Description("Form title to display in title bar.")]
        public string FormTitle
        {
            get
            {
                return LblTitle.Text;
            }
            set
            {
                LblTitle.Text = value;
            }
        }

        [Category("Appareance"), Description("Indicates that the form is resizable.")]
        public bool Resizable
        {
            get
            {
                return _resizable;
            }
            set
            {
                _resizable = value;

                SetBorderCursors();
            }
        }

        public new bool MaximizeBox
        {
            get
            {
                return BtnMaximize.Visible;
            }
            set
            {
                BtnMaximize.Visible = value;
            }
        }

        public new bool MinimizeBox
        {
            get
            {
                return BtnMinimize.Visible;
            }
            set
            {
                BtnMinimize.Visible = value;
            }
        }

        #endregion

        #region Constructor
        
        public FrmBase()
        {
            InitializeComponent();

            SetBorderCursors();
        }

        #endregion

        #region Control Events
        
        private void PanResize_MouseDown(object sender, MouseEventArgs e)
        {
            if (!Resizable)
            {
                return;
            }

            _isResizing = true;
            _startPoint = e.Location;
        }

        private void PanResize_MouseUp(object sender, MouseEventArgs e)
        {
            if (!Resizable)
            {
                return;
            }

            _isResizing = false;
        }

        private void PanRight_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Resizable)
            {
                return;
            }

            if (!_isResizing)
            {
                return;
            }

            Size = new Size(Size.Width + e.X - _startPoint.X, Size.Height);
        }

        private void PanDown_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Resizable)
            {
                return;
            }

            if (!_isResizing)
            {
                return;
            }

            Size = new Size(Size.Width, Size.Height + e.Y - _startPoint.Y);
        }

        private void PanLeft_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Resizable)
            {
                return;
            }

            if (!_isResizing)
            {
                return;
            }

            Size = new Size(Size.Width - e.X, Size.Height);
            Location = new Point(Location.X + e.X, Location.Y);
        }

        private void PanUp_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Resizable)
            {
                return;
            }

            if (!_isResizing)
            {
                return;
            }

            Size = new Size(Size.Width, Size.Height - e.Y);
            Location = new Point(Location.X, Location.Y + e.Y);
        }

        private void PanDownRight_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Resizable)
            {
                return;
            }

            if (!_isResizing)
            {
                return;
            }

            Size = new Size(Size.Width + e.X - _startPoint.X, Size.Height + e.Y - _startPoint.Y);
        }

        private void PanDownLeft_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Resizable)
            {
                return;
            }

            if (!_isResizing)
            {
                return;
            }

            Size = new Size(Size.Width - e.X, Size.Height + e.Y - _startPoint.Y);
            Location = new Point(Location.X + e.X, Location.Y);
        }

        private void PanUpLeft_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Resizable)
            {
                return;
            }

            if (!_isResizing)
            {
                return;
            }

            Size = new Size(Size.Width - e.X, Size.Height - e.Y);
            Location = new Point(Location.X + e.X, Location.Y + e.Y);
        }

        private void PanUpRight_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Resizable)
            {
                return;
            }

            if (!_isResizing)
            {
                return;
            }

            Size = new Size(Size.Width + e.X - _startPoint.X, Size.Height - e.Y);
            Location = new Point(Location.X, Location.Y + e.Y);
        }

        private void PanTitle_MouseDown(object sender, MouseEventArgs e)
        {
            _isMoving = true;
            _startPoint = e.Location;
        }

        private void PanTitle_MouseUp(object sender, MouseEventArgs e)
        {
            _isMoving = false;
        }

        private void PanTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isMoving)
            {
                return;
            }

            Location = new Point(Location.X + e.X - _startPoint.X, Location.Y + e.Y - _startPoint.Y);
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LblTitle_DoubleClick(object sender, EventArgs e)
        {
            if (!MaximizeBox)
            {
                return;
            }

            WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        #endregion

        #region Private Methods
        
        private void SetBorderCursors()
        {
            if (_resizable)
            {
                SetResizableCursors();
            }
            else
            {
                SetNotResizableCursors();
            }
        }

        private void SetResizableCursors()
        {
            PanUp.Cursor = Cursors.SizeNS;
            PanDown.Cursor = Cursors.SizeNS;
            PanLeft.Cursor = Cursors.SizeWE;
            PanRight.Cursor = Cursors.SizeWE;
            PanUpLeft.Cursor = Cursors.SizeNWSE;
            PanDownRight.Cursor = Cursors.SizeNWSE;
            PanDownLeft.Cursor = Cursors.SizeNESW;
        }

        private void SetNotResizableCursors()
        {
            PanUp.Cursor = Cursors.Default;
            PanDown.Cursor = Cursors.Default;
            PanLeft.Cursor = Cursors.Default;
            PanRight.Cursor = Cursors.Default;
            PanUpLeft.Cursor = Cursors.Default;
            PanDownRight.Cursor = Cursors.Default;
            PanDownLeft.Cursor = Cursors.Default;
        } 

        #endregion
    }
}
