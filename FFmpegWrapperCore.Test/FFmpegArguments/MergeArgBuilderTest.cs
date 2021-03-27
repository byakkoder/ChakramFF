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
using Entities;
using Entities.FFmpegArgs;
using FFmpegWrapperCore.FFmpegArguments;
using Interfaces.FFmpegWrapperCore.FFmpegArguments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FFmpegWrapperCore.Test.FFmpegArguments
{
    [TestClass]
    public class MergeArgBuilderTest
    {
        #region Fields

        private ISingleArgGenerator<MergeArgs> _mergeArgGenerator;

        private Mock<IMultipleArgsGenerator> _multipleArgsGenerator;
        private Mock<ISingleArgGenerator<InputArg>> _inputArgGenerator;
        private Mock<ISingleArgGenerator<MapArg>> _mapArgGenerator;
        private Mock<ISingleArgGenerator<DefaultArg>> _defaultArgGenerator;
        private Mock<ISingleArgGenerator<MetadataArg>> _metadataArgGenerator;

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _multipleArgsGenerator = new Mock<IMultipleArgsGenerator>();
            _inputArgGenerator = new Mock<ISingleArgGenerator<InputArg>>();
            _mapArgGenerator = new Mock<ISingleArgGenerator<MapArg>>();
            _defaultArgGenerator = new Mock<ISingleArgGenerator<DefaultArg>>();
            _metadataArgGenerator = new Mock<ISingleArgGenerator<MetadataArg>>();

            _mergeArgGenerator = new MergeArgGenerator(
                _multipleArgsGenerator.Object,
                _inputArgGenerator.Object,
                _mapArgGenerator.Object,
                _defaultArgGenerator.Object,
                _metadataArgGenerator.Object
            );
        }

        #endregion

        #region Test Methods
        
        [TestMethod]
        public void BuildTest()
        {
            #region Arrange

            string expectedInputs = "inputArgs";
            string expectedMaps = "mapArgs";
            string expectedDefaults = "defaultArgs";
            string expectedMetadata = "metadataArgs";

            MergeArgs mergeInfo = new MergeArgs
            {
                OutputFile = "output.mkv",
                InputArgs = new List<InputArg>() { new InputArg(), new InputArg() }
            };

            _multipleArgsGenerator.Setup(x => x.Generate(mergeInfo.InputArgs, _inputArgGenerator.Object)).Returns(expectedInputs);
            _multipleArgsGenerator.Setup(x => x.Generate(mergeInfo.MapArgs, _mapArgGenerator.Object)).Returns(expectedMaps);
            _multipleArgsGenerator.Setup(x => x.Generate(mergeInfo.DefaultArgs, _defaultArgGenerator.Object)).Returns(expectedDefaults);
            _multipleArgsGenerator.Setup(x => x.Generate(mergeInfo.MetadataArgs, _metadataArgGenerator.Object)).Returns(expectedMetadata);

            #endregion

            #region Act

            string mergeArgument = _mergeArgGenerator.Generate(mergeInfo);

            #endregion

            #region Assert

            Assert.AreEqual($"{expectedInputs} {expectedMaps} {expectedDefaults} {expectedMetadata} -c copy \"{mergeInfo.OutputFile}\"", mergeArgument);

            #endregion
        }

        [TestMethod]
        public void EmptyInputTest()
        {
            #region Arrange

            MergeArgs mergeInfo = new MergeArgs
            {
                OutputFile = "output.mkv"
            };

            #endregion

            #region Act and Assert

            Assert.ThrowsException<ArgumentException>(() => _mergeArgGenerator.Generate(mergeInfo));

            #endregion
        }

        [TestMethod]
        public void NullMergeInfoTest()
        {
            #region Arrange

            MergeArgs mergeInfo = null;

            #endregion

            #region Act and Assert

            Assert.ThrowsException<ArgumentException>(() => _mergeArgGenerator.Generate(mergeInfo));

            #endregion
        } 

        #endregion
    }
}
