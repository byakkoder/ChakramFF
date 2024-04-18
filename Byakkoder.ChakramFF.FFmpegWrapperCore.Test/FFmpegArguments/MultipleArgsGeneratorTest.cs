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
using Byakkoder.ChakramFF.Entities.FFmpegArgs;
using Byakkoder.ChakramFF.FFmpegWrapperCore.FFmpegArguments;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.FFmpegArguments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Test.FFmpegArguments
{
    [TestClass]
    public class MultipleArgsGeneratorTest
    {
        #region Fields
        
        private IMultipleArgsGenerator _multipleArgsBuilder = default!;
        private Mock<ISingleArgGenerator<MetadataArg>> _metadataArgBuilder = default!; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _metadataArgBuilder = new Mock<ISingleArgGenerator<MetadataArg>>();

            _multipleArgsBuilder = new MultipleArgsGenerator();
        }

        #endregion

        #region Test Methods
        
        [TestMethod]
        public void BuildTest()
        {
            List<MetadataArg> metadataArgs = new List<MetadataArg>()
            {
                new MetadataArg(),
                new MetadataArg()
            };

            string expectedVideoArg = "-metadata:s:v:0 title=\"Powerfull Data\"";
            string expectedAudioArg = "-metadata:s:a:0 language=\"eng\"";

            _metadataArgBuilder.Setup(x => x.Generate(metadataArgs[0])).Returns(expectedVideoArg);
            _metadataArgBuilder.Setup(x => x.Generate(metadataArgs[1])).Returns(expectedAudioArg);

            string args = _multipleArgsBuilder.Generate(metadataArgs, _metadataArgBuilder.Object);

            Assert.AreEqual($"{expectedVideoArg} {expectedAudioArg}", args);
        }

        [TestMethod]
        public void NullMetadataArgsTest()
        {
            List<MetadataArg> metadataArgs = null;

            Assert.ThrowsException<ArgumentException>(() =>
                _multipleArgsBuilder.Generate(metadataArgs, _metadataArgBuilder.Object));
        }

        [TestMethod]
        public void NullDelegateTest()
        {
            List<MetadataArg> metadataArgs = new List<MetadataArg>();

            Assert.ThrowsException<ArgumentException>(() =>
                _multipleArgsBuilder.Generate(metadataArgs, null));
        } 

        #endregion
    }
}
