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

using Byakkoder.ChakramFF.Bootstrapper;
using ChakramFF.Helpers;
using Byakkoder.ChakramFF.Entities;
using Byakkoder.ChakramFF.Entities.Dto;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Linq;

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

        public FrmStreamSettings(
            ILanguageHelper languageHelper
            )
        {
            InitializeComponent();

            _languageHelper = languageHelper;
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
            PreviewStreamHelper previewStreamHelper = DIInitializer.ServiceProvider.GetRequiredService<PreviewStreamHelper>();
            previewStreamHelper.Show(_streamSettings.FileName, _streamSettings.StreamType, _streamSettings.StreamIndex);
        }

        private void BtnPlayFile_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = TxtSourceFile.Text, UseShellExecute = true });
        }

        #endregion

        #region Private Methods

        private void InitializeServices()
        {
            if (_isInitialized)
            {
                return;
            }

            var data = _languageHelper.GetLanguages();
            CboLanguage.DataSource = data;
            CboLanguage.DisplayMember = "FullLanguageDesc";
            CboLanguage.ValueMember = "Code";

            _isInitialized = true;
        }

        #endregion
    }
}
