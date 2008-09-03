using System;
using System.Collections.Generic;
using System.Text;

namespace GreenTea.OQL
{
    public class PropertyCondition : AbstractCondition
    {
        private string _lhsPropertyName;
        private string _rhsPropertyName;
        private ExpressionOP _expressionOP;

        public string LHSPropertyName
        {
            get { return _lhsPropertyName; }
        }

        public string RHSPropertyName
        {
            get { return _rhsPropertyName; }
        }

        public PropertyCondition(string lhsPropertyName, string rhsPropertyName,ExpressionOP expressionOP)
		{
			_lhsPropertyName = lhsPropertyName;
			_rhsPropertyName = rhsPropertyName;
            _expressionOP = expressionOP;
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
            return _lhsPropertyName + OP + _rhsPropertyName;
        }
    }
}
