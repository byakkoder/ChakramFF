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

using Interfaces.FFmpegWrapperCore.ChakramSettings;
using Interfaces.FFmpegWrapperCore.DotNetWrappers;

namespace FFmpegWrapperCore.ChakramSettings
{
    public class FFmpegSettingsValidator : IFFmpegSettingsValidator
    {
        #region Fields
        
        private readonly IChakramSettingsSingleton _chakramSettingsSingleton;
        private readonly IFileWrapper _fileWrapper;

        #endregion

        #region Constructor
        
        public FFmpegSettingsValidator(
            IChakramSettingsSingleton chakramSettingsSingleton,
            IFileWrapper fileWrapper)
        {
            _chakramSettingsSingleton = chakramSettingsSingleton;
            _fileWrapper = fileWrapper;
        }

        #endregion

        #region Public Methods
        
        public bool HasValidSettings()
        {
            return _chakramSettingsSingleton.ChakramSettings.IsFFmpegPathInitialized &&
                _fileWrapper.Exists(_chakramSettingsSingleton.ChakramSettings.FFmpegPath) &&
                _fileWrapper.Exists(_chakramSettingsSingleton.ChakramSettings.FFprobePath) &&
                _fileWrapper.Exists(_chakramSettingsSingleton.ChakramSettings.FFplayPath);
        } 

        #endregion
    }
}
