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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ChakramFF.Helpers;
using ChakramFF.Mappers;
using Entities.MediaFileInfo;
using Entities.Dto;

namespace ChakramFF.Controls
{
    public partial class StreamList : UserControl
    {
        #region Fields
        
        private Dictionary<string, StreamItem> _streams;
        private List<StreamItem> _sortedStreamList;

        #endregion

        #region Constructor
        
        public StreamList()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods
        
        public List<StreamItemDto> GetSelectedStreams()
        {
            List<StreamItemDto> selectedStreams =
                _sortedStreamList.FindAll(streamItem =>
                    streamItem.GetStreamInfo().IsSelected).Select(streamItem =>
                        streamItem.GetStreamInfo()).ToList();

            return selectedStreams;
        }

        public void AddStreams(MediaInfo mediaInfo)
        {
            bool hasDefaultVideoStream = _sortedStreamList.Any(stream => 
                stream.GetStreamInfo().MediaStream.StreamType == Entities.StreamType.Video && 
                stream.GetStreamInfo().StreamSettings.Default);

            bool hasDefaultAudioStream = _sortedStreamList.Any(stream =>
                stream.GetStreamInfo().MediaStream.StreamType == Entities.StreamType.Audio &&
                stream.GetStreamInfo().StreamSettings.Default);

            bool hasDefaultSubtitleStream = _sortedStreamList.Any(stream =>
                stream.GetStreamInfo().MediaStream.StreamType == Entities.StreamType.Subtitle &&
                stream.GetStreamInfo().StreamSettings.Default);

            mediaInfo.Streams.ForEach(stream =>
            {
                string key = $"{mediaInfo.Format.Filename}|{stream.CodecType}|{stream.Index}";
                if (!_streams.ContainsKey(key))
                {
                    StreamSettingsInputDto streamSettingsInput = new StreamSettingsInputDto
                    {
                        HasDefaultVideoStream = hasDefaultVideoStream,
                        HasDefaultAudioStream = hasDefaultAudioStream,
                        HasDefaultSubtitleStream = hasDefaultSubtitleStream,
                        MediaStream = stream,
                        StreamId = StreamIdHelper.GetId(stream),
                        FileName = mediaInfo.Format.Filename
                    };

                    AddStream(mediaInfo, streamSettingsInput, key);
                }
            });
        }

        #endregion

        #region Control Events

        private void StreamItem_OnSettingsChanged(StreamItemDto streamItem)
        {
            if (!streamItem.StreamSettings.Default)
            {
                return;
            }

            List<StreamItemDto> sameTypeStreams = GetAllStreams().FindAll(stream => 
                stream.MediaStream.StreamType == streamItem.MediaStream.StreamType);
            
            if (sameTypeStreams.Contains(streamItem))
            {
                sameTypeStreams.Remove(streamItem);
            }

            sameTypeStreams.ForEach(stream => stream.StreamSettings.Default = false);
        }

        private void StreamItem_OnSelect(StreamItem streamItem)
        {
            SelectItem(streamItem);
        }

        private void StreamItem_OnDelete(StreamItem itemToDelete)
        {
            int currentIndex = _sortedStreamList.IndexOf(itemToDelete);

            StreamItemDto streamItemDto = itemToDelete.GetStreamInfo();
            string key = $"{streamItemDto.MediaFormat.Filename}|{streamItemDto.MediaStream.CodecType}|{streamItemDto.MediaStream.Index}";

            _sortedStreamList.Remove(itemToDelete);
            _streams.Remove(key);

            BindItems();

            SelectItemAfterDelete(currentIndex);
        }

        private void StreamItem_OnDown(StreamItem itemToMove)
        {
            MoveItem(itemToMove, 1, _sortedStreamList.Count);
        }

        private void StreamItem_OnUp(StreamItem itemToMove)
        {
            MoveItem(itemToMove, -1, 0);
        }

        private void StreamList_Load(object sender, EventArgs e)
        {
            _streams = new Dictionary<string, StreamItem>();
            _sortedStreamList = new List<StreamItem>();
        }

        #endregion

        #region Private Methods

        private void AddStream(MediaInfo mediaInfo, StreamSettingsInputDto streamSettingsInput, string key)
        {
            StreamItemDto streamItemInfo = new StreamItemDto
            {
                StreamId = streamSettingsInput.StreamId,
                MediaFormat = mediaInfo.Format,
                MediaStream = streamSettingsInput.MediaStream,
                StreamSettings = StreamSettingsMapper.Map(streamSettingsInput)
            };

            StreamItem streamItem = new StreamItem();
            streamItem.SetStreamInfo(streamItemInfo);

            streamItem.OnUp += StreamItem_OnUp;
            streamItem.OnDown += StreamItem_OnDown;
            streamItem.OnDelete += StreamItem_OnDelete;
            streamItem.OnSelect += StreamItem_OnSelect;
            streamItem.OnSettingsChanged += StreamItem_OnSettingsChanged;

            _streams.Add(key, streamItem);
            _sortedStreamList.Add(streamItem);

            BindItems();
        }

        private void SelectItem(StreamItem streamItem)
        {
            _sortedStreamList.ForEach(item => item.ShowUnselected());
            streamItem.ShowSelected();
        }

        private void SelectItemAfterDelete(int currentIndex)
        {
            if (_sortedStreamList.Count == 0)
            {
                return;
            }

            if (currentIndex == _sortedStreamList.Count)
            {
                currentIndex -= 1;
            }

            if (currentIndex < 0)
            {
                currentIndex = 0;
            }

            AutoScrollPosition = _sortedStreamList[currentIndex].Location;
            SelectItem(_sortedStreamList[currentIndex]);
        }

        private void MoveItem(StreamItem itemToMove, int increment, int limit)
        {
            int currentIndex = _sortedStreamList.IndexOf(itemToMove);
            int newIndex = currentIndex + increment;

            if (increment < 0)
            {
                limit -= 1;
            }

            if (newIndex == limit)
            {
                return;
            }

            _sortedStreamList.Remove(itemToMove);
            _sortedStreamList.Insert(newIndex, itemToMove);

            BindItems();

            AutoScrollPosition = itemToMove.Location;
        }

        private void BindItems()
        {
            Controls.Clear();

            _sortedStreamList.ForEach(streamItem =>
            {
                streamItem.Dock = DockStyle.Top;
                Controls.Add(streamItem);
                streamItem.Show();
                streamItem.BringToFront();
            });
        }

        private List<StreamItemDto> GetAllStreams()
        {
            List<StreamItemDto> selectedStreams =
                _sortedStreamList.Select(streamItem =>
                        streamItem.GetStreamInfo()).ToList();

            return selectedStreams;
        }

        #endregion
    }
}
