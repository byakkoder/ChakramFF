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
using FFmpegWrapperCore.FFmpegArguments;
using Interfaces.FFmpegWrapperCore.FFmpegArguments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FFmpegWrapperCore.Test.FFmpegArguments
{
    [TestClass]
    public class MapArgGeneratorTest
    {
        #region Fields
        
        private ISingleArgGenerator<MapArg> _mapArgumentBuilder;
        private Mock<ISingleArgGenerator<StreamTypeArg>> _streamTypeArgGenerator;

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _streamTypeArgGenerator = new Mock<ISingleArgGenerator<StreamTypeArg>>();

            _mapArgumentBuilder = new MapArgGenerator(_streamTypeArgGenerator.Object);
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void BuildVideoArgTest()
        {
            #region Arrange
            
            MapArg mapArg = new MapArg
            {
                InputIndex = 0,
                StreamTypeArg = new StreamTypeArg { StreamType = StreamType.Video },
                StreamIndex = 0
            };

            _streamTypeArgGenerator.Setup(x => x.Generate(mapArg.StreamTypeArg)).Returns("v");

            #endregion

            #region Act

            string mapArgument = _mapArgumentBuilder.Generate(mapArg);

            #endregion

            #region Assert
            
            Assert.AreEqual("-map 0:v:0", mapArgument); 

            #endregion
        }

        [TestMethod]
        public void BuildAudioArgTest()
        {
            #region Arrange
            
            MapArg mapArg = new MapArg
            {
                InputIndex = 1,
                StreamTypeArg = new StreamTypeArg { StreamType = StreamType.Audio },
                StreamIndex = 0
            };

            _streamTypeArgGenerator.Setup(x => x.Generate(mapArg.StreamTypeArg)).Returns("a");

            #endregion

            #region Act

            string mapArgument = _mapArgumentBuilder.Generate(mapArg);

            #endregion

            #region Assert
            
            Assert.AreEqual("-map 1:a:0", mapArgument); 

            #endregion
        }

        [TestMethod]
        public void WrongInputIndexTest()
        {
            #region Arrange
            
            MapArg mapArg = new MapArg
            {
                InputIndex = -1,
                StreamTypeArg = new StreamTypeArg { StreamType = StreamType.Video },
                StreamIndex = 0
            };

            #endregion

            #region Act and Assert
            
            Assert.ThrowsException<ArgumentException>(() => _mapArgumentBuilder.Generate(mapArg)); 

            #endregion
        }

        [TestMethod]
        public void WrongStreamIndexTest()
        {
            #region Arrange
            
            MapArg mapArg = new MapArg
            {
                InputIndex = 0,
                StreamTypeArg = new StreamTypeArg { StreamType = StreamType.Video },
                StreamIndex = -1
            };

            #endregion

            #region Act and Assert
            
            Assert.ThrowsException<ArgumentException>(() => _mapArgumentBuilder.Generate(mapArg)); 

            #endregion
        } 

        #endregion
    }
}
