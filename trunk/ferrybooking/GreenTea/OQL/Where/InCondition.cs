using System;
using System.Collections.Generic;
using System.Text;
using GreenTea.Utils;

namespace GreenTea.OQL
{
    [Serializable]
    public class InCondition : AbstractCondition
    {
        private readonly string _propertyName;
        private readonly object[] _values;

        public InCondition(string propertyName, object[] values)
		{
			_propertyName = propertyName;
			_values = values;
		}

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public object[] Values
        {
            get { return _values; }
        }

        public override System.Xml.XmlDocument ToXml()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string ToString()
        {
            return _propertyName + " in (" + StringUtils.ToString(_values) + ")";
        }
    }
}
