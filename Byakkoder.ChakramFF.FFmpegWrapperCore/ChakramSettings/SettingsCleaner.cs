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

using Byakkoder.ChakramFF.Entities;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.ChakramSettings;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.ChakramSettings
{
    public class SettingsCleaner : ISettingsCleaner
    {
        #region Fields
        
        private readonly IChakramSettingsSingleton _chakramSettingsSingleton;
        private readonly ISaveSettingsManager _saveSettingsManager;

        #endregion

        #region Constructor
        
        public SettingsCleaner(
            IChakramSettingsSingleton chakramSettingsSingleton,
            ISaveSettingsManager saveSettingsManager)
        {
            _chakramSettingsSingleton = chakramSettingsSingleton;
            _saveSettingsManager = saveSettingsManager;
        }

        #endregion

        #region Public Methods
        
        public void Clear()
        {
            _chakramSettingsSingleton.ChakramSettings = new ChakramSettingsInfo();
            _saveSettingsManager.Save();
        } 

        #endregion
    }
}
