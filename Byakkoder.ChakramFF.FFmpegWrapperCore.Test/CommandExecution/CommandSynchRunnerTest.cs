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

using System.IO;
using System.Text;
using Byakkoder.ChakramFF.FFmpegWrapperCore.CommandExecution;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.CommandExecution;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.DotNetWrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Test.CommandExecution
{
    [TestClass]
    public class CommandSynchRunnerTest
    {
        #region Fields
        
        private ICommandSynchRunner _commandSyncRunner = default!;
        private Mock<IProcessWrapper> _process = default!;
        private Mock<IStartInfoBuilder> _startInfoBuilder = default!;
        private Mock<ICommandRunnerValidator> _commandRunnerValidator = default!; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _process = new Mock<IProcessWrapper>();            
            _startInfoBuilder = new Mock<IStartInfoBuilder>();
            _commandRunnerValidator = new Mock<ICommandRunnerValidator>();

            _commandSyncRunner = new CommandSynchRunner(_process.Object, _startInfoBuilder.Object, _commandRunnerValidator.Object);
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void RunTest()
        {
            #region Arrange

            string exePath = @"C:\exefile.exe";
            string arguments = " -p processArgument";

            string expectedString = "test";
            MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(expectedString));
            MemoryStream errorMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes("errorTest"));
            StreamReader streamReader = new StreamReader(memoryStream);
            StreamReader errorStreamReader = new StreamReader(errorMemoryStream);

            _process.Setup(x => x.StandardOutput).Returns(streamReader);
            _process.Setup(x => x.StandardError).Returns(errorStreamReader);

            #endregion

            #region Act

            string response = _commandSyncRunner.Run(exePath, arguments);

            #endregion

            #region Assert

            Assert.AreEqual(expectedString, response);
            _commandRunnerValidator.Verify(x => x.Validate(exePath), Times.Once);
            _startInfoBuilder.Verify(x => x.Build(exePath, arguments), Times.Once);
            _process.Verify(x => x.Start(), Times.Once);
            _process.Verify(x => x.BeginOutputReadLine(), Times.Never);
            _process.Verify(x => x.BeginErrorReadLine(), Times.Never);
            _process.Verify(x => x.WaitForExit(), Times.Once);

            #endregion
        } 

        #endregion
    }
}
