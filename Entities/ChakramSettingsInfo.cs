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

using Newtonsoft.Json;
using System.IO;

namespace Entities
{
    public class ChakramSettingsInfo
    {
        #region Constants

        public const string FFmpegFileName = "ffmpeg.exe";
        public const string FFprobeFileName = "ffprobe.exe";
        public const string FFplayFileName = "ffplay.exe";

        #endregion

        #region Public Properties
        
        [JsonProperty]
        public string FFmpegRootPath { get; set; }

        [JsonIgnore]
        public string FFmpegPath
        {
            get
            {
                return Path.Combine(FFmpegRootPath, FFmpegFileName);
            }
        }

        [JsonIgnore]
        public string FFprobePath
        {
            get
            {
                return Path.Combine(FFmpegRootPath, FFprobeFileName);
            }
        }

        [JsonIgnore]
        public string FFplayPath
        {
            get
            {
                return Path.Combine(FFmpegRootPath, FFplayFileName);
            }
        }

        [JsonIgnore]
        public bool IsFFmpegPathInitialized
        {
            get
            {
                return !string.IsNullOrWhiteSpace(FFmpegRootPath) &&
                    !string.IsNullOrWhiteSpace(FFmpegPath) &&
                    !string.IsNullOrWhiteSpace(FFprobePath) &&
                    !string.IsNullOrWhiteSpace(FFplayPath);
            }
        } 

        #endregion
    }
}
