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

using Byakkoder.ChakramFF.Entities;
using Byakkoder.ChakramFF.Entities.FFmpegArgs;
using Byakkoder.ChakramFF.FFmpegWrapperCore.FFmpegArguments;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.FFmpegArguments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Test.FFmpegArguments
{
    [TestClass]
    public class PlayerArgBuilderTest
    {
        #region Fields
        
        private ISingleArgGenerator<PlayerArgs> _playerArgGenerator;
        private Mock<ISingleArgGenerator<StreamSpecifierArg>> _streamSpecifierGenerator;
        private Mock<ISingleArgGenerator<ShowModeArg>> _showModeArgGenerator;

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _streamSpecifierGenerator = new Mock<ISingleArgGenerator<StreamSpecifierArg>>();
            _showModeArgGenerator = new Mock<ISingleArgGenerator<ShowModeArg>>();

            _playerArgGenerator = new PlayerArgGenerator(_streamSpecifierGenerator.Object, _showModeArgGenerator.Object);
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void BuildTest()
        {
            #region Arrange

            string expectedResult = "-i \"sourceFile.avi\" ";

            PlayerArgs playerArgs = new PlayerArgs
            {
                FileToPlay = "sourceFile.avi"
            };

            #endregion

            #region Act

            string argument = _playerArgGenerator.Generate(playerArgs);

            #endregion

            #region Assert            

            Assert.AreEqual(expectedResult, argument);

            #endregion
        }

        [TestMethod]
        public void BuildNullTest()
        {
            #region Arrange

            PlayerArgs playerArgs = new PlayerArgs();

            #endregion

            #region Act and Assert

            Assert.ThrowsException<ArgumentException>(() => _playerArgGenerator.Generate(playerArgs));

            #endregion
        }

        [TestMethod]
        public void SourceFileMissingTest()
        {
            #region Arrange

            PlayerArgs playerArgs = new PlayerArgs();

            #endregion

            #region Act and Assert

            Assert.ThrowsException<ArgumentException>(() => _playerArgGenerator.Generate(playerArgs));

            #endregion
        }

        #endregion
    }
}
