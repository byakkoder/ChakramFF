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

using Bootstrapper;
using ChakramFF.Helpers;
using Entities;
using Entities.Dto;
using Interfaces.FFmpegWrapperCore.Helpers;
using System;
using System.Diagnostics;
using System.Linq;
using Unity;

namespace ChakramFF.Forms
{
    public partial class FrmStreamSettings : ChakramFF.FrmBase
    {
        #region Fields
        
        private StreamSettingsDto _streamSettings;
        private ILanguageHelper _languageHelper;
        private bool _isInitialized;

        #endregion

        #region Constructor
        
        public FrmStreamSettings()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods
        
        public void SetSettings(StreamSettingsDto streamSettings)
        {
            if (!_isInitialized)
            {
                InitializeServices();
            }

            TxtSourceFile.Text = streamSettings.FileName;
            TxtTitle.Text = streamSettings.Title;
            NudDelay.Value = Convert.ToDecimal(streamSettings.Delay);
            ChkDefault.Checked = streamSettings.Default;

            if (!string.IsNullOrWhiteSpace(streamSettings.Language) &&
                CboLanguage.Items.OfType<LanguageInfo>().Any(language => language.Code.Equals(streamSettings.Language)))
            {
                CboLanguage.SelectedValue = streamSettings.Language;
            }
            else
            {
                CboLanguage.SelectedValue = "und";
            }

            FormTitle = $"Stream Settings - [{streamSettings.StreamId}]";

            _streamSettings = streamSettings;
        }

        public StreamSettingsDto GetSettings()
        {
            return new StreamSettingsDto
            {
                Title = TxtTitle.Text,
                Delay = Convert.ToDouble(NudDelay.Value),
                Default = ChkDefault.Checked,
                Language = CboLanguage.SelectedValue.ToString(),
                FileName = _streamSettings.FileName,
                StreamId = _streamSettings.StreamId,
                StreamIndex = _streamSettings.StreamIndex,
                StreamType = _streamSettings.StreamType
            };
        }

        #endregion

        #region Form Events

        private void FrmStreamSettings_Load(object sender, EventArgs e)
        {
            InitializeServices();
        }

        #endregion

        #region Control Events
        
        private void ChkDefault_CheckedChanged(object sender, EventArgs e)
        {
            ChkDefault.Text = ChkDefault.Checked ? "Yes" : "No";
        }

        private void BtnPlayStream_Click(object sender, EventArgs e)
        {
            PreviewStreamHelper.Show(_streamSettings.FileName, _streamSettings.StreamType, _streamSettings.StreamIndex);
        }

        private void BtnPlayFile_Click(object sender, EventArgs e)
        {
            Process.Start(TxtSourceFile.Text);
        } 

        #endregion

        #region Private Methods

        private void InitializeServices()
        {
            if (_isInitialized)
            {
                return;
            }

            _languageHelper = DIContainerManager.GetContainer().Resolve<ILanguageHelper>();

            CboLanguage.DataSource = _languageHelper.GetLanguages();
            CboLanguage.DisplayMember = "FullLanguageDesc";
            CboLanguage.ValueMember = "Code";

            _isInitialized = true;
        }

        #endregion
    }
}
