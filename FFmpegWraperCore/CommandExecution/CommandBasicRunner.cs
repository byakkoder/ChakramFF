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

using Interfaces.FFmpegWrapperCore.CommandExecution;
using Interfaces.FFmpegWrapperCore.DotNetWrappers;

namespace FFmpegWrapperCore.CommandExecution
{
    public class CommandBasicRunner : ICommandBasicRunner
    {
        #region Fields
        
        private readonly IProcessWrapper _process;
        private readonly IBasicStartInfoBuilder _startInfoBuilder;
        private readonly ICommandRunnerValidator _commandRunnerValidator;

        #endregion

        #region Constructor

        public CommandBasicRunner(
            IProcessWrapper process,
            IBasicStartInfoBuilder startInfoBuilder,
            ICommandRunnerValidator commandRunnerValidator)
        {
            _process = process;
            _startInfoBuilder = startInfoBuilder;
            _commandRunnerValidator = commandRunnerValidator;

            _process.InitializeProcess();
        }

        #endregion

        #region Public Methods

        public void Run(string exePath, string arguments)
        {
            _commandRunnerValidator.Validate(exePath);

            if (!_process.HasExited)
            {
                _process.Kill();
            }

            _process.StartInfo = _startInfoBuilder.Build(exePath, arguments);
            _process.Start();
        }

        #endregion
    }
}
