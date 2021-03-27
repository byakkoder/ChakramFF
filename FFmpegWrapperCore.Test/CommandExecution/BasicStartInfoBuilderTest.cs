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

using System.Diagnostics;
using FFmpegWrapperCore.CommandExecution;
using Interfaces.FFmpegWrapperCore.CommandExecution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FFmpegWrapperCore.Test.CommandExecution
{
    [TestClass]
    public class BasicStartInfoBuilderTest
    {
        #region Fields
        
        private IBasicStartInfoBuilder _startInfoBuilder;
        private Mock<IStartInfoValidator> _startInfoValidator;

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _startInfoValidator = new Mock<IStartInfoValidator>();

            _startInfoBuilder = new BasicStartInfoBuilder(_startInfoValidator.Object);
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void BuildTest()
        {
            #region Arrange

            string exePath = @"C:\\exeFile.exe";
            string arguments = @" -args";

            #endregion

            #region Act

            ProcessStartInfo processStartInfo = _startInfoBuilder.Build(exePath, arguments);

            #endregion

            #region Assert

            _startInfoValidator.Verify(x => x.Validate(exePath, arguments), Times.Once);
            Assert.AreEqual(exePath, processStartInfo.FileName);
            Assert.AreEqual(arguments, processStartInfo.Arguments);
            Assert.AreEqual(false, processStartInfo.UseShellExecute);
            Assert.AreEqual(true, processStartInfo.CreateNoWindow);

            #endregion
        } 

        #endregion
    }
}
