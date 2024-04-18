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
    public class FFmpegSettingsValidatorTest
    {
        #region Fields
        
        private IFFmpegSettingsValidator _fFmpegSettingsValidator = default!;
        private Mock<IChakramSettingsSingleton> _chakramSettingsSingleton = default!;
        private Mock<IFileWrapper> _fileWrapper = default!; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _chakramSettingsSingleton = new Mock<IChakramSettingsSingleton>();
            _fileWrapper = new Mock<IFileWrapper>();

            _fFmpegSettingsValidator = new FFmpegSettingsValidator(_chakramSettingsSingleton.Object, _fileWrapper.Object);
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void HasValidSettingsTest()
        {
            #region Arrange

            string rootPath = @"C:\FFmpeg";
            ChakramSettingsInfo chakramSettingsInfo = new ChakramSettingsInfo() { FFmpegRootPath = rootPath };

            _fileWrapper.Setup(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFmpegFileName}")).Returns(true);
            _fileWrapper.Setup(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFprobeFileName}")).Returns(true);
            _fileWrapper.Setup(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFplayFileName}")).Returns(true);

            _chakramSettingsSingleton.Setup(x => x.ChakramSettings).Returns(chakramSettingsInfo);

            #endregion

            #region Act

            bool isValid = _fFmpegSettingsValidator.HasValidSettings();

            #endregion

            #region Assert

            Assert.IsTrue(isValid);

            _fileWrapper.Verify(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFmpegFileName}"), Times.Once);
            _fileWrapper.Verify(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFprobeFileName}"), Times.Once);
            _fileWrapper.Verify(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFplayFileName}"), Times.Once);
            _fileWrapper.VerifyNoOtherCalls();

            _chakramSettingsSingleton.Verify(x => x.ChakramSettings, Times.Exactly(4));
            _chakramSettingsSingleton.VerifyNoOtherCalls();

            #endregion
        }

        [TestMethod]
        public void NotExistsFFmpegTest()
        {
            #region Arrange

            string rootPath = @"C:\FFmpeg";
            ChakramSettingsInfo chakramSettingsInfo = new ChakramSettingsInfo() { FFmpegRootPath = rootPath };

            _fileWrapper.Setup(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFmpegFileName}")).Returns(false);
            _fileWrapper.Setup(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFprobeFileName}")).Returns(true);
            _fileWrapper.Setup(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFplayFileName}")).Returns(true);

            _chakramSettingsSingleton.Setup(x => x.ChakramSettings).Returns(chakramSettingsInfo);

            #endregion

            #region Act

            bool isValid = _fFmpegSettingsValidator.HasValidSettings();

            #endregion

            #region Assert

            Assert.IsFalse(isValid);

            _fileWrapper.Verify(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFmpegFileName}"), Times.Once);
            _fileWrapper.Verify(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFprobeFileName}"), Times.Never);
            _fileWrapper.Verify(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFplayFileName}"), Times.Never);
            _fileWrapper.VerifyNoOtherCalls();

            _chakramSettingsSingleton.Verify(x => x.ChakramSettings, Times.Exactly(2));
            _chakramSettingsSingleton.VerifyNoOtherCalls();

            #endregion
        }

        [TestMethod]
        public void NotExistsFFprobeTest()
        {
            #region Arrange

            string rootPath = @"C:\FFmpeg";
            ChakramSettingsInfo chakramSettingsInfo = new ChakramSettingsInfo() { FFmpegRootPath = rootPath };

            _fileWrapper.Setup(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFmpegFileName}")).Returns(true);
            _fileWrapper.Setup(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFprobeFileName}")).Returns(false);
            _fileWrapper.Setup(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFplayFileName}")).Returns(true);

            _chakramSettingsSingleton.Setup(x => x.ChakramSettings).Returns(chakramSettingsInfo);

            #endregion

            #region Act

            bool isValid = _fFmpegSettingsValidator.HasValidSettings();

            #endregion

            #region Assert

            Assert.IsFalse(isValid);

            _fileWrapper.Verify(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFmpegFileName}"), Times.Once);
            _fileWrapper.Verify(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFprobeFileName}"), Times.Once);
            _fileWrapper.Verify(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFplayFileName}"), Times.Never);
            _fileWrapper.VerifyNoOtherCalls();

            _chakramSettingsSingleton.Verify(x => x.ChakramSettings, Times.Exactly(3));
            _chakramSettingsSingleton.VerifyNoOtherCalls();

            #endregion
        }

        [TestMethod]
        public void NotExistsFFplayTest()
        {
            #region Arrange

            string rootPath = @"C:\FFmpeg";
            ChakramSettingsInfo chakramSettingsInfo = new ChakramSettingsInfo() { FFmpegRootPath = rootPath };

            _fileWrapper.Setup(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFmpegFileName}")).Returns(true);
            _fileWrapper.Setup(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFprobeFileName}")).Returns(true);
            _fileWrapper.Setup(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFplayFileName}")).Returns(false);

            _chakramSettingsSingleton.Setup(x => x.ChakramSettings).Returns(chakramSettingsInfo);

            #endregion

            #region Act

            bool isValid = _fFmpegSettingsValidator.HasValidSettings();

            #endregion

            #region Assert

            Assert.IsFalse(isValid);

            _fileWrapper.Verify(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFmpegFileName}"), Times.Once);
            _fileWrapper.Verify(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFprobeFileName}"), Times.Once);
            _fileWrapper.Verify(x => x.Exists($"{rootPath}\\{ChakramSettingsInfo.FFplayFileName}"), Times.Once);
            _fileWrapper.VerifyNoOtherCalls();

            _chakramSettingsSingleton.Verify(x => x.ChakramSettings, Times.Exactly(4));
            _chakramSettingsSingleton.VerifyNoOtherCalls();

            #endregion
        }

        [TestMethod]
        public void FFmpegNotInitializedTest()
        {
            #region Arrange

            ChakramSettingsInfo chakramSettingsInfo = new ChakramSettingsInfo();
            _chakramSettingsSingleton.Setup(x => x.ChakramSettings).Returns(chakramSettingsInfo);

            #endregion

            #region Act

            bool isValid = _fFmpegSettingsValidator.HasValidSettings();

            #endregion

            #region Assert

            Assert.IsFalse(isValid);

            _fileWrapper.VerifyNoOtherCalls();

            _chakramSettingsSingleton.Verify(x => x.ChakramSettings, Times.Once);
            _chakramSettingsSingleton.VerifyNoOtherCalls();

            #endregion
        } 

        #endregion
    }
}
