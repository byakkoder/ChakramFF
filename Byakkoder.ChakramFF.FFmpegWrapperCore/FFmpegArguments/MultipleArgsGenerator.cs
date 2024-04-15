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

using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.FFmpegArguments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.FFmpegArguments
{
    public class MultipleArgsGenerator : IMultipleArgsGenerator
    {
        #region Public Methods

        public string Generate<T>(List<T> args, ISingleArgGenerator<T> singleArgGenerator) where T : class
        {
            if (args == null)
            {
                throw new ArgumentException("Arguments missing.");
            }

            if (singleArgGenerator == null)
            {
                throw new ArgumentException("Delegate method missing.");
            }

            StringBuilder argsBuilder = new StringBuilder();

            foreach (T argEntity in args)
            {
                if (argsBuilder.Length > 0)
                {
                    argsBuilder.Append(FFmpegArgsResources.ArgSeparator);
                }

                argsBuilder.Append(singleArgGenerator.Generate(argEntity));
            }

            return argsBuilder.ToString();
        }

        #endregion
    }
}
