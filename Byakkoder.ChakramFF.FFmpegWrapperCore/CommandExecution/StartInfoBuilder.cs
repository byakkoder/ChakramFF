﻿/*********************************************************************************
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
using System.Diagnostics;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.CommandExecution
{
    public class StartInfoBuilder : IStartInfoBuilder
    {
        #region Fields
        
        private readonly IBasicStartInfoBuilder _basicStartInfoBuilder;
        private readonly IStartInfoValidator _startInfoValidator;

        #endregion

        #region Constructor

        public StartInfoBuilder(
            IBasicStartInfoBuilder basicStartInfoBuilder,
            IStartInfoValidator startInfoValidator)
        {
            _basicStartInfoBuilder = basicStartInfoBuilder;
            _startInfoValidator = startInfoValidator;
        }

        #endregion

        #region Public Methods

        public ProcessStartInfo Build(string exePath, string arguments)
        {
            _startInfoValidator.Validate(exePath, arguments);

            ProcessStartInfo processStartInfo = _basicStartInfoBuilder.Build(exePath, arguments);
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;

            return processStartInfo;
        } 

        #endregion
    }
}
