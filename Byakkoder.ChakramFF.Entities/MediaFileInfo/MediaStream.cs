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
using System.Text.Json.Serialization;

namespace Byakkoder.ChakramFF.Entities.MediaFileInfo
{
    public class MediaStream
    {
        #region Properties

        [JsonPropertyName("index")]
        public long Index { get; set; }

        [JsonPropertyName("codec_name")]
        public string CodecName { get; set; }

        [JsonPropertyName("codec_long_name")]
        public string CodecLongName { get; set; }

        [JsonPropertyName("profile")]
        public string Profile { get; set; }

        [JsonPropertyName("codec_type")]
        public string CodecType { get; set; }

        [JsonPropertyName("codec_time_base")]
        public string CodecTimeBase { get; set; }

        [JsonPropertyName("codec_tag_string")]
        public string CodecTagString { get; set; }

        [JsonPropertyName("codec_tag")]
        public string CodecTag { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("width")]
        public int? Width { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("height")]
        public int? Height { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("coded_width")]
        public long? CodedWidth { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("coded_height")]
        public long? CodedHeight { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("has_b_frames")]
        public long? HasBFrames { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("pix_fmt")]
        public string PixFmt { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("level")]
        public long? Level { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("chroma_location")]
        public string ChromaLocation { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("refs")]
        public long? Refs { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("is_avc")]
        [JsonConverter(typeof(ParseBoolStringConverter))]
        public bool? IsAvc { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("nal_length_size")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long? NalLengthSize { get; set; }

        [JsonPropertyName("r_frame_rate")]
        public string RFrameRate { get; set; }

        [JsonPropertyName("avg_frame_rate")]
        public string AvgFrameRate { get; set; }

        [JsonPropertyName("time_base")]
        public string TimeBase { get; set; }

        [JsonPropertyName("start_pts")]
        public long StartPts { get; set; }

        [JsonPropertyName("start_time")]
        public string StartTime { get; set; }

        [JsonPropertyName("duration_ts")]
        public long DurationTs { get; set; }

        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        [JsonPropertyName("bit_rate")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long BitRate { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("bits_per_raw_sample")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long? BitsPerRawSample { get; set; }

        [JsonPropertyName("nb_frames")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long NbFrames { get; set; }

        [JsonPropertyName("disposition")]
        public Dictionary<string, long> Disposition { get; set; }

        [JsonPropertyName("tags")]
        public Dictionary<string, string> Tags { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("sample_fmt")]
        public string SampleFmt { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("sample_rate")]
        [JsonConverter(typeof(ParseLongStringConverter))]
        public long? SampleRate { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("channels")]
        public long? Channels { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("channel_layout")]
        public string ChannelLayout { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("bits_per_sample")]
        public long? BitsPerSample { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("max_bit_rate")]
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
