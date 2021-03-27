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
using FFmpegWrapperCore.CommandExecution;
using Interfaces.FFmpegWrapperCore.CommandExecution;
using Interfaces.FFmpegWrapperCore.DotNetWrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FFmpegWrapperCore.Test.CommandExecution
{
    [TestClass]
    public class CommandRunnerValidatorTest
    {
        #region Fields

        private ICommandRunnerValidator _commandRunnerValidator;
        private Mock<IFileWrapper> _fileWrapper;

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _fileWrapper = new Mock<IFileWrapper>();

            _commandRunnerValidator = new CommandRunnerValidator(_fileWrapper.Object);
        }

        #endregion

        #region Test Methods
        
        [TestMethod]
        public void NullExePathTest()
        {
            #region Arrange
            
            string exePath = null;

            #endregion

            #region Act and Assert
            
            Assert.ThrowsException<ArgumentException>(() => _commandRunnerValidator.Validate(exePath)); 

            #endregion
        }

        [TestMethod]
        public void FileNotExistsTest()
        {
            #region Arrange
            
            string exePath = @"C:\MyFile.mp4";

            #endregion

            #region Act and Assert
            
            Assert.ThrowsException<FileNotFoundException>(() => _commandRunnerValidator.Validate(exePath)); 

            #endregion
        } 

        #endregion
    }
}
