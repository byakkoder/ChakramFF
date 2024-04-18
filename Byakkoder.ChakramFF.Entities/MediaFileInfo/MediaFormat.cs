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

using Byakkoder.ChakramFF.Entities.MediaFileInfo.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Byakkoder.ChakramFF.Entities.MediaFileInfo
{
    public class MediaFormat
    {
        private string _filename = string.Empty;

        #region Properties

        [JsonPropertyName("filename")]
        public string Filename 
        {
            get
            {
                return _filename;
            }
            set
            {
                byte[] filenameBytes = Encoding.Default.GetBytes(value);
                _filename = Encoding.UTF8.GetString(filenameBytes);
            } 
        }

        [JsonPropertyName("nb_streams")]
        public long NbStreams { get; set; }

        [JsonPropertyName("nb_programs")]
        public long NbPrograms { get; set; }

        [JsonPropertyName("format_name")]
        public string? FormatName { get; set; }

        [JsonPropertyName("format_long_name")]
        public string? FormatLongName { get; set; }

        [JsonPropertyName("start_time")]
        public string? StartTime { get; set; }

        [JsonPropertyName("duration")]
        public string? Duration { get; set; }

        [JsonPropertyName("size")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long Size { get; set; }

        [JsonPropertyName("bit_rate")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long BitRate { get; set; }

        [JsonPropertyName("probe_score")]
        public long ProbeScore { get; set; }

        [JsonPropertyName("tags")]
        public FormatTags? Tags { get; set; } 

        #endregion
    }
}
