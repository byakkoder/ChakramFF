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

using Byakkoder.ChakramFF.Entities;
using Byakkoder.ChakramFF.Entities.FFmpegArgs;
using Byakkoder.ChakramFF.FFmpegWrapperCore.MediaPlayer;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.ChakramSettings;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.CommandExecution;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.FFmpegArguments;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.MediaPlayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Test.MediaPlayer
{
    [TestClass]
    public class PlayerTest
    {
        #region Fields

        private IPlayer _player = default!;
        private Mock<IChakramSettingsSingleton> _chakramSettingsSingleton = default!;
        private Mock<ISingleArgGenerator<PlayerArgs>> _playerArgGenerator = default!;
        private Mock<ICommandBasicRunner> _commandRunner = default!;

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _chakramSettingsSingleton = new Mock<IChakramSettingsSingleton>();
            _playerArgGenerator = new Mock<ISingleArgGenerator<PlayerArgs>>();
            _commandRunner = new Mock<ICommandBasicRunner>();

            _player = new Player(_chakramSettingsSingleton.Object, _playerArgGenerator.Object, _commandRunner.Object);
        }

        #endregion

        #region Test Methods
        
        [TestMethod]
        public void PlayTest()
        {
            #region Arrange
            
            PlayerArgs playerArgs = new PlayerArgs();

            _chakramSettingsSingleton.Setup(x => x.ChakramSettings).Returns(new ChakramSettingsInfo() { FFmpegRootPath = @"C:\FFmpegPath" });

            #endregion

            #region Act

            _player.Play(playerArgs);

            #endregion

            #region Assert
            
            _playerArgGenerator.Verify(x => x.Generate(playerArgs), Times.Once);
            _playerArgGenerator.VerifyNoOtherCalls();
            _commandRunner.Verify(x => x.Run(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            _commandRunner.VerifyNoOtherCalls(); 

            #endregion
        } 

        #endregion
    }
}
