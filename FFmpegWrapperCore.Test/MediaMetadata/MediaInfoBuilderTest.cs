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
using System.Drawing;
using System.IO;
using Entities.MediaFileInfo;
using Entities.Dto;
using FFmpegWrapperCore.MediaMetadata;
using Interfaces.FFmpegWrapperCore.Helpers;
using Interfaces.FFmpegWrapperCore.MediaInfoQuery;
using Interfaces.FFmpegWrapperCore.MediaMetadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Entities.FFmpegArgs;

namespace FFmpegWrapperCore.Test.MediaMetadata
{
    [TestClass]
    public class MediaInfoBuilderTest
    {
        #region Fields

        private IMediaInfoBuilder _mediaInfoBuilder;
        private Mock<IVideoInfoHelper> _infoHelper;
        private Mock<ISizeQueryHelper> _sizeQueryHelper;
        private Mock<IDurationQueryHelper> _durationQueryHelper;

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _infoHelper = new Mock<IVideoInfoHelper>();
            _sizeQueryHelper = new Mock<ISizeQueryHelper>();
            _durationQueryHelper = new Mock<IDurationQueryHelper>();

            _mediaInfoBuilder = new MediaInfoBuilder(
                _infoHelper.Object,
                _sizeQueryHelper.Object,
                _durationQueryHelper.Object);
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void BuildMediaInfoTest()
        {
            #region Arrange

            FileInfoArg fileInfoArg = new FileInfoArg { FilePath = @"C:\sourceFile.mp4" };
            string fileName = "sourceFile.mp4";
            MemoryStream stream = new MemoryStream();
            MediaInfo mediaInfo = new MediaInfo();
            Size videoSize = new Size(800, 600);
            TimeSpan videoDuration = new TimeSpan(1, 20, 10);

            _infoHelper.Setup(x => x.GetVideoInfo(fileInfoArg)).Returns(mediaInfo);
            _sizeQueryHelper.Setup(x => x.GetSize(mediaInfo)).Returns(videoSize);
            _durationQueryHelper.Setup(x => x.GetDuration(mediaInfo)).Returns(videoDuration);

            #endregion

            #region Act

            MediaInfoDto mediaInfoDto = _mediaInfoBuilder.BuildMediaInfo(fileInfoArg);

            #endregion

            #region Assert

            Assert.AreEqual(fileInfoArg.FilePath, mediaInfoDto.FullFilename);
            Assert.AreEqual(fileName, mediaInfoDto.Filename);
            Assert.AreEqual(mediaInfo, mediaInfoDto.MediaInfo);
            Assert.AreEqual($"[{videoSize.Width}x{videoSize.Height}]", mediaInfoDto.SizeString);
            Assert.AreEqual($"[{videoDuration.ToString()}]", mediaInfoDto.DurationString);

            #endregion
        }

        [TestMethod]
        public void MissingSourceFileTest()
        {
            #region Arrange

            FileInfoArg fileInfoArg = new FileInfoArg { FilePath = string.Empty };

            #endregion

            #region Act and Assert

            Assert.ThrowsException<ArgumentException>(() => _mediaInfoBuilder.BuildMediaInfo(fileInfoArg));

            #endregion
        }

        #endregion
    }
}
