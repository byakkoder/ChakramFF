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
using System.IO;
using Byakkoder.ChakramFF.FFmpegWrapperCore.CommandExecution;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.CommandExecution;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.DotNetWrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Test.CommandExecution
{
    [TestClass]
    public class StartInfoValidatorTest
    {
        #region Fields

        private IStartInfoValidator _startInfoValidator = default!;
        private Mock<IFileWrapper> _fileWrapper = default!;

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _fileWrapper = new Mock<IFileWrapper>();

            _startInfoValidator = new StartInfoValidator(_fileWrapper.Object);
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void InvalidExePathTest()
        {
            #region Arrange

            string exePath = string.Empty;
            string arguments = @" -args";

            #endregion

            #region Act and Assert

            Assert.ThrowsException<ArgumentException>(() => _startInfoValidator.Validate(exePath, arguments));

            #endregion
        }

        [TestMethod]
        public void InvalidArgumentTest()
        {
            #region Arrange

            string exePath = @"C:\\exeFile.exe";
            string arguments = string.Empty;

            #endregion

            #region Act and Assert

            Assert.ThrowsException<ArgumentException>(() => _startInfoValidator.Validate(exePath, arguments));

            #endregion
        }

        [TestMethod]
        public void FileNotFoundTest()
        {
            #region Arrange

            string exePath = @"C:\\exeFile.exe";
            string arguments = @" -args";

            _fileWrapper.Setup(x => x.Exists(exePath)).Returns(false);

            #endregion

            #region Act and Assert

            Assert.ThrowsException<FileNotFoundException>(() => _startInfoValidator.Validate(exePath, arguments));

            #endregion
        }

        #endregion
    }
}
