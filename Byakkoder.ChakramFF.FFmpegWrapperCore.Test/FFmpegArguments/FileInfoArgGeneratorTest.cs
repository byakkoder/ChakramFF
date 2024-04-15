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
using Byakkoder.ChakramFF.FFmpegWrapperCore.FFmpegArguments;
using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.FFmpegArguments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Test.FFmpegArguments
{
    [TestClass]
    public class FileInfoArgGeneratorTest
    {
        #region Fields
        
        private ISingleArgGenerator<FileInfoArg> _fileInfoArgumentBuilder; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _fileInfoArgumentBuilder = new FileInfoArgGenerator();
        }

        #endregion

        #region Test Method
        
        [TestMethod]
        public void BuildFileInfoArgTest()
        {
            #region Arrange

            FileInfoArg fileInfoArg = new FileInfoArg
            {
                FilePath = "C:\\MyFile.mp4"
            };

            string expectedArg = string.Format("-v error -show_format -of json=c=1 -show_streams \"{0}\"", fileInfoArg.FilePath);

            #endregion

            #region Act

            string argument = _fileInfoArgumentBuilder.Generate(fileInfoArg);

            #endregion

            #region Assert

            Assert.AreEqual(argument, expectedArg);

            #endregion
        } 

        #endregion
    }
}
