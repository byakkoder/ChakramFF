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

using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.Helpers;
using System;
using System.Globalization;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Helpers
{
    public class SecondsTimeConverter : ISecondsTimeConverter
    {
        #region Public Methods

        public float ConvertToSeconds(string time)
        {
            if(string.IsNullOrWhiteSpace(time))
            {
                throw new ArgumentException("Invalid time argument.");
            }

            string[] timeSegments = time.Split(new char[] { ':' });

            if(timeSegments.Length != 3)
            {
                throw new FormatException("Wrong time format.");
            }

            float seconds = Convert.ToSingle(timeSegments[2]
                .Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                .Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            float minsInSeconds = Convert.ToSingle(timeSegments[1]) * 60f;
            float hoursInSeconds = Convert.ToSingle(timeSegments[0]) * 60f * 60f;

            return hoursInSeconds + minsInSeconds + seconds;
        }

        #endregion
    }
}
