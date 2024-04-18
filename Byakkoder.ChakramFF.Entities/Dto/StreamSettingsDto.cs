﻿/*********************************************************************************
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

namespace Byakkoder.ChakramFF.Entities.Dto
{
    public class StreamSettingsDto
    {
        #region Properties

        public string StreamId { get; set; } = string.Empty;

        public double Delay { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Language { get; set; } = string.Empty;

        public bool Default { get; set; }

        public string FileName { get; set; } = string.Empty;

        public StreamType StreamType { get; set; }

        public int StreamIndex { get; set; }

        #endregion
    }
}
