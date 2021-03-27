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

using Entities.FFmpegArgs;
using Interfaces.FFmpegWrapperCore.FFmpegArguments;
using System;
using System.Linq;

namespace FFmpegWrapperCore.FFmpegArguments
{
    public class MergeArgGenerator : ISingleArgGenerator<MergeArgs>
    {
        #region Fields

        private readonly IMultipleArgsGenerator _multipleArgsGenerator;
        private readonly ISingleArgGenerator<InputArg> _inputArgGenerator;
        private readonly ISingleArgGenerator<MapArg> _mapArgGenerator;
        private readonly ISingleArgGenerator<DefaultArg> _defaultArgGenerator;
        private readonly ISingleArgGenerator<MetadataArg> _metadataArgGenerator;

        #endregion

        #region Constructor

        public MergeArgGenerator(
            IMultipleArgsGenerator multipleArgsGenerator,
            ISingleArgGenerator<InputArg> inputArgGenerator,
            ISingleArgGenerator<MapArg> mapArgGenerator,
            ISingleArgGenerator<DefaultArg> defaultArgGenerator,
            ISingleArgGenerator<MetadataArg> metadataArgGenerator)
        {
            _multipleArgsGenerator = multipleArgsGenerator;
            _inputArgGenerator = inputArgGenerator;
            _mapArgGenerator = mapArgGenerator;
            _defaultArgGenerator = defaultArgGenerator;
            _metadataArgGenerator = metadataArgGenerator;
        }

        #endregion

        #region Public Methods
        
        public string Generate(MergeArgs sourceArg)
        {
            if (sourceArg == null)
            {
                throw new ArgumentException("Missing mergeArgs to merge.");
            }

            if (!sourceArg.InputArgs.Any())
            {
                throw new ArgumentException("Input files missing to merge.");
            }            

            string inputFileArgs = _multipleArgsGenerator.Generate(sourceArg.InputArgs, _inputArgGenerator);
            string mapArgs = _multipleArgsGenerator.Generate(sourceArg.MapArgs, _mapArgGenerator);
            string defaultArgs = _multipleArgsGenerator.Generate(sourceArg.DefaultArgs, _defaultArgGenerator);
            string metadataArgs = _multipleArgsGenerator.Generate(sourceArg.MetadataArgs, _metadataArgGenerator);

            return string.Format(
                FFmpegArgsResources.MergeArgument,
                $"{inputFileArgs}{FFmpegArgsResources.ArgSeparator}",
                $"{mapArgs}{FFmpegArgsResources.ArgSeparator}",
                !string.IsNullOrWhiteSpace(defaultArgs) ? $"{defaultArgs}{FFmpegArgsResources.ArgSeparator}" : string.Empty,
                !string.IsNullOrWhiteSpace(metadataArgs) ? $"{metadataArgs}{FFmpegArgsResources.ArgSeparator}" : string.Empty,
                sourceArg.OutputFile);
        } 

        #endregion
    }
}
