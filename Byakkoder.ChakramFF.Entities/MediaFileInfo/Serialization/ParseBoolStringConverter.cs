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

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Byakkoder.ChakramFF.Entities.MediaFileInfo.Serialization
{
    internal class ParseBoolStringConverter : JsonConverter<bool>
    {
        #region Public Methods

        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(bool) || typeToConvert == typeof(bool?);
        }

        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null) return false;

            var value = reader.GetString();

            if (bool.TryParse(value, out bool b))
            {
                return b;
            }

            throw new ArgumentException("Cannot unmarshal type bool");
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value ? "true" : "false");
        }

        #endregion        
    }
}
