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
using Byakkoder.ChakramFF.FFmpegWrapperCore.Helpers;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Test.Helpers
{
    [TestClass]
    public class SecondsTimeConverterTest
    {
        #region Fields
        
        private ISecondsTimeConverter _secondsTimeConverter; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _secondsTimeConverter = new SecondsTimeConverter();
        }

        #endregion

        #region Test Methods
        
        [TestMethod]
        public void ConvertToSecondsTest()
        {
            string timeToConvert = "01:28:37.527";

            float totalSeconds = _secondsTimeConverter.ConvertToSeconds(timeToConvert);

            Assert.AreEqual(5317.527F, totalSeconds);
        }

        [TestMethod]
        public void WrongInputFormatTest()
        {
            string timeToConvert = "28:37.527";

            Assert.ThrowsException<FormatException>(() => _secondsTimeConverter.ConvertToSeconds(timeToConvert));
        }

        [TestMethod]
        public void InvalidTimeTest()
        {
            string timeToConvert = null;

            Assert.ThrowsException<ArgumentException>(() => _secondsTimeConverter.ConvertToSeconds(timeToConvert));
        }

        #endregion
    }
}
