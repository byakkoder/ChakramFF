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
using System.Diagnostics;

namespace FFmpegWrapperCore.CommandExecution
{
    public class BasicStartInfoBuilder : IBasicStartInfoBuilder
    {
        #region Fields

        private readonly IStartInfoValidator _startInfoValidator;

        #endregion

        #region Constructor

        public BasicStartInfoBuilder(IStartInfoValidator startInfoValidator)
        {
            _startInfoValidator = startInfoValidator;
        }

        #endregion

        #region Public Methods

        public ProcessStartInfo Build(string exePath, string arguments)
        {
            _startInfoValidator.Validate(exePath, arguments);

            return new ProcessStartInfo
            {
                FileName = exePath,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true
            };
        }

        #endregion
    }
}
