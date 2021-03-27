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
using Entities.Dto;
using System;
using System.Collections.Generic;

namespace ChakramFF.Mappers
{
    public static class StreamSettingsMapper
    {
        #region Public Methods
        
        public static StreamSettingsDto Map(StreamSettingsInputDto streamSettingsInput)
        {
            if (streamSettingsInput.MediaStream.Tags == null)
            {
                streamSettingsInput.MediaStream.Tags = new Dictionary<string, string>();
            }

            if (streamSettingsInput.MediaStream.Disposition == null)
            {
                streamSettingsInput.MediaStream.Disposition = new Dictionary<string, long>();
            }

            bool sourceItemsHasDefault =
                streamSettingsInput.MediaStream.StreamType == StreamType.Video && streamSettingsInput.HasDefaultVideoStream ||
                streamSettingsInput.MediaStream.StreamType == StreamType.Audio && streamSettingsInput.HasDefaultAudioStream ||
                streamSettingsInput.MediaStream.StreamType == StreamType.Subtitle && streamSettingsInput.HasDefaultSubtitleStream;


            return new StreamSettingsDto
            {
                StreamId = streamSettingsInput.StreamId,
                FileName = streamSettingsInput.FileName,
                Title = streamSettingsInput.MediaStream.Tags.ContainsKey("title") ? streamSettingsInput.MediaStream.Tags["title"] : string.Empty,
                Language = streamSettingsInput.MediaStream.Tags.ContainsKey("language") ? streamSettingsInput.MediaStream.Tags["language"] : string.Empty,
                Default = 
                    !sourceItemsHasDefault && 
                    streamSettingsInput.MediaStream.Disposition.ContainsKey("default") && 
                    Convert.ToBoolean(streamSettingsInput.MediaStream.Disposition["default"]),
                StreamType = streamSettingsInput.MediaStream.StreamType,
                StreamIndex = Convert.ToInt32(streamSettingsInput.MediaStream.Index)
            };
        } 

        #endregion
    }
}
