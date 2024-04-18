﻿/*********************************************************************************
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
using Byakkoder.ChakramFF.Entities.FFmpegArgs;
using Byakkoder.ChakramFF.FFmpegWrapperCore.FFmpegArguments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Test.FFmpegArguments
{
    [TestClass]
    public class StreamTypeArgGeneratorTest
    {
        #region Fields
        
        private StreamTypeArgGenerator _streamTypeArgGenerator = default!; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _streamTypeArgGenerator = new StreamTypeArgGenerator();
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void VideoStreamTypeTest()
        {
            #region Arrange

            StreamTypeArg streamTypeArg = new StreamTypeArg { StreamType = StreamType.Video };

            #endregion

            #region Act

            string type = _streamTypeArgGenerator.Generate(streamTypeArg);

            #endregion

            #region Assert

            Assert.AreEqual("v", type);

            #endregion
        }

        [TestMethod]
        public void AudioStreamTypeTest()
        {
            #region Arrange

            StreamTypeArg streamTypeArg = new StreamTypeArg { StreamType = StreamType.Audio };

            #endregion

            #region Act

            string type = _streamTypeArgGenerator.Generate(streamTypeArg);

            #endregion

            #region Assert
            
            Assert.AreEqual("a", type); 

            #endregion
        }

        [TestMethod]
        public void SubtitleStreamTypeTest()
        {
            #region Arrange

            StreamTypeArg streamTypeArg = new StreamTypeArg { StreamType = StreamType.Subtitle };

            #endregion

            #region Act

            string type = _streamTypeArgGenerator.Generate(streamTypeArg);

            #endregion

            #region Assert

            Assert.AreEqual("s", type);

            #endregion
        }

        [TestMethod]
        public void UnknownStreamTypeTest()
        {
            #region Arrange

            StreamTypeArg streamTypeArg = new StreamTypeArg { StreamType = (StreamType)(-24) };

            #endregion

            #region Act and Assert

            Assert.ThrowsException<ArgumentException>(() => _streamTypeArgGenerator.Generate(streamTypeArg));

            #endregion
        } 

        #endregion
    }
}
