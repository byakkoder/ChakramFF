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
using System;

namespace ChakramFF.Helpers
{
    public static class StreamIdHelper
    {
        #region Constants
        
        private const string UndefinedLanguage = "und";
        private const string LanguageTag = "language";

        #endregion

        #region Public Methods
        
        public static string GetId(MediaStream mediaStream)
        {
            if (mediaStream == null)
            {
                throw new ArgumentException("Missing media stream.");
            }

            string streamLanguage = UndefinedLanguage;

            if (mediaStream?.Tags != null && mediaStream.Tags.ContainsKey(LanguageTag))
            {
                streamLanguage = mediaStream.Tags[LanguageTag];
            }

            return $"{mediaStream.StreamType} {streamLanguage} {mediaStream.Index}";
        } 

        #endregion
    }
}
