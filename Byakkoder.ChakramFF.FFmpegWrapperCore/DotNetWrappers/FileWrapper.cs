﻿/*********************************************************************************
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

using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.DotNetWrappers;
using System.IO;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.DotNetWrappers
{
    /// <summary>
    /// This class is a DotNet wrapper to help testing application code without DotNet Framework
    /// dependencies because Microsoft Fakes (shim) is not available in Visual Studio Community.
    /// For more information visit https://docs.microsoft.com/en-us/visualstudio/test/isolating-code-under-test-with-microsoft-fakes?view=vs-2019
    /// </summary>
    public class FileWrapper : IFileWrapper
    {
        #region Public Methods
        
        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public void Create(string path)
        {
            File.Create(path);
        }

        public void Delete(string path)
        {
            File.Delete(path);
        }

        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        public void WriteAllText(string path, string content)
        {
            File.WriteAllText(path, content);
        }

        #endregion
    }
}
