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

using Byakkoder.ChakramFF.Entities.MediaFileInfo;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.MediaInfoQuery;
using System.Drawing;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.MediaInfoQuery
{
    public class SizeQueryHelper : ISizeQueryHelper
    {
        #region Public Methods

        public Size GetSize(MediaInfo mediaInfo)
        {
            if (mediaInfo.Streams == null || mediaInfo.Streams.Count == 0)
            {
                return new Size();
            }

            MediaStream? mediaStream = mediaInfo.Streams.Find(stream => stream.Width != null && stream.Height != null);
            if (mediaStream != null)
            {
                return new Size(mediaStream.Width.GetValueOrDefault(), mediaStream.Height.GetValueOrDefault());
            }

            return new Size();
        }

        #endregion
    }
}
