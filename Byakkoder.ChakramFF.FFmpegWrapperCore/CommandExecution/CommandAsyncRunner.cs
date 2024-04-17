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

using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.CommandExecution;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.DotNetWrappers;
using System;
using System.Diagnostics;
using System.IO;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.CommandExecution
{
    public class CommandAsyncRunner : ICommandAsyncRunner
    {
        #region Events

        public event Action<string> OnDataReceived;
        public event Action<string> OnErrorReceived;

        #endregion

        #region Fields

        private readonly IProcessWrapper _process;
        private readonly IStartInfoBuilder _startInfoBuilder;
        private readonly ICommandRunnerValidator _commandRunnerValidator;

        #endregion

        #region Constructor

        public CommandAsyncRunner(
            IProcessWrapper process,
            IStartInfoBuilder startInfoBuilder,
            ICommandRunnerValidator commandRunnerValidator)
        {
            _process = process;
            _startInfoBuilder = startInfoBuilder;
            _commandRunnerValidator = commandRunnerValidator;

            _process.OutputDataReceived += Process_OutputDataReceived;
            _process.ErrorDataReceived += Process_ErrorDataReceived;
        }

        #endregion

        #region Public Methods

        public void Run(string exePath, string arguments)
        {
            _commandRunnerValidator.Validate(exePath);

            _process.InitializeProcess();

            _process.StartInfo = _startInfoBuilder.Build(exePath, arguments);

            _process.Start();
            _process.BeginOutputReadLine();
            _process.BeginErrorReadLine();
            _process.WaitForExit();
        }

        public void Stop()
        {
            if (_process == null)
            {
                return;
            }

            _process.Kill();
        }

        public void Stop(string stopCommand)
        {
            if (_process == null)
            {
                return;
            }

            using (StreamWriter sr = _process.StandardInput)
            {
                sr.WriteLine(stopCommand);
                sr.Close();
            }
        }

        #endregion

        #region Private Methods

        // FFmpeg uses stdout to pipe out binary data (Multimedia, Snapshoots) and stderr for logging.
        // Use this event for get each line of process log.
        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.Data))
            {
                OnErrorReceived?.Invoke(e.Data);
            }
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.Data))
            {
                OnDataReceived?.Invoke(e.Data);
            }
        }

        #endregion
    }
}
