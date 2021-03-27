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

using Bootstrapper;
using Interfaces.FFmpegWrapperCore.ChakramSettings;
using System;
using System.Windows.Forms;
using Unity;

namespace ChakramFF
{
    public partial class FrmSettings : Form
    {
        #region Fields

        private IChakramSettingsSingleton _chakramSettingsSingleton;
        private IFFmpegSettingsValidator _fFmpegSettingsValidator;
        private ISaveSettingsManager _saveSettingsManager;
        private ISettingsCleaner _settingsCleaner;

        #endregion

        #region Constructor

        public FrmSettings()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Events
        
        private void FrmSettings_Load(object sender, EventArgs e)
        {
            _chakramSettingsSingleton = DIContainerManager.GetContainer().Resolve<IChakramSettingsSingleton>();
            _fFmpegSettingsValidator = DIContainerManager.GetContainer().Resolve<IFFmpegSettingsValidator>();
            _saveSettingsManager = DIContainerManager.GetContainer().Resolve<ISaveSettingsManager>();
            _settingsCleaner = DIContainerManager.GetContainer().Resolve<ISettingsCleaner>();

            TxtFFmpegPath.Text = _chakramSettingsSingleton.ChakramSettings.FFmpegRootPath;
            FbdFFmpegPath.SelectedPath = TxtFFmpegPath.Text;
        } 

        #endregion

        #region Control Events
        
        private void BtnFFmpegPath_Click(object sender, EventArgs e)
        {
            if (FbdFFmpegPath.ShowDialog(this) == DialogResult.OK)
            {
                TxtFFmpegPath.Text = FbdFFmpegPath.SelectedPath;

                _chakramSettingsSingleton.ChakramSettings.FFmpegRootPath = TxtFFmpegPath.Text;

                if (_fFmpegSettingsValidator.HasValidSettings())
                {
                    _saveSettingsManager.Save();
                    MessageBox.Show("FFmpeg path has been configured successfully!", "FFmpeg Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("FFmpeg path is not valid", "FFmpeg Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnCleanSettings_Click(object sender, EventArgs e)
        {
            _settingsCleaner.Clear();

            TxtFFmpegPath.Clear();
            FbdFFmpegPath.SelectedPath = null;
        }

        #endregion
    }
}
