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

using System.Collections.Generic;
using Byakkoder.ChakramFF.Entities;
using Byakkoder.ChakramFF.FFmpegWrapperCore.FFmpegResponse;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.FFmpegResponse;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Test.FFmpegResponse
{
    [TestClass]
    public class FFmpegResponseBuilderTest
    {
        #region Fields
        
        private IFFmpegResponseBuilder _fFFmpegResponseBuilder;
        private Mock<IPropertiesDictBuilder> _propertiesDictBuilder;
        private Mock<IFFmpegResponseMapper> _fFmpegResponseMapper; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _propertiesDictBuilder = new Mock<IPropertiesDictBuilder>();
            _fFmpegResponseMapper = new Mock<IFFmpegResponseMapper>();

            _fFFmpegResponseBuilder = new FFmpegResponseBuilder(_propertiesDictBuilder.Object, _fFmpegResponseMapper.Object);
        }

        #endregion

        #region Test Methods
        
        [TestMethod]
        public void BuildTest()
        {
            #region Arrange

            string ffmpegOutputLine = "frame=testData";
            FFmpegResponseInfo expectedFFmpegResponse = new FFmpegResponseInfo();
            Dictionary<string, string> expectedPropDict = new Dictionary<string, string>();

            _propertiesDictBuilder.Setup(x => x.Build(ffmpegOutputLine)).Returns(expectedPropDict);
            _fFmpegResponseMapper.Setup(x => x.Map(expectedPropDict)).Returns(expectedFFmpegResponse);

            #endregion

            #region Act

            FFmpegResponseInfo response = _fFFmpegResponseBuilder.Build(ffmpegOutputLine);

            #endregion

            #region Assert

            Assert.AreEqual(expectedFFmpegResponse, response);
            _propertiesDictBuilder.Verify(x => x.Build(ffmpegOutputLine), Times.Once);
            _propertiesDictBuilder.VerifyNoOtherCalls();
            _fFmpegResponseMapper.Verify(x => x.Map(expectedPropDict), Times.Once);
            _fFmpegResponseMapper.VerifyNoOtherCalls();

            #endregion
        }

        [TestMethod]
        public void AvoidFrameLineTest()
        {
            #region Arrange
            
            string ffmpegOutputLine = "testData";

            #endregion

            #region Act
            
            FFmpegResponseInfo response = _fFFmpegResponseBuilder.Build(ffmpegOutputLine);

            #endregion

            #region Assert
            
            Assert.IsNull(response);
            _propertiesDictBuilder.VerifyNoOtherCalls();
            _fFmpegResponseMapper.VerifyNoOtherCalls(); 

            #endregion
        }

        #endregion
    }
}
