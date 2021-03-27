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
using Entities.MediaFileInfo;
using FFmpegWrapperCore.MediaInfoQuery;
using Interfaces.FFmpegWrapperCore.MediaInfoQuery;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FFmpegWrapperCore.Test.MediaInfoQuery
{
    [TestClass]
    public class DurationQueryHelperTest
    {
        #region Fields
        
        private IDurationQueryHelper _durationQueryHelper; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _durationQueryHelper = new DurationQueryHelper();
        }

        #endregion

        #region Test Methods
        
        [TestMethod]
        public void GetDotDurationTest()
        {
            #region Arrange
            
            MediaInfo mediaInfo = new MediaInfo()
            {
                Format = new MediaFormat()
                {
                    Duration = "263.686000"
                }
            };

            #endregion

            #region Act
            
            TimeSpan timeSpan = _durationQueryHelper.GetDuration(mediaInfo);

            #endregion

            #region Assert
            
            Assert.AreEqual(0, timeSpan.Days);
            Assert.AreEqual(0, timeSpan.Hours);
            Assert.AreEqual(4, timeSpan.Minutes);
            Assert.AreEqual(23, timeSpan.Seconds);
            Assert.AreEqual(686, timeSpan.Milliseconds); 

            #endregion
        }

        [TestMethod]
        public void GetCommaDurationTest()
        {
            #region Arrange
            
            MediaInfo mediaInfo = new MediaInfo()
            {
                Format = new MediaFormat()
                {
                    Duration = "263,686000"
                }
            };

            #endregion

            #region Act
            
            TimeSpan timeSpan = _durationQueryHelper.GetDuration(mediaInfo);

            #endregion

            #region Assert
            
            Assert.AreEqual(0, timeSpan.Days);
            Assert.AreEqual(0, timeSpan.Hours);
            Assert.AreEqual(4, timeSpan.Minutes);
            Assert.AreEqual(23, timeSpan.Seconds);
            Assert.AreEqual(686, timeSpan.Milliseconds); 

            #endregion
        }

        [TestMethod]
        public void GetEmptyDurationTest()
        {
            #region Arrange
            
            MediaInfo mediaInfo = new MediaInfo()
            {
                Format = new MediaFormat()
            };

            #endregion

            #region Act
            
            TimeSpan timeSpan = _durationQueryHelper.GetDuration(mediaInfo);

            #endregion

            #region Assert
            
            Assert.AreEqual(0, timeSpan.Days);
            Assert.AreEqual(0, timeSpan.Hours);
            Assert.AreEqual(0, timeSpan.Minutes);
            Assert.AreEqual(0, timeSpan.Seconds);
            Assert.AreEqual(0, timeSpan.Milliseconds); 

            #endregion
        }

        [TestMethod]
        public void GetWithEmptyFormatTest()
        {
            #region Arrange
            
            MediaInfo mediaInfo = new MediaInfo();

            #endregion

            #region Act
            
            TimeSpan timeSpan = _durationQueryHelper.GetDuration(mediaInfo);

            #endregion

            #region Assert
            
            Assert.AreEqual(0, timeSpan.Days);
            Assert.AreEqual(0, timeSpan.Hours);
            Assert.AreEqual(0, timeSpan.Minutes);
            Assert.AreEqual(0, timeSpan.Seconds);
            Assert.AreEqual(0, timeSpan.Milliseconds); 

            #endregion
        } 

        #endregion
    }
}
