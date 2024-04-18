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

using Byakkoder.ChakramFF.FFmpegWrapperCore.CommandExecution;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.CommandExecution;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.DotNetWrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Test.CommandExecution
{
    [TestClass]
    public class CommandBasicRunnerTest
    {
        #region Fields
        
        private ICommandBasicRunner _commandBasicRunner = default!;
        private Mock<IProcessWrapper> _process = default!;
        private Mock<IBasicStartInfoBuilder> _startInfoBuilder = default!;
        private Mock<ICommandRunnerValidator> _commandRunnerValidator = default!; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _process = new Mock<IProcessWrapper>();
            _commandRunnerValidator = new Mock<ICommandRunnerValidator>();
            _startInfoBuilder = new Mock<IBasicStartInfoBuilder>();

            _commandBasicRunner = new CommandBasicRunner(_process.Object, _startInfoBuilder.Object, _commandRunnerValidator.Object);
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void RunTest()
        {
            #region Arrange

            string exePath = @"C:\exefile.exe";
            string arguments = " -p processArgument";

            _process.Setup(x => x.HasExited).Returns(true);

            #endregion

            #region Act

            _commandBasicRunner.Run(exePath, arguments);

            #endregion

            #region Assert

            _commandRunnerValidator.Verify(x => x.Validate(exePath), Times.Once);
            _startInfoBuilder.Verify(x => x.Build(exePath, arguments), Times.Once);
            _process.Verify(x => x.Start(), Times.Once);
            _process.Verify(x => x.Kill(), Times.Never);
            _process.Verify(x => x.BeginOutputReadLine(), Times.Never);
            _process.Verify(x => x.BeginErrorReadLine(), Times.Never);
            _process.Verify(x => x.WaitForExit(), Times.Never);

            #endregion
        } 

        #endregion
    }
}
