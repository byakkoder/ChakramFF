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

using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.DotNetWrappers;
using System.Reflection;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.DotNetWrappers
{
    public class ConfigurationWrapper : IConfigurationWrapper
    {
        #region Fields

        private readonly IFileWrapper _fileWrapper;
        private string _settingsPath;

        #endregion

        #region Constructor

        public ConfigurationWrapper(
            IFileWrapper fileWrapper)
        {
            _settingsPath = Path.Combine(AppContext.BaseDirectory, "chakram-settings.json");
            _fileWrapper = fileWrapper;
        }

        #endregion

        #region Public Methods

        public string Load()
        {
            if (!_fileWrapper.Exists(_settingsPath))
            {
                return string.Empty;
            }
            else
            {
                return _fileWrapper.ReadAllText(_settingsPath);
            }
        }

        public void Save(string content)
        {
            _fileWrapper.WriteAllText(_settingsPath, content);
        }

        #endregion
    }
}
