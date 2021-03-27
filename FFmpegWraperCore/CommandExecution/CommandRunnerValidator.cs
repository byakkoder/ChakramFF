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
using System;
using System.IO;

namespace FFmpegWrapperCore.CommandExecution
{
    public class CommandRunnerValidator : ICommandRunnerValidator
    {
        #region Fields

        private readonly IFileWrapper _fileWrapper;

        #endregion

        #region Constructor

        public CommandRunnerValidator(IFileWrapper fileWrapper)
        {
            _fileWrapper = fileWrapper;
        }

        #endregion

        #region Public Methods

        public void Validate(string exePath)
        {
            if (string.IsNullOrWhiteSpace(exePath))
            {
                throw new ArgumentException("ExePath to run commands missing.");
            }

            if (!_fileWrapper.Exists(exePath))
            {
                throw new FileNotFoundException("The executable file doesn't exists.");
            }
        }

        #endregion
    }
}
