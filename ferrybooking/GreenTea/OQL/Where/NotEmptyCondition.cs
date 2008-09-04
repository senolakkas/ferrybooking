using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace GreenTea.OQL
{
    public class NotEmptyCondition : AbstractCondition
    {
        private readonly string _propertyName;

        public NotEmptyCondition(string propertyName)
        {
            _propertyName = propertyName;
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public override XmlDocument ToXml()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string ToString()
        {
            return _propertyName + " is not Empty";
        }
    }
}
