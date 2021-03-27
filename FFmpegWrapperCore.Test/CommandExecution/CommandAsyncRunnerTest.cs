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

using FFmpegWrapperCore.CommandExecution;
using FFmpegWrapperCore.Test.TestHelpers;
using Interfaces.FFmpegWrapperCore.CommandExecution;
using Interfaces.FFmpegWrapperCore.DotNetWrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace FFmpegWrapperCore.Test.CommandExecution
{
    [TestClass]
    public class CommandAsyncRunnerTest
    {
        #region Fields
        
        private ICommandAsyncRunner _commandAsyncRunner;
        private Mock<IProcessWrapper> _process;
        private Mock<IStartInfoBuilder> _startInfoBuilder;
        private Mock<ICommandRunnerValidator> _commandRunnerValidator; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _process = new Mock<IProcessWrapper>();
            _commandRunnerValidator = new Mock<ICommandRunnerValidator>();
            _startInfoBuilder = new Mock<IStartInfoBuilder>();

            _commandAsyncRunner = new CommandAsyncRunner(_process.Object, _startInfoBuilder.Object, _commandRunnerValidator.Object);
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void RunTest()
        {
            #region Arrange

            string exePath = @"C:\exefile.exe";
            string arguments = " -p processArgument";

            #endregion

            #region Act

            _commandAsyncRunner.Run(exePath, arguments);

            #endregion

            #region Assert

            _commandRunnerValidator.Verify(x => x.Validate(exePath), Times.Once);
            _startInfoBuilder.Verify(x => x.Build(exePath, arguments), Times.Once);
            _process.Verify(x => x.InitializeProcess(), Times.Once);
            _process.Verify(x => x.Start(), Times.Once);
            _process.Verify(x => x.BeginOutputReadLine(), Times.Once);
            _process.Verify(x => x.BeginErrorReadLine(), Times.Once);
            _process.Verify(x => x.WaitForExit(), Times.Once);

            #endregion
        }

        [TestMethod]
        public void RunOnDataReceivedTest()
        {
            #region Arrange

            string currentOutput = string.Empty;
            string expectedOutput = "some_command_response";

            DataReceivedEventArgs mockEventArgs = MockHelper.GetMockInstance<DataReceivedEventArgs>();
            Dictionary<string, FieldInfo> fields = MockHelper.GetFieldsInfo<DataReceivedEventArgs>();
            MockHelper.SetFieldValue(mockEventArgs, fields["_data"], expectedOutput);

            #endregion

            #region Act

            _commandAsyncRunner.OnDataReceived += (data) => { currentOutput = data; };

            _process.Raise(x => x.OutputDataReceived += null, new object[] { null, mockEventArgs });

            #endregion

            #region Assert

            Assert.AreEqual(expectedOutput, currentOutput);

            #endregion
        }

        [TestMethod]
        public void RunOnErrorReceivedTest()
        {
            #region Arrange

            string currentOutput = string.Empty;
            string expectedOutput = "some_command_response";

            DataReceivedEventArgs mockEventArgs = MockHelper.GetMockInstance<DataReceivedEventArgs>();
            Dictionary<string, FieldInfo> fields = MockHelper.GetFieldsInfo<DataReceivedEventArgs>();
            MockHelper.SetFieldValue(mockEventArgs, fields["_data"], expectedOutput);

            #endregion

            #region Act

            _commandAsyncRunner.OnErrorReceived += (data) => { currentOutput = data; };

            _process.Raise(x => x.ErrorDataReceived += null, new object[] { null, mockEventArgs });

            #endregion

            #region Assert

            Assert.AreEqual(expectedOutput, currentOutput);

            #endregion
        } 

        #endregion
    }
}
