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
using Byakkoder.ChakramFF.FFmpegWrapperCore.ChakramSettings;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.ChakramSettings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Test.ChakramSettings
{
    [TestClass]
    public class SettingsCleanerTest
    {
        #region Fields
        
        private ISettingsCleaner _settingsCleaner;
        private Mock<IChakramSettingsSingleton> _chakramSettingsSingleton;
        private Mock<ISaveSettingsManager> _saveSettingsManager; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _chakramSettingsSingleton = new Mock<IChakramSettingsSingleton>();
            _saveSettingsManager = new Mock<ISaveSettingsManager>();

            _settingsCleaner = new SettingsCleaner(_chakramSettingsSingleton.Object, _saveSettingsManager.Object);
        }

        #endregion

        #region Test Methods
        
        [TestMethod]
        public void ClearTest()
        {
            #region Arrange and Act

            _settingsCleaner.Clear();

            #endregion

            #region Assert

            _chakramSettingsSingleton.VerifySet(x => x.ChakramSettings = It.IsNotNull<ChakramSettingsInfo>());
            _saveSettingsManager.Verify(x => x.Save());
            _saveSettingsManager.VerifyNoOtherCalls();

            #endregion
        } 

        #endregion
    }
}
