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

using System.Collections.Generic;
using System.Drawing;
using Byakkoder.ChakramFF.Entities;
using Byakkoder.ChakramFF.Entities.MediaFileInfo;
using Byakkoder.ChakramFF.FFmpegWrapperCore.MediaInfoQuery;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.MediaInfoQuery;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Test.MediaInfoQuery
{
    [TestClass]
    public class SizeQueryHelperTest
    {
        #region Fields
        
        private ISizeQueryHelper _sizeQueryHelper; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _sizeQueryHelper = new SizeQueryHelper();
        }

        #endregion

        #region Test Methods
        
        [TestMethod]
        public void GetSizeTest()
        {
            #region Arrange

            int expectedWidth = 1500;
            int expectedHeight = 1024;

            MediaInfo mediaInfo = new MediaInfo()
            {
                Streams = new List<MediaStream>
                {
                    new MediaStream() { Width = expectedWidth, Height = expectedHeight }
                }
            };

            #endregion

            #region Act

            Size size = _sizeQueryHelper.GetSize(mediaInfo);

            #endregion

            #region Assert

            Assert.IsNotNull(size);
            Assert.AreEqual(expectedWidth, size.Width);
            Assert.AreEqual(expectedHeight, size.Height);

            #endregion
        }

        [TestMethod]
        public void NullStreamTest()
        {
            #region Arrange
            
            MediaInfo mediaInfo = new MediaInfo();

            #endregion

            #region Act
            
            Size size = _sizeQueryHelper.GetSize(mediaInfo);

            #endregion

            #region Assert
            
            Assert.IsNotNull(size);
            Assert.AreEqual(0, size.Width);
            Assert.AreEqual(0, size.Height); 

            #endregion
        }

        [TestMethod]
        public void EmptyStreamTest()
        {
            #region Arrange

            MediaInfo mediaInfo = new MediaInfo() 
            { 
                Streams = new List<MediaStream>()
            };

            #endregion

            #region Act

            Size size = _sizeQueryHelper.GetSize(mediaInfo);

            #endregion

            #region Assert

            Assert.IsNotNull(size);
            Assert.AreEqual(0, size.Width);
            Assert.AreEqual(0, size.Height);

            #endregion
        }

        [TestMethod]
        public void AvoidWrongStreamTest()
        {
            #region Arrange

            MediaInfo mediaInfo = new MediaInfo()
            {
                Streams = new List<MediaStream>() 
                { 
                    new MediaStream() { Width = 500 }
                }
            };

            #endregion

            #region Act

            Size size = _sizeQueryHelper.GetSize(mediaInfo);

            #endregion

            #region Assert

            Assert.IsNotNull(size);
            Assert.AreEqual(0, size.Width);
            Assert.AreEqual(0, size.Height);

            #endregion
        }

        #endregion
    }
}
