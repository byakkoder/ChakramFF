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
using Byakkoder.ChakramFF.Entities.MediaFileInfo;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.ChakramSettings;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.CommandExecution;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.DotNetWrappers;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.FFmpegArguments;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.Helpers;
using System;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Helpers
{
    public class VideoInfoHelper : IVideoInfoHelper
    {
        #region Fields

        private readonly IChakramSettingsSingleton _chakramSettingsSingleton;
        private readonly ISingleArgGenerator<FileInfoArg> _fileInfoArgGenerator;
        private readonly ICommandSynchRunner _commandRunner;
        private readonly ISerializationWrapper _serializationWrapper;
        private readonly IStreamIndexer _streamIndexer;

        #endregion

        #region Constructor

        public VideoInfoHelper(
            IChakramSettingsSingleton chakramSettingsSingleton,
            ISingleArgGenerator<FileInfoArg> fileInfoArgGenerator,
            ICommandSynchRunner commandRunner,
            ISerializationWrapper serializationWrapper,
            IStreamIndexer streamIndexer)
        {
            _chakramSettingsSingleton = chakramSettingsSingleton;
            _fileInfoArgGenerator = fileInfoArgGenerator;
            _commandRunner = commandRunner;
            _serializationWrapper = serializationWrapper;
            _streamIndexer = streamIndexer;
        }

        #endregion

        #region Public Methods

        public MediaInfo? GetVideoInfo(FileInfoArg fileInfoArg)
        {
            if (string.IsNullOrWhiteSpace(fileInfoArg.FilePath))
            {
                throw new ArgumentException("Missing file path to get information.");
            }

            string arguments = _fileInfoArgGenerator.Generate(fileInfoArg);

            string fileMetadata = _commandRunner.Run(_chakramSettingsSingleton.ChakramSettings.FFprobePath, arguments, false);

            MediaInfo? mediaInfo = _serializationWrapper.Deserialize<MediaInfo>(fileMetadata);

            if (mediaInfo != null && mediaInfo.Streams != null)
            {
                _streamIndexer.SetIndex(mediaInfo.Streams);
            }            

            return mediaInfo;
        }

        #endregion
    }
}
