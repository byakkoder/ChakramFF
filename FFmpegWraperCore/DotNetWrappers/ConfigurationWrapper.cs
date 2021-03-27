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

using Interfaces.FFmpegWrapperCore.DotNetWrappers;
using System.Configuration;

namespace FFmpegWrapperCore.DotNetWrappers
{
    public class ConfigurationWrapper : IConfigurationWrapper
    {
        #region Fields

        private readonly Configuration _configuration;

        #endregion

        #region Constructor

        public ConfigurationWrapper()
        {
            _configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        #endregion

        #region Public Methods

        public string Load(string settingKey)
        {
            return _configuration.AppSettings.Settings[settingKey]?.Value;
        }

        public void Save(string settingName, string settingValue)
        {
            if (_configuration.AppSettings.Settings[settingName] == null)
            {
                _configuration.AppSettings.Settings.Add(settingName, settingValue);
            }
            else
            {
                _configuration.AppSettings.Settings[settingName].Value = settingValue;
            }

            _configuration.Save();
        }

        #endregion
    }
}
