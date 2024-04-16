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
        
        public void SetDataObject(object dataObject)
        {
            List<PropertyInfo> properties = new List<PropertyInfo>(dataObject.GetType().GetProperties());
            properties.ForEach(property => SetProperty(property, dataObject));
        }

        #endregion

        #region Private Methods
        
        private void SetProperty(PropertyInfo property, object dataObject)
        {
            PropertyVisualizer propertyVisualizer = new PropertyVisualizer();
            object propertyValue = property.GetValue(dataObject);
            string value = propertyValue != null ? propertyValue.ToString() : string.Empty;
            propertyVisualizer.SetData(property.Name, value);
            propertyVisualizer.Dock = DockStyle.Top;
            this.Controls.Add(propertyVisualizer);
            propertyVisualizer.BringToFront();
        } 

        #endregion
    }
}
