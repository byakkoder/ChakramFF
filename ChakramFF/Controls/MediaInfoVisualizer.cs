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

using System.Windows.Forms;
using Entities.MediaFileInfo;

namespace ChakramFF
{
    public partial class MediaInfoVisualizer : UserControl
    {
        #region Contructor
        
        public MediaInfoVisualizer()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods
        
        public void SetMediaInfo(MediaInfo mediaInfo)
        {
            SetGroupInfo(mediaInfo.Format, "Format");
            mediaInfo.Streams.ForEach(stream => SetGroupInfo(stream, "Stream"));
        }

        #endregion

        #region Private Methods
        
        private void SetGroupInfo(object dataObject, string groupName)
        {
            GroupInfoVisualizer groupVisualizer = new GroupInfoVisualizer();
            groupVisualizer.SetData(dataObject, groupName);
            groupVisualizer.Dock = DockStyle.Top;
            Controls.Add(groupVisualizer);
            groupVisualizer.BringToFront();
        } 

        #endregion
    }
}
