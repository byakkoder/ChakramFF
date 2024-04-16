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

using Byakkoder.ChakramFF.Entities.FFmpegArgs;
using Byakkoder.ChakramFF.Entities.Dto;
using System.Collections.Generic;
using System.Linq;

namespace ChakramFF.Mappers
{
    public static class DefaultArgsMapper
    {
        #region Public Methods
        
        public static List<DefaultArg> Map(List<StreamItemDto> streams)
        {
            List<DefaultArg> defaultArgs = new List<DefaultArg>();

            streams.ForEach(stream =>
            {
                List<DefaultArg> defaultArgsByType = defaultArgs.FindAll(defaultArg => defaultArg.StreamTypeArg.StreamType == stream.MediaStream.StreamType);
                int lastIndex = defaultArgsByType.Any() ? defaultArgsByType.Max(defaultArg => defaultArg.StreamIndex) : -1;

                defaultArgs.Add(new DefaultArg
                {
                    StreamTypeArg = new StreamTypeArg { StreamType = stream.MediaStream.StreamType },
                    StreamIndex = lastIndex + 1,
                    Default = stream.StreamSettings.Default
                });
            });

            return defaultArgs;
        } 

        #endregion
    }
}
