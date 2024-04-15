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
using Byakkoder.ChakramFF.Entities.FFmpegArgs;
using Byakkoder.ChakramFF.FFmpegWrapperCore.FFmpegArguments;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.FFmpegArguments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Test.FFmpegArguments
{
    [TestClass]
    public class InputArgGeneratorTest
    {
        #region Fields
        
        private ISingleArgGenerator<InputArg> _singleInputArgBuilder;
        private Mock<ISingleArgGenerator<DelayArg>> _delayArgumentBuilder; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _delayArgumentBuilder = new Mock<ISingleArgGenerator<DelayArg>>();

            _singleInputArgBuilder = new InputArgGenerator(_delayArgumentBuilder.Object);
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void BuildTest()
        {
            DelayArg delayArg = new DelayArg { Delay = 2.4 };

            InputArg inputArg = new InputArg
            {
                Input = @"C:\My Music\Some File.mp3",
                DelayArg = delayArg
            };

            _delayArgumentBuilder.Setup(x => x.Generate(delayArg)).Returns("-itsoffset 2.4");

            string argument = _singleInputArgBuilder.Generate(inputArg);

            Assert.AreEqual("-itsoffset 2.4 -i \"C:\\My Music\\Some File.mp3\"", argument);
        }

        [TestMethod]
        public void BuildWithoutDelayTest()
        {
            DelayArg delayArg = new DelayArg();

            InputArg inputArg = new InputArg
            {
                Input = @"C:\My Music\Some File.mp3",
                DelayArg = delayArg
            };

            string argument = _singleInputArgBuilder.Generate(inputArg);

            Assert.AreEqual("-i \"C:\\My Music\\Some File.mp3\"", argument);
            _delayArgumentBuilder.Verify(x => x.Generate(delayArg), Times.Never);
        }

        [TestMethod]
        public void EmptyInputTest()
        {
            InputArg inputArg = new InputArg();

            Assert.ThrowsException<ArgumentException>(() => _singleInputArgBuilder.Generate(inputArg));
        }

        [TestMethod]
        public void NullArgumentTest()
        {
            InputArg inputArg = null;

            Assert.ThrowsException<ArgumentException>(() => _singleInputArgBuilder.Generate(inputArg));
        } 

        #endregion
    }
}
