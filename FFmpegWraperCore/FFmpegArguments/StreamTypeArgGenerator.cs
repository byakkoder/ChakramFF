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

using Entities;
using Entities.FFmpegArgs;
using Interfaces.FFmpegWrapperCore.FFmpegArguments;
using System;

namespace FFmpegWrapperCore.FFmpegArguments
{
    public class StreamTypeArgGenerator : ISingleArgGenerator<StreamTypeArg>
    {
        #region Private Constants

        private const string Video = "v";
        private const string Audio = "a";
        private const string Subtitle = "s";

        #endregion

        #region Public Methods

        public string Generate(StreamTypeArg sourceArg)
        {
            string argStreamType;

            switch (sourceArg.StreamType)
            {
                case StreamType.Audio:
                    argStreamType = Audio;

                    break;
                case StreamType.Video:
                    argStreamType = Video;

                    break;
                case StreamType.Subtitle:
                    argStreamType = Subtitle;

                    break;
                default:
                    throw new ArgumentException("Unknown Stream Type.");
            }

            return argStreamType;
        }

        #endregion
    }
}
