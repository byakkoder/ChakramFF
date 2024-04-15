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
using Byakkoder.ChakramFF.Entities.FFmpegArgs;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.FFmpegArguments;
using System;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.FFmpegArguments
{
    public class StreamSpecifierArgGenerator : ISingleArgGenerator<StreamSpecifierArg>
    {
        #region Public Methods
        
        public string Generate(StreamSpecifierArg sourceArg)
        {
            if (sourceArg == null)
            {
                return string.Empty;
            }

            switch (sourceArg.StreamType)
            {
                case StreamType.Audio:

                    return string.Format(FFmpegArgsResources.AudioStreamSpecifier, sourceArg.StreamIndex);
                case StreamType.Video:

                    return string.Format(FFmpegArgsResources.VideoStreamSpecifier, sourceArg.StreamIndex);
                case StreamType.Subtitle:

                    return string.Format(FFmpegArgsResources.SubtitleStreamSpecifier, sourceArg.StreamIndex);
                default:

                    throw new ArgumentException("Unknown stream type");
            }
        } 

        #endregion
    }
}
