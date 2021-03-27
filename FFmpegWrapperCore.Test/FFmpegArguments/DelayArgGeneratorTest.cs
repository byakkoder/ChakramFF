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
using Entities.FFmpegArgs;
using FFmpegWrapperCore.FFmpegArguments;
using Interfaces.FFmpegWrapperCore.FFmpegArguments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FFmpegWrapperCore.Test.FFmpegArguments
{
    [TestClass]
    public class DelayArgGeneratorTest
    {
        #region Fields
        
        private ISingleArgGenerator<DelayArg> _delayArgumentBuilder; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _delayArgumentBuilder = new DelayArgGenerator();
        }

        #endregion

        #region Test Methods
        
        [TestMethod]
        public void BuildTest()
        {
            DelayArg delayArg = new DelayArg { Delay = 3.7 };

            string argument = _delayArgumentBuilder.Generate(delayArg);

            Assert.AreEqual("-itsoffset 3.7", argument);
        }

        [TestMethod]
        public void WrongDelayTest()
        {
            DelayArg delayArg = new DelayArg();

            Assert.ThrowsException<ArgumentException>(() => _delayArgumentBuilder.Generate(delayArg));
        } 

        #endregion
    }
}
