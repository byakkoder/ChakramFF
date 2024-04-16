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
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.DotNetWrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Test.ChakramSettings
{
    [TestClass]
    public class LoadSettingsManagerTest
    {
        #region Fields
        
        private ILoadSettingsManager _loadSettingsManager;
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

            _loadSettingsManager = new LoadSettingsManager(_chakramSettingsSingleton.Object, _configurationWrapper.Object, _serializationWrapper.Object);
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void LoadTest()
        {
            #region Arrange

            ChakramSettingsInfo expectedSettingsInfo = new ChakramSettingsInfo();
            string settingValue = "testValue";
            _configurationWrapper.Setup(x => x.Load()).Returns(settingValue);
            _serializationWrapper.Setup(x => x.Deserialize<ChakramSettingsInfo>(settingValue)).Returns(expectedSettingsInfo);
            _chakramSettingsSingleton.Setup(x => x.ChakramSettings).Returns(expectedSettingsInfo);

            #endregion

            #region Act

            ChakramSettingsInfo chakramSettingsInfo = _loadSettingsManager.Load();

            #endregion

            #region Assert

            Assert.AreSame(expectedSettingsInfo, chakramSettingsInfo);
            _configurationWrapper.Verify(x => x.Load(), Times.Once);
            _configurationWrapper.VerifyNoOtherCalls();
            _serializationWrapper.Verify(x => x.Deserialize<ChakramSettingsInfo>(settingValue), Times.Once);
            _serializationWrapper.VerifyNoOtherCalls();
            _chakramSettingsSingleton.Verify(x => x.ChakramSettings, Times.Once);
            _chakramSettingsSingleton.VerifySet(x => x.ChakramSettings = expectedSettingsInfo, Times.Once);
            _chakramSettingsSingleton.VerifyNoOtherCalls();

            #endregion
        }

        [TestMethod]
        public void LoadNewTest()
        {
            #region Arrange

            ChakramSettingsInfo expectedSettingsInfo = new ChakramSettingsInfo();
            string settingValue = "testValue";
            _serializationWrapper.Setup(x => x.Deserialize<ChakramSettingsInfo>(settingValue)).Returns(expectedSettingsInfo);

            #endregion

            #region Act

            ChakramSettingsInfo chakramSettingsInfo = _loadSettingsManager.Load();

            #endregion

            #region Assert

            Assert.AreNotSame(expectedSettingsInfo, chakramSettingsInfo);
            _configurationWrapper.Verify(x => x.Load(), Times.Once);
            _configurationWrapper.VerifyNoOtherCalls();
            _serializationWrapper.Verify(x => x.Deserialize<ChakramSettingsInfo>(settingValue), Times.Never);
            _serializationWrapper.VerifyNoOtherCalls();
            _chakramSettingsSingleton.Verify(x => x.ChakramSettings, Times.Once);
            _chakramSettingsSingleton.VerifySet(x => x.ChakramSettings = expectedSettingsInfo, Times.Never);

            #endregion
        } 

        #endregion
    }
}
