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
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.DotNetWrappers;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Helpers
{
    public class LanguageHelper : ILanguageHelper
    {
        #region Fields

        private readonly ISerializationWrapper _serializationWrapper;

        #endregion

        #region Constructor

        public LanguageHelper(ISerializationWrapper serializationWrapper)
        {
            _serializationWrapper = serializationWrapper;
        }

        #endregion

        #region Public Methods

        public List<LanguageInfo> GetLanguages()
        {
            return _serializationWrapper.Deserialize<List<LanguageInfo>>(LibResources.Languages_ISO_639_2)?.OrderBy(language => language.Code).ToList() ?? new();
        }

        #endregion
    }
}
