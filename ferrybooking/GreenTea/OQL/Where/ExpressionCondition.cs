using System;
using System.Collections.Generic;
using System.Text;

namespace GreenTea.OQL
{
    [Serializable]
    public class ExpressionCondition : AbstractCondition
    {
        private readonly string _propertyName;
        private readonly object _value;
        private readonly ExpressionOP _expressionOP;

        public ExpressionCondition(string propertyName, object value,ExpressionOP expressionOP)
        {
            _propertyName = propertyName;
            _value = value;
            _expressionOP = expressionOP;
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public object Value
        {
            get { return _value; }
        }

        public ExpressionOP ExpressionOP
        {
            get { return _expressionOP; }
        }

        public override System.Xml.XmlDocument ToXml()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string ToString()
        {
            string OP;
            switch (_expressionOP)
            {
                case ExpressionOP.Eq:
                    OP = "=";
                    break;
                case ExpressionOP.Ge:
                    OP = ">=";
                    break;
                case ExpressionOP.Gt:
                    OP = ">";
                    break;
                case ExpressionOP.Le:
                    OP = "<=";
                    break;
                case ExpressionOP.Lt:
                    OP = "<";
                    break;
                default:
                    OP = "OP";
                    break;
            }
            return _propertyName + OP +"'"+ _value +"'";
        }

    }
}
