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
using Entities;
using Entities.FFmpegArgs;
using Entities.MediaFileInfo;
using FFmpegWrapperCore.Helpers;
using Interfaces.FFmpegWrapperCore;
using Interfaces.FFmpegWrapperCore.ChakramSettings;
using Interfaces.FFmpegWrapperCore.CommandExecution;
using Interfaces.FFmpegWrapperCore.DotNetWrappers;
using Interfaces.FFmpegWrapperCore.FFmpegArguments;
using Interfaces.FFmpegWrapperCore.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FFmpegWrapperCore.Test
{
    [TestClass]
    public class VideoInfoHelperTest
    {
        #region Fields

        private IVideoInfoHelper _videoInfoHelper;
        private Mock<IChakramSettingsSingleton> _chakramSettingsSingleton;
        private Mock<ISingleArgGenerator<FileInfoArg>> _fileInfoArgGenerator;
        private Mock<ICommandSynchRunner> _commandRunner;
        private Mock<ISerializationWrapper> _serializationWrapper;
        private Mock<IStreamIndexer> _streamIndexer;

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _chakramSettingsSingleton = new Mock<IChakramSettingsSingleton>();
            _fileInfoArgGenerator = new Mock<ISingleArgGenerator<FileInfoArg>>();
            _commandRunner = new Mock<ICommandSynchRunner>();
            _serializationWrapper = new Mock<ISerializationWrapper>();
            _streamIndexer = new Mock<IStreamIndexer>();

            _videoInfoHelper = new VideoInfoHelper(
                _chakramSettingsSingleton.Object,
                _fileInfoArgGenerator.Object,
                _commandRunner.Object,
                _serializationWrapper.Object,
                _streamIndexer.Object);
        }

        #endregion

        #region Test Methods
        
        [TestMethod]
        public void GetVideoInfoTest()
        {
            #region Arrange

            string fileMetadata = "{ metadata }";
            FileInfoArg fileInfoArg = new FileInfoArg { FilePath = @"C:\Video\Video.mp4" };
            string argument = " -getVideoInfo";
            MediaInfo expectedMediaInfo = new MediaInfo();
            ChakramSettingsInfo chakramSettingsInfo = new ChakramSettingsInfo() { FFmpegRootPath = @"C:\FFmpeg\" };

            _fileInfoArgGenerator.Setup(x => x.Generate(fileInfoArg)).Returns(argument);
            _chakramSettingsSingleton.Setup(x => x.ChakramSettings).Returns(chakramSettingsInfo);
            _commandRunner.Setup(x => x.Run(chakramSettingsInfo.FFprobePath, argument, false)).Returns(fileMetadata);
            _serializationWrapper.Setup(x => x.Deserialize<MediaInfo>(fileMetadata)).Returns(expectedMediaInfo);

            #endregion

            #region Act

            MediaInfo mediaInfo = _videoInfoHelper.GetVideoInfo(fileInfoArg);

            #endregion

            #region Assert

            Assert.AreSame(expectedMediaInfo, mediaInfo);

            _fileInfoArgGenerator.Verify(x => x.Generate(fileInfoArg), Times.Once);
            _fileInfoArgGenerator.VerifyNoOtherCalls();
            _chakramSettingsSingleton.Verify(x => x.ChakramSettings, Times.Once);
            _chakramSettingsSingleton.VerifyNoOtherCalls();
            _commandRunner.Verify(x => x.Run(chakramSettingsInfo.FFprobePath, argument, false), Times.Once);
            _commandRunner.VerifyNoOtherCalls();
            _serializationWrapper.Verify(x => x.Deserialize<MediaInfo>(fileMetadata), Times.Once);
            _serializationWrapper.VerifyNoOtherCalls();

            #endregion
        }

        [TestMethod]
        public void InvalidFilePathTest()
        {
            #region Arrange

            FileInfoArg fileInfoArg = new FileInfoArg { FilePath = string.Empty };

            #endregion

            #region Act and Assert

            Assert.ThrowsException<ArgumentException>(() => _videoInfoHelper.GetVideoInfo(fileInfoArg));

            #endregion
        } 

        #endregion
    }
}
