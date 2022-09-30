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

using ChakramFF.Bootstrapper;
using ChakramFF.Forms;
using ChakramFF.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChakramFF
{
    static class Program
    {
        /// <summary>
        /// Start point of the App.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<Type> transientDependencies = new List<Type>();
            transientDependencies.Add(typeof(FrmMain));
            transientDependencies.Add(typeof(FrmSettings));
            transientDependencies.Add(typeof(FrmMerge));
            transientDependencies.Add(typeof(FrmStreamSettings));
            transientDependencies.Add(typeof(PreviewStreamHelper));
            DIInitializer.Initialize(transientDependencies);

            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(DIInitializer.ServiceProvider.GetRequiredService<FrmMain>());
        }
    }
}
