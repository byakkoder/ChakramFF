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

using Entities.MediaFileInfo;
using Entities.Dto;
using Interfaces.FFmpegWrapperCore.Helpers;
using Interfaces.FFmpegWrapperCore.MediaInfoQuery;
using Interfaces.FFmpegWrapperCore.MediaMetadata;
using System;
using System.IO;
using Entities.FFmpegArgs;

namespace FFmpegWrapperCore.MediaMetadata
{
    public class MediaInfoBuilder : IMediaInfoBuilder
    {
        #region Fields
        
        private readonly IVideoInfoHelper _infoHelper;
        private readonly ISizeQueryHelper _sizeQueryHelper;
        private readonly IDurationQueryHelper _durationQueryHelper;

        #endregion

        #region Constructor

        public MediaInfoBuilder(
            IVideoInfoHelper infoHelper,
            ISizeQueryHelper sizeQueryHelper,
            IDurationQueryHelper durationQueryHelper)
        {
            _infoHelper = infoHelper;
            _sizeQueryHelper = sizeQueryHelper;
            _durationQueryHelper = durationQueryHelper;
        } 

        #endregion

        #region Public Methods

        public MediaInfoDto BuildMediaInfo(FileInfoArg fileInfoArg)
        {
            if (string.IsNullOrWhiteSpace(fileInfoArg.FilePath))
            {
                throw new ArgumentException("Missing source file path");
            }

            MediaInfoDto mediaInfoDto = new MediaInfoDto();

            mediaInfoDto.FullFilename = fileInfoArg.FilePath;
            mediaInfoDto.Filename = new FileInfo(fileInfoArg.FilePath).Name;

            MediaInfo mediaInfo = _infoHelper.GetVideoInfo(fileInfoArg);

            mediaInfoDto.MediaInfo = mediaInfo;
            mediaInfoDto.Size = _sizeQueryHelper.GetSize(mediaInfo);
            mediaInfoDto.Duration = _durationQueryHelper.GetDuration(mediaInfo);

            return mediaInfoDto;
        }

        #endregion
    }
}
