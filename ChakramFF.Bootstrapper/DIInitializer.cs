using Entities.FFmpegArgs;
using FFmpegWrapperCore.ChakramSettings;
using FFmpegWrapperCore.CommandExecution;
using FFmpegWrapperCore.Conversion;
using FFmpegWrapperCore.DotNetWrappers;
using FFmpegWrapperCore.FFmpegArguments;
using FFmpegWrapperCore.FFmpegResponse;
using FFmpegWrapperCore.Helpers;
using FFmpegWrapperCore.MediaInfoQuery;
using FFmpegWrapperCore.MediaMetadata;
using FFmpegWrapperCore.MediaPlayer;
using Interfaces.FFmpegWrapperCore.ChakramSettings;
using Interfaces.FFmpegWrapperCore.CommandExecution;
using Interfaces.FFmpegWrapperCore.Conversion;
using Interfaces.FFmpegWrapperCore.DotNetWrappers;
using Interfaces.FFmpegWrapperCore.FFmpegArguments;
using Interfaces.FFmpegWrapperCore.FFmpegResponse;
using Interfaces.FFmpegWrapperCore.Helpers;
using Interfaces.FFmpegWrapperCore.MediaInfoQuery;
using Interfaces.FFmpegWrapperCore.MediaMetadata;
using Interfaces.FFmpegWrapperCore.MediaPlayer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChakramFF.Bootstrapper
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

        // DotNet 6 DI: https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage
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