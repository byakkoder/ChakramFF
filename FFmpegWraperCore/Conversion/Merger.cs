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

using Entities;
using Entities.FFmpegArgs;
using Interfaces.FFmpegWrapperCore.ChakramSettings;
using Interfaces.FFmpegWrapperCore.CommandExecution;
using Interfaces.FFmpegWrapperCore.Conversion;
using Interfaces.FFmpegWrapperCore.FFmpegArguments;
using Interfaces.FFmpegWrapperCore.FFmpegResponse;
using Interfaces.FFmpegWrapperCore.Helpers;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FFmpegWrapperCore.Conversion
{
    public class Merger : IMerger
    {
        #region Events

        public event Action<string> OnCommandSent;
        public event Action<string> OnDataReceived;
        public event Action<string> OnErrorReceived;
        public event Action<int> OnProgress;
        public event Action OnEndProgress;

        #endregion

        #region Constants

        private const string EndOfProcessTag = "video";
        private const int FullPercent = 100;

        #endregion

        #region Fields

        private readonly IChakramSettingsSingleton _chakramSettingsSingleton;
        private readonly ISingleArgGenerator<MergeArgs> _mergeArgGenerator;
        private readonly ICommandAsyncRunner _commandRunner;
        private readonly IFFmpegResponseBuilder _ffmpegResponseBuilder;
        private readonly ISecondsTimeConverter _secondsTimeConverter;
        
        private MergeArgs _mergeArgs;
        private bool _endProgressRaised;

        #endregion

        #region Constructor

        public Merger(
            IChakramSettingsSingleton chakramSettingsSingleton,
            ISingleArgGenerator<MergeArgs> mergeArgGenerator,
            IFFmpegResponseBuilder ffmpegResponseBuilder,
            ISecondsTimeConverter secondsTimeConverter,
            ICommandAsyncRunner commandRunner)
        {
            _chakramSettingsSingleton = chakramSettingsSingleton;
            _mergeArgGenerator = mergeArgGenerator;
            _ffmpegResponseBuilder = ffmpegResponseBuilder;
            _secondsTimeConverter = secondsTimeConverter;
            _commandRunner = commandRunner;
            _commandRunner.OnDataReceived += CommandRunner_OnDataReceived;
            _commandRunner.OnErrorReceived += CommandRunner_OnErrorReceived;
        }

        #endregion

        #region Public Methods

        public void Merge(MergeArgs mergeArgs)
        {
            _mergeArgs = mergeArgs;

            if (File.Exists(mergeArgs.OutputFile))
            {
                File.Delete(mergeArgs.OutputFile);
            }

            string arguments = _mergeArgGenerator.Generate(mergeArgs);

            OnCommandSent?.Invoke($"FFmpeg command ---> {_chakramSettingsSingleton.ChakramSettings.FFmpegPath} {arguments}");

            _commandRunner.Run(_chakramSettingsSingleton.ChakramSettings.FFmpegPath, arguments);            
        }

        public void Stop()
        {
            _endProgressRaised = false;
            _commandRunner.Stop();

            if (!File.Exists(_mergeArgs.OutputFile))
            {
                return;
            }

            Task.Run(async delegate
            {
                await Task.Delay(2000);
                File.Delete(_mergeArgs.OutputFile);
            });
        }

        #endregion

        #region Command Runner Events

        private void CommandRunner_OnErrorReceived(string outputLine)
        {
            FFmpegResponseInfo fFmpegResponseInfo = _ffmpegResponseBuilder.Build(outputLine);
            if (fFmpegResponseInfo != null)
            {
                double percentProcessed = System.Convert.ToDouble(_secondsTimeConverter.ConvertToSeconds(fFmpegResponseInfo.Time)) * 100D / System.Convert.ToDouble(_mergeArgs.Duration);
                int totalProgressPercent = System.Convert.ToInt32(Math.Floor(percentProcessed));

                OnProgress?.Invoke(totalProgressPercent);

                if (totalProgressPercent == FullPercent)
                {
                    OnEndProgress?.Invoke();
                    _endProgressRaised = true;
                }
            }

            // Fix: Sometimes FFmpeg does not write the last frame processed in the console output.
            if (outputLine.StartsWith(EndOfProcessTag))
            {
                if (!_endProgressRaised)
                {
                    OnProgress?.Invoke(FullPercent);
                    OnEndProgress?.Invoke();
                }
                else
                {
                    _endProgressRaised = false;
                }
            }

            OnErrorReceived?.Invoke(outputLine);
        }

        private void CommandRunner_OnDataReceived(string outputErrorLine)
        {
            OnDataReceived?.Invoke(outputErrorLine);
        }

        #endregion
    }
}
