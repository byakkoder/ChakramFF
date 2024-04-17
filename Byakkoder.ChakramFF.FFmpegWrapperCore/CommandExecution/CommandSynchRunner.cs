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
using System.Diagnostics;
using System.IO;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.CommandExecution
{
    public class CommandSynchRunner : ICommandSynchRunner
    {
        #region Fields
        
        private readonly IProcessWrapper _process;
        private readonly IStartInfoBuilder _startInfoBuilder;
        private readonly ICommandRunnerValidator _commandRunnerValidator;

        #endregion

        #region Constructor

        public CommandSynchRunner(
            IProcessWrapper process,
            IStartInfoBuilder startInfoBuilder,
            ICommandRunnerValidator commandRunnerValidator)
        {
            _process = process;
            _startInfoBuilder = startInfoBuilder;
            _commandRunnerValidator = commandRunnerValidator;
        }

        #endregion

        #region Public Methods

        public string Run(string exePath, string arguments, bool readStandardError = true)
        {
            _commandRunnerValidator.Validate(exePath);

            _process.InitializeProcess();
            _process.StartInfo = _startInfoBuilder.Build(exePath, arguments);
            _process.Start();

            // Synchronously read the standard error of the spawned process.
            if (readStandardError)
            {
                StreamReader errorReader = _process.StandardError;
                string error = errorReader.ReadToEnd();
                Debug.WriteLine(error);
            }

            // Synchronously read the standard output of the spawned process. 
            StreamReader reader = _process.StandardOutput;
            string output = reader.ReadToEnd();

            _process.WaitForExit();

            return output;
        }

        #endregion
    }
}
