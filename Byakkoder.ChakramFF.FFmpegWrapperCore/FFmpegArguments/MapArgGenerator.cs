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
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.FFmpegArguments;
using System;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.FFmpegArguments
{
    public class MapArgGenerator : ISingleArgGenerator<MapArg>
    {
        #region Fields
        
        private readonly ISingleArgGenerator<StreamTypeArg> _streamTypeArgGenerator; 

        #endregion

        #region Constructor

        public MapArgGenerator(ISingleArgGenerator<StreamTypeArg> streamTypeArgGenerator)
        {
            _streamTypeArgGenerator = streamTypeArgGenerator;
        } 

        #endregion

        #region Public Methods

        public string Generate(MapArg sourceArg)
        {
            if (sourceArg.InputIndex < 0)
            {
                throw new ArgumentException("InputIndex must be greater or equals than zero.");
            }

            if (sourceArg.StreamIndex < 0)
            {
                throw new ArgumentException("StreamIndex must be greater or equals than zero.");
            }

            return string.Format(FFmpegArgsResources.MapArgument, sourceArg.InputIndex, _streamTypeArgGenerator.Generate(sourceArg.StreamTypeArg), sourceArg.StreamIndex);
        } 

        #endregion
    }
}
