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

using Entities.MediaFileInfo;
using Interfaces.FFmpegWrapperCore.MediaInfoQuery;
using System;
using System.Globalization;

namespace FFmpegWrapperCore.MediaInfoQuery
{
    public class DurationQueryHelper : IDurationQueryHelper
    {
        #region Constants
        
        private const string CommaDecimalSeparator = ",";
        private const string DotDecimalSeparator = "."; 

        #endregion

        #region Public Methods

        public TimeSpan GetDuration(MediaInfo mediaInfo)
        {
            if (mediaInfo.Format == null || string.IsNullOrWhiteSpace(mediaInfo.Format.Duration))
            {
                return new TimeSpan();
            }

            string separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            double durationInSeconds = Convert.ToDouble(mediaInfo.Format.Duration.
                Replace(DotDecimalSeparator, separator).
                Replace(CommaDecimalSeparator, separator));

            return TimeSpan.FromSeconds(durationInSeconds);
        } 

        #endregion
    }
}
