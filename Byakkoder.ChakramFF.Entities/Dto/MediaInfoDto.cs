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
using System.Drawing;

namespace Byakkoder.ChakramFF.Entities.Dto
{
    public class MediaInfoDto
    {
        #region Fields
        
        private Size _size;
        private TimeSpan _duration;

        #endregion

        #region Constructor
        
        public MediaInfoDto() { }

        #endregion

        #region Properties
        
        public MediaInfo MediaInfo { get; set; }

        public string Filename { get; set; }

        public string FullFilename { get; set; }

        public string SizeString { get; private set; }

        public Size Size 
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                SizeString = $"[{_size.Width}x{_size.Height}]";
            }
        }

        public string DurationString { get; private set; }

        public TimeSpan Duration 
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
                DurationString = $"[{_duration.ToString()}]";
            } 
        }

        public bool CustomVideoSettings { get; set; }

        #endregion
    }
}
