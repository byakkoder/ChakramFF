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

using Byakkoder.ChakramFF.Entities;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.FFmpegResponse;
using System.Collections.Generic;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.FFmpegResponse
{
    public class FFmpegResponseBuilder : IFFmpegResponseBuilder
    {
        #region Constants

        private const string ValidLineStartLegacy = "frame="; // Old FFmpeg versions output
        private const string ValidLineStartCurrent = "size="; // Current FFmpeg versions output

        #endregion

        #region Fields

        private readonly IPropertiesDictBuilder _propertiesDictBuilder;
        private readonly IFFmpegResponseMapper _fFmpegResponseMapper;

        #endregion

        #region Constructor
        
        public FFmpegResponseBuilder(
            IPropertiesDictBuilder propertiesDictBuilder,
            IFFmpegResponseMapper fFmpegResponseMapper)
        {
            _propertiesDictBuilder = propertiesDictBuilder;
            _fFmpegResponseMapper = fFmpegResponseMapper;
        } 

        #endregion

        #region Public Methods

        public FFmpegResponseInfo? Build(string ffmpegOutputLine)
        {
            if (!ffmpegOutputLine.StartsWith(ValidLineStartCurrent) && !ffmpegOutputLine.StartsWith(ValidLineStartLegacy))
            {
                return null;
            }

            Dictionary<string, string> propertiesDict = _propertiesDictBuilder.Build(ffmpegOutputLine);

            return _fFmpegResponseMapper.Map(propertiesDict);
        }

        #endregion
    }
}
