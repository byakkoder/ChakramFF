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
using ChakramFF.Mappers;
using ChakramFF.Properties;
using Entities.Dto;
using Entities.FFmpegArgs;
using Interfaces.FFmpegWrapperCore.Conversion;
using Interfaces.FFmpegWrapperCore.Helpers;
using Interfaces.FFmpegWrapperCore.MediaMetadata;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ChakramFF.Forms
{
    public partial class FrmMerge : Form
    {
        #region Fields
        
        private IMerger _merger;
        private IVideoInfoHelper _infoHelper;
        private IMediaInfoBuilder _mediaInfoBuilder;

        private MediaInfoDto _targetMediaInfoModel;

        #endregion

        #region Constructor

        public FrmMerge()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods
        
        public void Abort()
        {
            if (BtnAbort.Enabled)
            {
                BtnAbort.PerformClick();
            }
        } 

        #endregion

        #region Form Events

        private void FrmMerge_Load(object sender, EventArgs e)
        {
            InitializeServices();

            OfdAddStreams.Filter = Resources.FileTypes;
        }

        #endregion

        #region Control Events
        
        private void BtnAddStreams_Click(object sender, EventArgs e)
        {
            if (OfdAddStreams.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            OfdAddStreams.FileNames.ToList().ForEach(filePath =>
                streamList1.AddStreams(_infoHelper.GetVideoInfo(new FileInfoArg { FilePath = filePath })));
        }

        private void BtnShowDetails_Click(object sender, EventArgs e)
        {
            if (TxtConsole.Visible)
            {
                BtnShowDetails.Text = "Show Details >>";
                TxtConsole.Hide();
            }
            else
            {
                BtnShowDetails.Text = "Hide Details <<";
                TxtConsole.Show();
            }
        }

        private void BtnSelectTarget_Click(object sender, EventArgs e)
        {
            if (SfdTargetFile.ShowDialog(this) != DialogResult.OK ||
                TxtTarget.Text == SfdTargetFile.FileName)
            {
                return;
            }

            TxtTarget.Text = SfdTargetFile.FileName;
            BtnPlayTarget.Enabled = false;
        }

        private async void BtnMerge_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtTarget.Text))
                {
                    MessageBox.Show("Missing target file path.", "Mandatory field", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                List<StreamItemDto> selectedStreams = streamList1.GetSelectedStreams();

                if (selectedStreams.Count == 0)
                {
                    MessageBox.Show("Missing streams to merge.", "Missing streams", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                MergeArgs mergeInfo = StreamToMergeInfoMapper.Map(selectedStreams);
                mergeInfo.OutputFile = TxtTarget.Text;
                mergeInfo.Duration = selectedStreams.Max(stream => Convert.ToSingle(stream.MediaFormat.Duration)) / 1000f / 1000f;

                DisableUI();
                TxtConsole.Clear();

                await Task.Run(() => _merger.Merge(mergeInfo));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An internal error has ocurred: {ex.Message}", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnableUI();
            }
        }

        private void BtnPlayTarget_Click(object sender, EventArgs e)
        {
            Process.Start(TxtTarget.Text);
        }

        private void BtnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                _merger.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An internal error has ocurred: {ex.Message}", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EnableUI();
                PbProgress.Value = 0;
                BtnPlayTarget.Enabled = false;
            }
        }

        private void BtnShowTargetInfo_Click(object sender, EventArgs e)
        {
            FrmMediaInfo frmMediaInfo = new FrmMediaInfo();
            frmMediaInfo.SetMediaInfo(_targetMediaInfoModel.MediaInfo);
            frmMediaInfo.ShowDialog();
        }

        #endregion

        #region Merger Events

        private void Merger_OnCommandSent(string obj)
        {
            this.Invoke((MethodInvoker)delegate
            {
                TxtConsole.AppendText(obj);
                TxtConsole.AppendText(Environment.NewLine);
                TxtConsole.AppendText(Environment.NewLine);
            });
        }

        private void Merger_OnEndProgress()
        {
            this.Invoke((MethodInvoker)delegate
            {
                EnableUI();
                BtnPlayTarget.Enabled = true;

                if (MessageBox.Show("¿Do you want to play the generated video?", "Done!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Process.Start(TxtTarget.Text);
                }

                _targetMediaInfoModel = _mediaInfoBuilder.BuildMediaInfo(new FileInfoArg { FilePath = TxtTarget.Text });
            });
        }

        private void Merger_OnProgress(int percent)
        {
            this.Invoke((MethodInvoker)delegate
            {
                PbProgress.Value = percent;
            });
        }

        private void Merger_OnErrorReceived(string obj)
        {
            this.Invoke((MethodInvoker)delegate
            {
                TxtConsole.AppendText(obj);
                TxtConsole.AppendText(Environment.NewLine);
            });
        }

        private void Merger_OnDataReceived(string obj)
        {
            this.Invoke((MethodInvoker)delegate
            {
                TxtConsole.AppendText(obj);
                TxtConsole.AppendText(Environment.NewLine);
            });
        }

        #endregion

        #region Private Methods

        private void InitializeServices()
        {
            _mediaInfoBuilder = DIContainerManager.GetContainer().Resolve<IMediaInfoBuilder>();
            _infoHelper = DIContainerManager.GetContainer().Resolve<IVideoInfoHelper>();
            _merger = DIContainerManager.GetContainer().Resolve<IMerger>();

            _merger.OnDataReceived += Merger_OnDataReceived;
            _merger.OnErrorReceived += Merger_OnErrorReceived;
            _merger.OnProgress += Merger_OnProgress;
            _merger.OnEndProgress += Merger_OnEndProgress;
            _merger.OnCommandSent += Merger_OnCommandSent;
        }

        private void EnableUI()
        {
            BtnAddStreams.Enabled = true;
            streamList1.Enabled = true;
            BtnSelectTarget.Enabled = true;
            BtnPlayTarget.Enabled = true;
            BtnMerge.Enabled = true;
            BtnAbort.Enabled = false;
            BtnShowTargetInfo.Enabled = true;
        }

        private void DisableUI()
        {
            BtnAddStreams.Enabled = false;
            streamList1.Enabled = false;
            BtnSelectTarget.Enabled = false;
            BtnPlayTarget.Enabled = false;
            BtnMerge.Enabled = false;
            BtnAbort.Enabled = true;
            BtnShowTargetInfo.Enabled = false;
        }

        #endregion
    }
}
