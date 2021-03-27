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

using Unity;
using Interfaces.FFmpegWrapperCore.FFmpegArguments;
using FFmpegWrapperCore.FFmpegArguments;
using Interfaces.FFmpegWrapperCore.MediaMetadata;
using FFmpegWrapperCore.MediaMetadata;
using FFmpegWrapperCore.DotNetWrappers;
using Interfaces.FFmpegWrapperCore.DotNetWrappers;
using Interfaces.FFmpegWrapperCore.Helpers;
using FFmpegWrapperCore.Helpers;
using FFmpegWrapperCore.CommandExecution;
using Interfaces.FFmpegWrapperCore.CommandExecution;
using Interfaces.FFmpegWrapperCore.FFmpegResponse;
using FFmpegWrapperCore.FFmpegResponse;
using Interfaces.FFmpegWrapperCore.MediaInfoQuery;
using FFmpegWrapperCore.MediaInfoQuery;
using Interfaces.FFmpegWrapperCore.ChakramSettings;
using FFmpegWrapperCore.ChakramSettings;
using FFmpegWrapperCore.Conversion;
using Interfaces.FFmpegWrapperCore.Conversion;
using Interfaces.FFmpegWrapperCore.MediaPlayer;
using FFmpegWrapperCore.MediaPlayer;
using Entities.FFmpegArgs;

namespace Bootstrapper
{
    public static class UnityDIInitializer
    {
        #region Fields
        
        private static bool _isInitialized;

        #endregion

        #region Public Methods
        
        public static void Initialize()
        {
            if (_isInitialized)
            {
                return;
            }

            IUnityContainer unityContainer = DIContainerManager.GetContainer();            

            #region Conversion

            unityContainer.RegisterType<IMerger, Merger>(TypeLifetime.Singleton);

            #endregion

            #region ChakramSettings

            unityContainer.RegisterType<IChakramSettingsSingleton, ChakramSettingsSingleton>(TypeLifetime.Singleton);
            unityContainer.RegisterType<IFFmpegSettingsValidator, FFmpegSettingsValidator>();
            unityContainer.RegisterType<ILoadSettingsManager, LoadSettingsManager>();
            unityContainer.RegisterType<ISaveSettingsManager, SaveSettingsManager>();
            unityContainer.RegisterType<ISettingsCleaner, SettingsCleaner>();

            #endregion

            #region MediaInfoQuery

            unityContainer.RegisterType<ISizeQueryHelper, SizeQueryHelper>();
            unityContainer.RegisterType<IDurationQueryHelper, DurationQueryHelper>(); 

            #endregion

            #region FFmpegResponse

            unityContainer.RegisterType<IFFmpegResponseBuilder, FFmpegResponseBuilder>();
            unityContainer.RegisterType<IFFmpegResponseMapper, FFmpegResponseMapper>();
            unityContainer.RegisterType<IPropertiesDictBuilder, PropertiesDictBuilder>(); 

            #endregion

            #region MediaMetadata

            unityContainer.RegisterType<IMediaInfoBuilder, MediaInfoBuilder>();

            #endregion

            #region FFmpegArguments

            unityContainer.RegisterType<ISingleArgGenerator<MergeArgs>, MergeArgGenerator>();
            unityContainer.RegisterType<ISingleArgGenerator<PlayerArgs>, PlayerArgGenerator>();
            
            unityContainer.RegisterType<ISingleArgGenerator<FileInfoArg>, FileInfoArgGenerator>();
            unityContainer.RegisterType<ISingleArgGenerator<DelayArg>, DelayArgGenerator>();
            unityContainer.RegisterType<ISingleArgGenerator<ShowModeArg>, ShowModeArgGenerator>();
            unityContainer.RegisterType<ISingleArgGenerator<InputArg>, InputArgGenerator>();
            unityContainer.RegisterType<ISingleArgGenerator<MapArg>, MapArgGenerator>();
            unityContainer.RegisterType<ISingleArgGenerator<DefaultArg>, DefaultArgGenerator>();
            unityContainer.RegisterType<ISingleArgGenerator<MetadataArg>, MetadataArgGenerator>();
            unityContainer.RegisterType<ISingleArgGenerator<StreamSpecifierArg>, StreamSpecifierArgGenerator>();
            unityContainer.RegisterType<ISingleArgGenerator<StreamTypeArg>, StreamTypeArgGenerator>();

            unityContainer.RegisterType<IMultipleArgsGenerator, MultipleArgsGenerator>();

            #endregion

            #region MediaPlayer

            unityContainer.RegisterType<IPlayer, Player>(TypeLifetime.Singleton); 

            #endregion

            #region CommandExecution

            unityContainer.RegisterType<ICommandAsyncRunner, CommandAsyncRunner>();
            unityContainer.RegisterType<ICommandSynchRunner, CommandSynchRunner>();
            unityContainer.RegisterType<ICommandBasicRunner, CommandBasicRunner>();
            unityContainer.RegisterType<ICommandRunnerValidator, CommandRunnerValidator>();
            unityContainer.RegisterType<IStartInfoBuilder, StartInfoBuilder>();
            unityContainer.RegisterType<IBasicStartInfoBuilder, BasicStartInfoBuilder>();
            unityContainer.RegisterType<IStartInfoValidator, StartInfoValidator>();

            #endregion

            #region Helpers

            unityContainer.RegisterType<ISecondsTimeConverter, SecondsTimeConverter>();
            unityContainer.RegisterType<IVideoInfoHelper, VideoInfoHelper>();
            unityContainer.RegisterType<IStreamIndexer, StreamIndexer>();
            unityContainer.RegisterType<ILanguageHelper, LanguageHelper>();

            #endregion

            #region DotNetWrappers

            unityContainer.RegisterType<IProcessWrapper, ProcessWrapper>();
            unityContainer.RegisterType<IFileWrapper, FileWrapper>();
            unityContainer.RegisterType<ISerializationWrapper, SerializationWrapper>();
            unityContainer.RegisterType<IConfigurationWrapper, ConfigurationWrapper>();

            #endregion

            _isInitialized = true;
        } 

        #endregion
    }
}
