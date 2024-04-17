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
using System.Collections.Generic;
using Byakkoder.ChakramFF.Entities.MediaFileInfo;
using Byakkoder.ChakramFF.FFmpegWrapperCore.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Test.Helpers
{
    [TestClass]
    public class StreamIndexerTest
    {
        #region Fields
        
        private StreamIndexer _streamIndexer; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _streamIndexer = new StreamIndexer();
        }

        #endregion

        #region Test Methods
        
        [TestMethod]
        public void SetIndexTest()
        {
            #region Arrange

            List<MediaStream> streams = new List<MediaStream>()
            {
                new MediaStream{ CodecType = "Video" },
                new MediaStream{ CodecType = "Video" },
                new MediaStream{ CodecType = "Video" },
                new MediaStream{ CodecType = "Audio" },
                new MediaStream{ CodecType = "Audio" },
                new MediaStream{ CodecType = "Subtitle" },
                new MediaStream{ CodecType = "Subtitle" }
            };

            #endregion

            #region Act

            _streamIndexer.SetIndex(streams);

            #endregion

            #region Assert

            Assert.AreEqual(0, streams[0].IndexByType);
            Assert.AreEqual(1, streams[1].IndexByType);
            Assert.AreEqual(2, streams[2].IndexByType);
            Assert.AreEqual(0, streams[3].IndexByType);
            Assert.AreEqual(1, streams[4].IndexByType);
            Assert.AreEqual(0, streams[5].IndexByType);
            Assert.AreEqual(1, streams[6].IndexByType);

            #endregion
        }

        [TestMethod]
        public void NoneStreamTest()
        {
            #region Arrange

            List<MediaStream> streams = new List<MediaStream>()
            {
                new MediaStream{ CodecType = "None" }
            };

            #endregion

            #region Act and Assert

            Assert.ThrowsException<ArgumentException>(() => _streamIndexer.SetIndex(streams));

            #endregion
        }

        [TestMethod]
        public void UnknownStreamTest()
        {
            #region Arrange

            List<MediaStream> streams = new List<MediaStream>()
            {
                new MediaStream{ CodecType = "Unknown" }
            };

            #endregion

            #region Act and Assert

            Assert.ThrowsException<ArgumentException>(() => _streamIndexer.SetIndex(streams));

            #endregion
        }

        #endregion
    }
}
