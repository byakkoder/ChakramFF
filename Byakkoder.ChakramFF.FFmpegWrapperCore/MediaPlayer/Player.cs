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

using Byakkoder.ChakramFF.Entities.FFmpegArgs;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.ChakramSettings;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.CommandExecution;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.FFmpegArguments;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.MediaPlayer;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.MediaPlayer
{
    public class Player : IPlayer
    {
        #region Fields

        private readonly IChakramSettingsSingleton _chakramSettingsSingleton;
        private readonly ISingleArgGenerator<PlayerArgs> _playerArgGenerator;
        private readonly ICommandBasicRunner _commandRunner;

        #endregion

        #region Constructor
        
        public Player(
            IChakramSettingsSingleton chakramSettingsSingleton,
            ISingleArgGenerator<PlayerArgs> playerArgGenerator,
            ICommandBasicRunner commandRunner)
        {
            _chakramSettingsSingleton = chakramSettingsSingleton;
            _playerArgGenerator = playerArgGenerator;
            _commandRunner = commandRunner;
        }

        #endregion

        #region Public Methods
        
        public void Play(PlayerArgs playerArgs)
        {
            string arguments = _playerArgGenerator.Generate(playerArgs);
            _commandRunner.Run(_chakramSettingsSingleton.ChakramSettings.FFplayPath, arguments);
        } 

        #endregion
    }
}
