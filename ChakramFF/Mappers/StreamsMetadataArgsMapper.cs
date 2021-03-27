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
using Entities.Dto;
using System.Collections.Generic;
using System.Linq;

namespace ChakramFF.Mappers
{
    public static class StreamsMetadataArgsMapper
    {
        #region Public Methods
        
        public static List<MetadataArg> Map(List<StreamItemDto> streams)
        {
            List<MetadataArg> metadataArgs = new List<MetadataArg>();

            streams.ForEach(stream =>
            {
                List<MetadataArg> metadataArgsByType = metadataArgs.FindAll(metadataArg => metadataArg.StreamTypeArg.StreamType == stream.MediaStream.StreamType);
                int lastIndex = metadataArgsByType.Any() ? metadataArgsByType.Max(metadataArg => metadataArg.StreamIndex) : -1;

                metadataArgs.AddRange(MetadataArgsMapper.Map(stream, lastIndex + 1));
            });

            return metadataArgs;
        } 

        #endregion
    }
}
