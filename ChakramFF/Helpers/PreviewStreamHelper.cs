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
using Byakkoder.ChakramFF.Entities;
using Byakkoder.ChakramFF.Entities.FFmpegArgs;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.MediaPlayer;

namespace ChakramFF.Helpers
{
    public class PreviewStreamHelper
    {
        #region Fields

        private readonly IPlayer _player;

        #endregion

        #region Constructor

        public PreviewStreamHelper(IPlayer player)
        {
            _player = player;
        }

        #endregion

        #region Public Methods

        public void Show(string filePath, StreamType streamType, int streamIndex)
        {
            IPlayer _player = (IPlayer)DIInitializer.ServiceProvider.GetService(typeof(IPlayer));

            PlayerArgs playerArgs = new PlayerArgs
            {
                FileToPlay = filePath,
                StreamSpecifierArg = new StreamSpecifierArg
                {
                    StreamType = streamType,
                    StreamIndex = streamIndex
                }
            };

            _player.Play(playerArgs);
        }

        #endregion
    }
}
