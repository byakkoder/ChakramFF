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

using Entities.FFmpegArgs;
using Interfaces.FFmpegWrapperCore.FFmpegArguments;
using System;
using System.Text;

namespace FFmpegWrapperCore.FFmpegArguments
{
    public class InputArgGenerator : ISingleArgGenerator<InputArg>
    {
        #region Fields
        
        private readonly ISingleArgGenerator<DelayArg> _delayArgumentBuilder;

        #endregion

        #region Constructor
        
        public InputArgGenerator(ISingleArgGenerator<DelayArg> delayArgumentBuilder)
        {
            _delayArgumentBuilder = delayArgumentBuilder;
        }

        #endregion

        #region Public Methods
        
        public string Generate(InputArg sourceArg)
        {
            if (sourceArg == null)
            {
                throw new ArgumentException("The argument object is mandatory.");
            }

            if (string.IsNullOrWhiteSpace(sourceArg.Input))
            {
                throw new ArgumentException("Input file is mandatory.");
            }

            StringBuilder inputBuilder = new StringBuilder();

            if (sourceArg.DelayArg != null && sourceArg.DelayArg.Delay != 0)
            {
                inputBuilder.Append($"{_delayArgumentBuilder.Generate(sourceArg.DelayArg)} ");
            }

            inputBuilder.Append(string.Format(FFmpegArgsResources.InputFile, sourceArg.Input));

            return inputBuilder.ToString();
        } 

        #endregion
    }
}
