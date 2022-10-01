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
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.Text;

namespace ChakramFF
{
    public partial class ObjectVisualizer : UserControl
    {
        #region Constructor
        
        public ObjectVisualizer()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods
        
        public void SetDataObject(object dataObject, string prefix = null)
        {
            List<PropertyInfo> properties = new List<PropertyInfo>(dataObject.GetType().GetProperties());
            properties.ForEach(property => 
            { 
                if (property.PropertyType.IsPrimitive ||
                property.PropertyType.IsValueType ||
                property.GetValue(dataObject) is IDictionary ||
                property.PropertyType.Namespace.StartsWith("System"))
                {
                    SetProperty(property, dataObject, prefix);
                }
                else
                {
                    SetDataObject(property.GetValue(dataObject), property.Name);
                }
            });
        }

        #endregion

        #region Private Methods
        
        private void SetProperty(PropertyInfo property, object dataObject, string prefix)
        {
            PropertyVisualizer propertyVisualizer = new PropertyVisualizer();
            object propertyValue = property.GetValue(dataObject);
            string value = GetPropertyStringValue(propertyValue);

            string composedName = !string.IsNullOrWhiteSpace(prefix) ? $"{prefix}.{property.Name}" : property.Name;

            propertyVisualizer.SetData(composedName, value);
            propertyVisualizer.Dock = DockStyle.Top;
            this.Controls.Add(propertyVisualizer);
            propertyVisualizer.BringToFront();
        }
        
        private string GetPropertyStringValue(object propertyValue)
        {
            if (propertyValue is IDictionary)
            {
                return GetDictValues((IDictionary)propertyValue);
            }

            return propertyValue != null ? propertyValue.ToString() : string.Empty;
        }

        private string GetDictValues(IDictionary dictionary)
        {
            StringBuilder dictValueBuilder = new StringBuilder();

            foreach (DictionaryEntry dictionaryEntry in dictionary)
            {
                if(dictValueBuilder.Length > 0)
                {
                    dictValueBuilder.Append(", ");
                }

                dictValueBuilder.Append($"{dictionaryEntry.Key.ToString()}: {dictionaryEntry.Value.ToString()}");
            }

            return dictValueBuilder.ToString();
        }

        #endregion
    }
}
