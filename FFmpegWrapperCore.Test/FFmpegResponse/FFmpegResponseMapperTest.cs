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
using System.Collections.Generic;
using Entities;
using FFmpegWrapperCore.FFmpegResponse;
using Interfaces.FFmpegWrapperCore.FFmpegResponse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FFmpegWrapperCore.Test.FFmpegResponse
{
    [TestClass]
    public class FFmpegResponseMapperTest
    {
        #region Fields
        
        private IFFmpegResponseMapper _fFmpegResponseMapper; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _fFmpegResponseMapper = new FFmpegResponseMapper();
        }

        #endregion

        #region Test Methods
        
        [TestMethod]
        public void MapTest()
        {
            #region Arrange
            
            Dictionary<string, string> propertiesDict = new Dictionary<string, string>();
            propertiesDict.Add(FFmpegResponseMapper.Bitrate, "320.0kbits/s");
            propertiesDict.Add(FFmpegResponseMapper.Size, "1536kB");
            propertiesDict.Add(FFmpegResponseMapper.Speed, "15x");
            propertiesDict.Add(FFmpegResponseMapper.Time, "00:01:34.08");

            #endregion

            #region Act
            
            FFmpegResponseInfo fFmpegResponseInfo = _fFmpegResponseMapper.Map(propertiesDict);

            #endregion

            #region Assert
            
            Assert.AreEqual("320.0kbits/s", fFmpegResponseInfo.Bitrate);
            Assert.AreEqual("1536kB", fFmpegResponseInfo.Size);
            Assert.AreEqual("15x", fFmpegResponseInfo.Speed);
            Assert.AreEqual("00:01:34.08", fFmpegResponseInfo.Time); 

            #endregion
        }

        [TestMethod]
        public void MissingDictValueTest()
        {
            #region Arrange

            Dictionary<string, string> propertiesDict = new Dictionary<string, string>();
            propertiesDict.Add(FFmpegResponseMapper.Fps, "30,5");
            propertiesDict.Add(FFmpegResponseMapper.Frame, "25");
            propertiesDict.Add(FFmpegResponseMapper.Q, "20,5");
            propertiesDict.Add(FFmpegResponseMapper.Size, "1536kB");
            propertiesDict.Add(FFmpegResponseMapper.Speed, "15x");
            propertiesDict.Add(FFmpegResponseMapper.Time, "00:01:34.08");

            #endregion

            #region Act and Assert

            Assert.ThrowsException<ArgumentException>(() =>
                _fFmpegResponseMapper.Map(propertiesDict));

            #endregion
        }

        #endregion
    }
}
