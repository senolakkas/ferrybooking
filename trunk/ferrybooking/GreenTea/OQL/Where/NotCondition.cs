using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace GreenTea.OQL
{
    [Serializable]
    public class NotCondition : AbstractCondition
    {
        ICondition _condition;

        public NotCondition(ICondition condition)
        {
            _condition = condition;
        }

        public ICondition Condition
        {
            get { return _condition; }
        }

        public override string ToString()
        {
            return "Not " + _condition.ToString();
        }

        public override XmlDocument ToXml()
        {
            throw new Exception("The method or operation is not implemented.");
        }

    }
}
