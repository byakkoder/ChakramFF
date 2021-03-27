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
using ChakramFF.Forms;
using Interfaces.FFmpegWrapperCore.ChakramSettings;
using System;
using System.Drawing;
using System.Windows.Forms;
using Unity;

namespace ChakramFF
{
    public partial class FrmMain : FrmBase
    {
        #region Fields

        private IFFmpegSettingsValidator _fFmpegSettingsValidator;
        private FrmSettings _frmSettings;
        private FrmMerge _frmMerge;
        private bool _isProcessing;

        #endregion

        #region Constructor
        
        public FrmMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods

        public void StartProcess()
        {
            _isProcessing = true;

            DisableMenu();
        }

        public void StopProcess()
        {
            _isProcessing = false;

            EnableMenu();
        }

        #endregion

        #region Form Events
        
        private void FrmMain_Load(object sender, EventArgs e)
        {
            _fFmpegSettingsValidator = DIContainerManager.GetContainer().Resolve<IFFmpegSettingsValidator>();
            _frmMerge = new FrmMerge();
            _frmSettings = new FrmSettings();

            ConfigureChildForm(_frmMerge);
            ConfigureChildForm(_frmSettings);

            BtnMerge.PerformClick();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !ExitApp();
        }

        #endregion

        #region Control Events

        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (ExitApp())
            {
                Close();
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            SelectMenuButton(BtnSettings);
            HideForms();
            _frmSettings.Show();
        }

        private void BtnMerge_Click(object sender, EventArgs e)
        {
            if (!IsValidFFmpegPath())
            {
                return;
            }

            SelectMenuButton(BtnMerge);
            HideForms();
            _frmMerge.Show();
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog(this);
        } 

        #endregion

        #region Private Methods

        private void EnableMenu()
        {
            BtnSettings.Enabled = true;
            BtnMerge.Enabled = true;
        }

        private void DisableMenu()
        {
            BtnSettings.Enabled = false;
            BtnMerge.Enabled = false;
        }

        private void ConfigureChildForm(Form form)
        {
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            PanContent.Controls.Add(form);
        }

        private void HideForms()
        {
            foreach (Control form in PanContent.Controls)
            {
                form.Hide();
            }
        }

        private void ClearMenuButtons()
        {
            Color bgColor = Color.FromArgb(28, 42, 53);
            Color foreColor = Color.FromArgb(170, 171, 184);

            foreach (Control button in PanMenu.Controls)
            {
                if (button is Button)
                {
                    button.BackColor = bgColor;
                    button.ForeColor = foreColor;
                }
            }
        }

        private void SelectMenuButton(Button button)
        {
            ClearMenuButtons();

            button.BackColor = Color.FromArgb(23, 30, 36);
            button.ForeColor = Color.White;
        }

        private bool IsValidFFmpegPath()
        {
            if (_fFmpegSettingsValidator.HasValidSettings())
            {
                return true;
            }

            BtnSettings.PerformClick();
            MessageBox.Show("FFmpeg path is not valid or not found. You must set FFmpeg path to use ChakramFF.", "FFmpeg path missing", MessageBoxButtons.OK, MessageBoxIcon.Information);            

            return false;
        }

        private bool ExitApp()
        {
            if (_isProcessing && MessageBox.Show("¿Are you sure stop the current video processing and exit ChakramFF?", "Abort and Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return false;
            }

            _frmMerge.Abort();

            return true;
        }

        #endregion
    }
}
