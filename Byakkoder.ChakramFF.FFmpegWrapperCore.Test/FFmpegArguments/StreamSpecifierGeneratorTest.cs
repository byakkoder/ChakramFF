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
using Byakkoder.ChakramFF.Entities.FFmpegArgs;
using Byakkoder.ChakramFF.FFmpegWrapperCore.FFmpegArguments;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.FFmpegArguments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Test.FFmpegArguments
{
    [TestClass]
    public class StreamSpecifierGeneratorTest
    {
        #region Fields
        
        private ISingleArgGenerator<StreamSpecifierArg> _streamSpecifierArgGenerator; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _streamSpecifierArgGenerator = new StreamSpecifierArgGenerator();
        }

        #endregion

        #region Test Methods
        
        [TestMethod]
        public void BuildAudioTest()
        {
            StreamSpecifierArg streamSpecifierArg = new StreamSpecifierArg
            {
                StreamType = StreamType.Audio,
                StreamIndex = 2
            };

            string audioArgSpecifier = _streamSpecifierArgGenerator.Generate(streamSpecifierArg);

            Assert.AreEqual(" -ast 2", audioArgSpecifier);
        }

        [TestMethod]
        public void BuildVideoTest()
        {
            StreamSpecifierArg streamSpecifierArg = new StreamSpecifierArg
            {
                StreamType = StreamType.Video,
                StreamIndex = 1
            };

            string audioArgSpecifier = _streamSpecifierArgGenerator.Generate(streamSpecifierArg);

            Assert.AreEqual(" -vst 1", audioArgSpecifier);
        }

        [TestMethod]
        public void BuildSubtitleTest()
        {
            StreamSpecifierArg streamSpecifierArg = new StreamSpecifierArg
            {
                StreamType = StreamType.Subtitle,
                StreamIndex = 2
            };

            string audioArgSpecifier = _streamSpecifierArgGenerator.Generate(streamSpecifierArg);

            Assert.AreEqual(" -sst 2", audioArgSpecifier);
        }

        [TestMethod]
        public void UnknownStreamTest()
        {
            StreamSpecifierArg streamSpecifierArg = new StreamSpecifierArg
            {
                StreamType = StreamType.None,
                StreamIndex = 2
            };

            Assert.ThrowsException<ArgumentException>(() => _streamSpecifierArgGenerator.Generate(streamSpecifierArg));
        } 

        #endregion
    }
}
