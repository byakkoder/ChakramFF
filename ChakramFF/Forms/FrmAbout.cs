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
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace ChakramFF
{
    public partial class FrmAbout : ChakramFF.FrmBase
    {
        #region Constructor

        public FrmAbout()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Events

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            AssemblyName currentAssemblyName = Assembly.GetExecutingAssembly().GetName();

            int major = currentAssemblyName.Version.Major;
            int minor = currentAssemblyName.Version.Minor;
            int patch = currentAssemblyName.Version.Build;

            RtbAbout.Text = RtbAbout.Text.Replace("{version}", $"{major}.{minor}.{patch} - Alpha");
        }

        #endregion

        #region Control Events

        private void RtbAbout_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = e.LinkText, UseShellExecute = true });
        }

        #endregion
    }
}
