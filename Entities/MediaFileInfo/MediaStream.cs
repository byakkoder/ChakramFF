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

using Entities.MediaFileInfo.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Entities.MediaFileInfo
{
    public class MediaStream
    {
        #region Properties

        [JsonProperty("index")]
        public long Index { get; set; }

        [JsonProperty("codec_name")]
        public string CodecName { get; set; }

        [JsonProperty("codec_long_name")]
        public string CodecLongName { get; set; }

        [JsonProperty("profile")]
        public string Profile { get; set; }

        [JsonProperty("codec_type")]
        public string CodecType { get; set; }

        [JsonProperty("codec_time_base")]
        public string CodecTimeBase { get; set; }

        [JsonProperty("codec_tag_string")]
        public string CodecTagString { get; set; }

        [JsonProperty("codec_tag")]
        public string CodecTag { get; set; }

        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public int? Width { get; set; }

        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public int? Height { get; set; }

        [JsonProperty("coded_width", NullValueHandling = NullValueHandling.Ignore)]
        public long? CodedWidth { get; set; }

        [JsonProperty("coded_height", NullValueHandling = NullValueHandling.Ignore)]
        public long? CodedHeight { get; set; }

        [JsonProperty("has_b_frames", NullValueHandling = NullValueHandling.Ignore)]
        public long? HasBFrames { get; set; }

        [JsonProperty("pix_fmt", NullValueHandling = NullValueHandling.Ignore)]
        public string PixFmt { get; set; }

        [JsonProperty("level", NullValueHandling = NullValueHandling.Ignore)]
        public long? Level { get; set; }

        [JsonProperty("chroma_location", NullValueHandling = NullValueHandling.Ignore)]
        public string ChromaLocation { get; set; }

        [JsonProperty("refs", NullValueHandling = NullValueHandling.Ignore)]
        public long? Refs { get; set; }

        [JsonProperty("is_avc", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseBoolStringConverter))]
        public bool? IsAvc { get; set; }

        [JsonProperty("nal_length_size", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long? NalLengthSize { get; set; }

        [JsonProperty("r_frame_rate")]
        public string RFrameRate { get; set; }

        [JsonProperty("avg_frame_rate")]
        public string AvgFrameRate { get; set; }

        [JsonProperty("time_base")]
        public string TimeBase { get; set; }

        [JsonProperty("start_pts")]
        public long StartPts { get; set; }

        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        [JsonProperty("duration_ts")]
        public long DurationTs { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("bit_rate")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long BitRate { get; set; }

        [JsonProperty("bits_per_raw_sample", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long? BitsPerRawSample { get; set; }

        [JsonProperty("nb_frames")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long NbFrames { get; set; }

        [JsonProperty("disposition")]
        public Dictionary<string, long> Disposition { get; set; }

        [JsonProperty("tags")]
        public Dictionary<string, string> Tags { get; set; }

        [JsonProperty("sample_fmt", NullValueHandling = NullValueHandling.Ignore)]
        public string SampleFmt { get; set; }

        [JsonProperty("sample_rate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long? SampleRate { get; set; }

        [JsonProperty("channels", NullValueHandling = NullValueHandling.Ignore)]
        public long? Channels { get; set; }

        [JsonProperty("channel_layout", NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelLayout { get; set; }

        [JsonProperty("bits_per_sample", NullValueHandling = NullValueHandling.Ignore)]
        public long? BitsPerSample { get; set; }

        [JsonProperty("max_bit_rate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long? MaxBitRate { get; set; }

        [JsonIgnore]
        public StreamType StreamType
        {
            get
            {
                StreamType streamType;

                bool converted = Enum.TryParse(CodecType, true, out streamType);

                if (converted)
                {
                    return streamType;
                }

                return StreamType.None;
            }
        }

        [JsonIgnore]
        public int IndexByType { get; set; }

        #endregion
    }
}
