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
using Interfaces.FFmpegWrapperCore.FFmpegResponse;
using System;
using System.Collections.Generic;

namespace FFmpegWrapperCore.FFmpegResponse
{
    public class FFmpegResponseMapper : IFFmpegResponseMapper
    {
        #region Constants
        
        public const string Bitrate = "bitrate";
        public const string Fps = "fps";
        public const string Frame = "frame";
        public const string Q = "q";
        public const string Size = "size";
        public const string Speed = "speed";
        public const string Time = "time"; 

        #endregion

        #region Public Methods

        public FFmpegResponseInfo Map(Dictionary<string, string> propertiesDict)
        {
            if(!propertiesDict.ContainsKey(Bitrate) ||
                !propertiesDict.ContainsKey(Fps) ||
                !propertiesDict.ContainsKey(Frame) ||
                !propertiesDict.ContainsKey(Q) ||
                !propertiesDict.ContainsKey(Size) ||
                !propertiesDict.ContainsKey(Speed) ||
                !propertiesDict.ContainsKey(Time))
            {
                throw new ArgumentException("The dictionary has not mandatory values.");
            }

            return new FFmpegResponseInfo
            {
                Bitrate = propertiesDict[Bitrate],
                Fps = Convert.ToSingle(propertiesDict[Fps]),
                Frame = Convert.ToInt64(propertiesDict[Frame]),
                Q = Convert.ToSingle(propertiesDict[Q]),
                Size = propertiesDict[Size],
                Speed = propertiesDict[Speed],
                Time = propertiesDict[Time]
            };
        }

        #endregion
    }
}
