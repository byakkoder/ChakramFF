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

using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.FFmpegResponse;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.FFmpegResponse
{
    public class PropertiesDictBuilder : IPropertiesDictBuilder
    {
        #region Constants

        private const string PropertyRegex = @"\b\w+\s*\={1}\-*\s*\S+\b";
        private const string Lsize = "Lsize";
        private const string Size = "size";
        private const char PropertySeparator = '='; 
        
        #endregion

        #region Public Methods

        public Dictionary<string, string> Build(string ffmpegOutputLine)
        {
            Dictionary<string, string> propertiesDict = new Dictionary<string, string>();

            if(ffmpegOutputLine == null)
            {
                throw new ArgumentException("OutputLine to process is mandatory.");
            }

            if (string.IsNullOrWhiteSpace(ffmpegOutputLine))
            {
                return propertiesDict;
            }

            ffmpegOutputLine = ffmpegOutputLine.Replace(Lsize, Size); // Avoid error from FFmpeg output
            Regex regex = new Regex(PropertyRegex, RegexOptions.IgnoreCase);
            MatchCollection resultPairs = regex.Matches(ffmpegOutputLine);

            foreach (Match match in resultPairs)
            {
                string[] propertyData = match.Value.Split(new char[] { PropertySeparator }, StringSplitOptions.RemoveEmptyEntries);
                propertiesDict.Add(propertyData[0].Trim(), propertyData[1].Trim());
            }

            return propertiesDict;
        }

        #endregion
    }
}
