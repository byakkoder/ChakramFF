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
using System.Linq;
using System.Reflection;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.Test.TestHelpers
{
    public static class MockHelper
    {
        #region Public Methods
        
        public static T GetMockInstance<T>()
        {
            T objectToInstance = (T)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(T));

            return objectToInstance;
        }

        public static Dictionary<string, FieldInfo> GetFieldsInfo<T>()
        {
            FieldInfo[] fields = typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            return fields.ToDictionary(x => x.Name, x => x);
        }

        public static void SetFieldValue<T>(T objectInstance, FieldInfo field, object value)
        {
            field.SetValue(objectInstance, value);
        } 

        #endregion
    }
}
