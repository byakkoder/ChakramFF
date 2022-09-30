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
using System.Drawing;
using System.Windows.Forms;
using Entities.Dto;
using System.IO;
using Entities.MediaFileInfo;
using ChakramFF.Helpers;
using ChakramFF.Forms;
using ChakramFF.Bootstrapper;
using Microsoft.Extensions.DependencyInjection;

namespace ChakramFF.Controls
{
    public partial class StreamItem : UserControl
    {
        #region Events
        
        public event Action<StreamItem> OnUp;
        public event Action<StreamItem> OnDown;
        public event Action<StreamItem> OnDelete;
        public event Action<StreamItem> OnSelect;
        public event Action<StreamItemDto> OnSettingsChanged;

        #endregion

        #region Fields

        private StreamItemDto _streamItemDto;

        #endregion

        #region Constructor
        
        public StreamItem()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods
        
        public StreamItemDto GetStreamInfo()
        {
            return _streamItemDto;
        }

        public void SetStreamInfo(StreamItemDto streamItemDto)
        {
            _streamItemDto = streamItemDto;

            LblFileName.Text = new FileInfo(_streamItemDto.MediaFormat.Filename).Name;
            ChkSelectStream.Text = streamItemDto.StreamId;
        }

        public void ShowSelected()
        {
            LblFileName.ForeColor = Color.White;
            LblFileName.Font = new Font(LblFileName.Font, FontStyle.Bold);
        }

        public void ShowUnselected()
        {
            LblFileName.ForeColor = Color.FromArgb(170, 171, 184);
            LblFileName.Font = new Font(LblFileName.Font, FontStyle.Regular);
        }

        #endregion

        #region Control Events

        private void BtnStreamInfo_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this);

            MediaInfo mediaInfo = new MediaInfo
            {
                Format = _streamItemDto.MediaFormat,
                Streams = new List<MediaStream> { _streamItemDto.MediaStream }
            };

            FrmMediaInfo frmMediaInfo = new FrmMediaInfo();
            frmMediaInfo.SetMediaInfo(mediaInfo);
            frmMediaInfo.ShowDialog();
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this);

            PreviewStreamHelper previewStreamHelper = DIInitializer.ServiceProvider.GetRequiredService<PreviewStreamHelper>();
            previewStreamHelper.Show(_streamItemDto.MediaFormat.Filename, _streamItemDto.MediaStream.StreamType, Convert.ToInt32(_streamItemDto.MediaStream.Index));
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this);

            FrmStreamSettings frmStreamSettings = DIInitializer.ServiceProvider.GetRequiredService<FrmStreamSettings>();

            frmStreamSettings.SetSettings(_streamItemDto.StreamSettings);
            
            if (frmStreamSettings.ShowDialog() == DialogResult.OK)
            {
                _streamItemDto.StreamSettings = frmStreamSettings.GetSettings();
                OnSettingsChanged?.Invoke(_streamItemDto);
            }
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this);
            OnUp?.Invoke(this);
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this);
            OnDown?.Invoke(this);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            OnDelete?.Invoke(this);
        }

        private void LblFileName_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this);
        }

        private void ChkSelectStream_CheckedChanged(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this);
            _streamItemDto.IsSelected = ChkSelectStream.Checked;
        }

        private void PanItemContainer_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this);
        } 

        #endregion
    }
}
