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
using FFmpegWrapperCore.FFmpegResponse;
using Interfaces.FFmpegWrapperCore.FFmpegResponse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FFmpegWrapperCore.Test.FFmpegResponse
{
    [TestClass]
    public class PropertiesDictBuilderTest
    {
        #region Fields
        
        private IPropertiesDictBuilder _propertiesDictBuilder; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _propertiesDictBuilder = new PropertiesDictBuilder();
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void BuildTest()
        {
            #region Arrange

            string fFmpegOutputLine = "frame=  545 fps=272 q=28.0 size=    1536kB time=00:00:22.03 bitrate= 571.0kbits/s speed=  11x    ";

            #endregion

            #region Act

            Dictionary<string, string> propertiesDict = _propertiesDictBuilder.Build(fFmpegOutputLine);

            #endregion

            #region Assert

            Assert.AreEqual(7, propertiesDict.Count);
            Assert.IsTrue(propertiesDict.ContainsKey("frame"));
            Assert.AreEqual("545", propertiesDict["frame"]);
            Assert.IsTrue(propertiesDict.ContainsKey("fps"));
            Assert.AreEqual("272", propertiesDict["fps"]);
            Assert.IsTrue(propertiesDict.ContainsKey("q"));
            Assert.AreEqual("28.0", propertiesDict["q"]);
            Assert.IsTrue(propertiesDict.ContainsKey("size"));
            Assert.AreEqual("1536kB", propertiesDict["size"]);
            Assert.IsTrue(propertiesDict.ContainsKey("time"));
            Assert.AreEqual("00:00:22.03", propertiesDict["time"]);
            Assert.IsTrue(propertiesDict.ContainsKey("bitrate"));
            Assert.AreEqual("571.0kbits/s", propertiesDict["bitrate"]);
            Assert.IsTrue(propertiesDict.ContainsKey("speed"));
            Assert.AreEqual("11x", propertiesDict["speed"]);

            #endregion
        }

        [TestMethod]
        public void FixLsizeTest()
        {
            #region Arrange

            string fFmpegOutputLine = "frame=  545 fps=272 q=28.0 Lsize=    1536kB time=00:00:22.03 bitrate= 571.0kbits/s speed=  11x    ";

            #endregion

            #region Act

            Dictionary<string, string> propertiesDict = _propertiesDictBuilder.Build(fFmpegOutputLine);

            #endregion

            #region Assert
            
            Assert.IsFalse(propertiesDict.ContainsKey("Lsize"));
            Assert.IsTrue(propertiesDict.ContainsKey("size"));
            Assert.AreEqual("1536kB", propertiesDict["size"]);
            Assert.AreEqual(7, propertiesDict.Count);

            #endregion
        }

        [TestMethod]
        public void NotValidOutputTest()
        {
            #region Arrange

            string fFmpegOutputLine = null;

            #endregion

            #region Act and Assert

            Assert.ThrowsException<ArgumentException>(() =>
                _propertiesDictBuilder.Build(fFmpegOutputLine));

            #endregion
        }

        [TestMethod]
        public void EmptyOutputTest()
        {
            #region Arrange

            string fFmpegOutputLine = string.Empty;

            #endregion

            #region Act

            Dictionary<string, string> propertiesDict = _propertiesDictBuilder.Build(fFmpegOutputLine);

            #endregion

            #region Assert

            Assert.IsNotNull(propertiesDict);
            Assert.AreEqual(0, propertiesDict.Count);            

            #endregion
        }

        #endregion
    }
}
