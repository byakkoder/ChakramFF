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
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Byakkoder.ChakramFF.Entities.MediaFileInfo;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Helpers
{
    public class StreamIndexer : IStreamIndexer
    {
        #region Public Methods
        
        public void SetIndex(List<MediaStream> streams)
        {
            if (streams == null)
            {
                return;
            }

            if (streams.Any(stream => stream.StreamType == StreamType.None))
            {
                throw new ArgumentException("Stream has a not valid type.");
            }

            List<StreamType> streamTypes = Enum.GetValues(typeof(StreamType)).Cast<StreamType>().ToList();

            foreach (StreamType streamType in streamTypes)
            {
                List<MediaStream> mediaStreams = streams.FindAll(stream => stream.StreamType == streamType);
                if (!mediaStreams.Any())
                {
                    continue;
                }

                int streamIndex = 0;
                mediaStreams.ForEach(stream =>
                {
                    stream.IndexByType = streamIndex;
                    streamIndex++;
                });
            }
        } 

        #endregion
    }
}
