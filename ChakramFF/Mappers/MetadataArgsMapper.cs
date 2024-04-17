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
using Byakkoder.ChakramFF.Entities.Dto;
using System.Collections.Generic;

namespace ChakramFF.Mappers
{
    public static class MetadataArgsMapper
    {
        #region Public Methods
        
        public static List<MetadataArg> Map(StreamItemDto streamItem, int streamIndex)
        {
            List<MetadataArg> metadataArgs = new List<MetadataArg>();

            MetadataArg titleMetadata = MetadataArgMapper.Map(streamItem, Metadata.Title, streamItem.StreamSettings.Title, streamIndex);
            MetadataArg languageMetadata = MetadataArgMapper.Map(streamItem, Metadata.Language, streamItem.StreamSettings.Language, streamIndex);

            if (titleMetadata != null)
            {
                metadataArgs.Add(titleMetadata);
            }

            if (languageMetadata != null)
            {
                metadataArgs.Add(languageMetadata);
            }            

            return metadataArgs;
        } 

        #endregion
    }
}
