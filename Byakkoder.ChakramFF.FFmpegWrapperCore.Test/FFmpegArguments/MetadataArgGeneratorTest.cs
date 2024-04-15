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
using Moq;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Test.FFmpegArguments
{
    [TestClass]
    public class MetadataArgGeneratorTest
    {
        #region Fields
        
        private ISingleArgGenerator<MetadataArg> _metadataArgBuilder;
        private Mock<ISingleArgGenerator<StreamTypeArg>> _streamTypeArgGenerator;

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _streamTypeArgGenerator = new Mock<ISingleArgGenerator<StreamTypeArg>>();

            _metadataArgBuilder = new MetadataArgGenerator(_streamTypeArgGenerator.Object);
        }

        #endregion

        #region Test Methods
        
        [TestMethod]
        public void BuildTest()
        {
            MetadataArg metadataArg = new MetadataArg
            {
                StreamTypeArg = new StreamTypeArg { StreamType = StreamType.Video },
                StreamIndex = 0,
                Metadata = Metadata.Title,
                Value = "Powerfull Data"
            };

            _streamTypeArgGenerator.Setup(x => x.Generate(metadataArg.StreamTypeArg)).Returns("v");

            string argument = _metadataArgBuilder.Generate(metadataArg);

            Assert.AreEqual("-metadata:s:v:0 title=\"Powerfull Data\"", argument);
        }

        [TestMethod]
        public void InvalidStreamIndexTest()
        {
            MetadataArg metadataArg = new MetadataArg
            {
                StreamIndex = -1,
            };

            Assert.ThrowsException<ArgumentException>(() => _metadataArgBuilder.Generate(metadataArg));
        }

        [TestMethod]
        public void InvalidMetadataTagTest()
        {
            MetadataArg metadataArg = new MetadataArg
            {
                Metadata = (Metadata)(-2),
            };

            Assert.ThrowsException<ArgumentException>(() => _metadataArgBuilder.Generate(metadataArg));
        }

        #endregion
    }
}
