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
using Byakkoder.ChakramFF.Entities;
using Byakkoder.ChakramFF.FFmpegWrapperCore.ChakramSettings;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.ChakramSettings;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.DotNetWrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Test.ChakramSettings
{
    [TestClass]
    public class SaveSettingsManagerTest
    {
        #region Fields
        
        private ISaveSettingsManager _saveSettingsManager;
        private Mock<IChakramSettingsSingleton> _chakramSettingsSingleton;
        private Mock<IConfigurationWrapper> _configurationWrapper;
        private Mock<ISerializationWrapper> _serializationWrapper; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _chakramSettingsSingleton = new Mock<IChakramSettingsSingleton>();
            _configurationWrapper = new Mock<IConfigurationWrapper>();
            _serializationWrapper = new Mock<ISerializationWrapper>();

            _saveSettingsManager = new SaveSettingsManager(_chakramSettingsSingleton.Object, _configurationWrapper.Object, _serializationWrapper.Object);
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void SaveTest()
        {
            #region Arrange

            string serializedSettings = "{ settings }";
            ChakramSettingsInfo chakramSettingsInfo = new ChakramSettingsInfo();

            _chakramSettingsSingleton.Setup(x => x.ChakramSettings).Returns(chakramSettingsInfo);
            _serializationWrapper.Setup(x => x.Serialize(chakramSettingsInfo)).Returns(serializedSettings);
            _configurationWrapper.Setup(x => x.Save(serializedSettings));

            #endregion

            #region Act

            _saveSettingsManager.Save();

            #endregion

            #region Assert

            _chakramSettingsSingleton.Verify(x => x.ChakramSettings, Times.Exactly(2));
            _chakramSettingsSingleton.VerifyNoOtherCalls();
            _serializationWrapper.Verify(x => x.Serialize(chakramSettingsInfo), Times.Once);
            _serializationWrapper.VerifyNoOtherCalls();
            _configurationWrapper.Verify(x => x.Save(serializedSettings), Times.Once);
            _configurationWrapper.VerifyNoOtherCalls();

            #endregion
        }

        [TestMethod]
        public void NullSettingsTest()
        {
            #region Arrange

            string serializedSettings = "{ settings }";
            ChakramSettingsInfo chakramSettingsInfo = new ChakramSettingsInfo();

            _serializationWrapper.Setup(x => x.Serialize(chakramSettingsInfo)).Returns(serializedSettings);
            _configurationWrapper.Setup(x => x.Save(serializedSettings));

            #endregion

            #region Act and Assert

            Assert.ThrowsException<ArgumentException>(() => _saveSettingsManager.Save());
            _serializationWrapper.Verify(x => x.Serialize(chakramSettingsInfo), Times.Never);
            _configurationWrapper.Verify(x => x.Save(serializedSettings), Times.Never);

            #endregion
        } 

        #endregion
    }
}
