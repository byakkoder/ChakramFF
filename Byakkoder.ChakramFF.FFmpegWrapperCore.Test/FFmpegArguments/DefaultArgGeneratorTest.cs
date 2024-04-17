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
using Byakkoder.ChakramFF.FFmpegWrapperCore.FFmpegArguments;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.FFmpegArguments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Test.FFmpegArguments
{
    [TestClass]
    public class DefaultArgGeneratorTest
    {
        #region Fields
        
        private ISingleArgGenerator<DefaultArg> _defaultStreamArgGenerator;
        private Mock<ISingleArgGenerator<StreamTypeArg>> _streamTypeArgGenerator; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _streamTypeArgGenerator = new Mock<ISingleArgGenerator<StreamTypeArg>>();

            _defaultStreamArgGenerator = new DefaultArgGenerator(_streamTypeArgGenerator.Object);
        }

        #endregion

        #region Test Methods
        
        [TestMethod]
        public void BuildDefaultTest()
        {
            #region Arrange
            
            DefaultArg defaultArg = new DefaultArg
            {
                StreamTypeArg = new StreamTypeArg { StreamType = StreamType.Video },
                StreamIndex = 1,
                Default = true
            };

            _streamTypeArgGenerator.Setup(x => x.Generate(defaultArg.StreamTypeArg)).Returns("v");

            #endregion

            #region Act
            
            string argument = _defaultStreamArgGenerator.Generate(defaultArg);

            #endregion

            #region Assert
            
            Assert.AreEqual("-disposition:v:1 default", argument); 

            #endregion
        }

        [TestMethod]
        public void BuildNoneTest()
        {
            #region Arrange

            DefaultArg defaultArg = new DefaultArg
            {
                StreamTypeArg = new StreamTypeArg { StreamType = StreamType.Video },
                StreamIndex = 1
            };

            _streamTypeArgGenerator.Setup(x => x.Generate(defaultArg.StreamTypeArg)).Returns("v");

            #endregion

            #region Act

            string argument = _defaultStreamArgGenerator.Generate(defaultArg);

            #endregion

            #region Assert

            Assert.AreEqual("-disposition:v:1 none", argument);

            #endregion
        }

        #endregion
    }
}
