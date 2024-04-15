using Byakkoder.ChakramFF.Entities.FFmpegArgs;
using Byakkoder.ChakramFF.FFmpegWrapperCore.ChakramSettings;
using Byakkoder.ChakramFF.FFmpegWrapperCore.CommandExecution;
using Byakkoder.ChakramFF.FFmpegWrapperCore.Conversion;
using Byakkoder.ChakramFF.FFmpegWrapperCore.DotNetWrappers;
using Byakkoder.ChakramFF.FFmpegWrapperCore.FFmpegArguments;
using Byakkoder.ChakramFF.FFmpegWrapperCore.FFmpegResponse;
using Byakkoder.ChakramFF.FFmpegWrapperCore.Helpers;
using Byakkoder.ChakramFF.FFmpegWrapperCore.MediaInfoQuery;
using Byakkoder.ChakramFF.FFmpegWrapperCore.MediaMetadata;
using Byakkoder.ChakramFF.FFmpegWrapperCore.MediaPlayer;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.ChakramSettings;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.CommandExecution;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.Conversion;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.DotNetWrappers;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.FFmpegArguments;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.FFmpegResponse;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.Helpers;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.MediaInfoQuery;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.MediaMetadata;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.MediaPlayer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Byakkoder.ChakramFF.Bootstrapper
{
    public static class DIInitializer
    {
        #region Fields

        private static bool _isInitialized;

        #endregion

        #region Properties
        
        public static IServiceProvider ServiceProvider { get; private set; } 

        #endregion

        #region Public Methods

        // DotNet 8 DI: https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage
        public static void Initialize(List<Type> additionalTransientDependencies)
        {
            if (_isInitialized)
            {
                return;
            }

            var builder = Host.CreateDefaultBuilder();

            builder.ConfigureServices(services => services
                // Conversion
                .AddSingleton<IMerger, Merger>()

                // ChakramSettings
                .AddSingleton<IChakramSettingsSingleton, ChakramSettingsSingleton>()
                .AddScoped<IFFmpegSettingsValidator, FFmpegSettingsValidator>()
                .AddScoped<ILoadSettingsManager, LoadSettingsManager>()
                .AddScoped<ISaveSettingsManager, SaveSettingsManager>()
                .AddScoped<ISettingsCleaner, SettingsCleaner>()

                // MediaInfoQuery
                .AddScoped<ISizeQueryHelper, SizeQueryHelper>()
                .AddScoped<IDurationQueryHelper, DurationQueryHelper>()

                // FFmpegResponse
                .AddScoped<IFFmpegResponseBuilder, FFmpegResponseBuilder>()
                .AddScoped<IFFmpegResponseMapper, FFmpegResponseMapper>()
                .AddScoped<IPropertiesDictBuilder, PropertiesDictBuilder>()

                // MediaMetadata
                .AddScoped<IMediaInfoBuilder, MediaInfoBuilder>()

                // FFmpegArguments
                .AddScoped<ISingleArgGenerator<MergeArgs>, MergeArgGenerator>()
                .AddScoped<ISingleArgGenerator<PlayerArgs>, PlayerArgGenerator>()
                .AddScoped<ISingleArgGenerator<FileInfoArg>, FileInfoArgGenerator>()
                .AddScoped<ISingleArgGenerator<DelayArg>, DelayArgGenerator>()
                .AddScoped<ISingleArgGenerator<ShowModeArg>, ShowModeArgGenerator>()
                .AddScoped<ISingleArgGenerator<InputArg>, InputArgGenerator>()
                .AddScoped<ISingleArgGenerator<MapArg>, MapArgGenerator>()
                .AddScoped<ISingleArgGenerator<DefaultArg>, DefaultArgGenerator>()
                .AddScoped<ISingleArgGenerator<MetadataArg>, MetadataArgGenerator>()
                .AddScoped<ISingleArgGenerator<StreamTypeArg>, StreamTypeArgGenerator>()
                .AddScoped<ISingleArgGenerator<StreamSpecifierArg>, StreamSpecifierArgGenerator>()
                .AddScoped<IMultipleArgsGenerator, MultipleArgsGenerator>()

                // MediaPlayer
                .AddSingleton<IPlayer, Player>()

                // CommandExecution
                .AddScoped<ICommandAsyncRunner, CommandAsyncRunner>()
                .AddScoped<ICommandSynchRunner, CommandSynchRunner>()
                .AddScoped<ICommandBasicRunner, CommandBasicRunner>()
                .AddScoped<ICommandRunnerValidator, CommandRunnerValidator>()
                .AddScoped<IStartInfoBuilder, StartInfoBuilder>()
                .AddScoped<IBasicStartInfoBuilder, BasicStartInfoBuilder>()
                .AddScoped<IStartInfoValidator, StartInfoValidator>()

                // Helpers
                .AddScoped<ISecondsTimeConverter, SecondsTimeConverter>()
                .AddScoped<IVideoInfoHelper, VideoInfoHelper>()
                .AddScoped<IStreamIndexer, StreamIndexer>()
                .AddScoped<ILanguageHelper, LanguageHelper>()

                // DotNetWrappers
                .AddScoped<IProcessWrapper, ProcessWrapper>()
                .AddScoped<IFileWrapper, FileWrapper>()
                .AddScoped<ISerializationWrapper, SerializationWrapper>()
                .AddScoped<IConfigurationWrapper, ConfigurationWrapper>());

            additionalTransientDependencies.ForEach(dependencyType => 
                builder.ConfigureServices(services => services.AddTransient(dependencyType)));

            var host = builder.Build();

            ServiceProvider = host.Services;

            //host.RunAsync();

            _isInitialized = true;
        } 

        #endregion
    }
}