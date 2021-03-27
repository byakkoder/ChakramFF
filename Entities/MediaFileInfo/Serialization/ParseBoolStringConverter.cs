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

using Newtonsoft.Json;
using System;

namespace Entities.MediaFileInfo.Serialization
{
    internal class ParseBoolStringConverter : JsonConverter
    {
        #region Properties
        
        public static readonly ParseBoolStringConverter Singleton = new ParseBoolStringConverter(); 

        #endregion

        #region Public Methods

        public override bool CanConvert(Type objectType) => objectType == typeof(bool) || objectType == typeof(bool?);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            
            var value = serializer.Deserialize<string>(reader);
            bool b;
            
            if (Boolean.TryParse(value, out b))
            {
                return b;
            }

            throw new ArgumentException("Cannot unmarshal type bool");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            var convertedValue = (bool)value;
            var boolString = convertedValue ? "true" : "false";
            serializer.Serialize(writer, boolString);
        } 

        #endregion        
    }
}
