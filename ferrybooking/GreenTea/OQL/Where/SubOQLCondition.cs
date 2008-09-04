using System;
using System.Collections.Generic;
using System.Text;

namespace GreenTea.OQL
{
    public class SubOQLCondition : AbstractCondition
    {
        private OQL _subOQL;
        private SubQueryOP _subQueryOP;
        private SubQueryQuantifier _subQueryQuantifier;
        private string _propertyName;
        private object _value;

        public SubOQLCondition(OQL subOQL, SubQueryOP subQueryOP, SubQueryQuantifier subQueryQuantifier)
        {
            _subOQL = subOQL;
            _subQueryOP = subQueryOP;
            _subQueryQuantifier = subQueryQuantifier;
        }

        public SubOQLCondition(OQL subOQL, SubQueryOP subQueryOP, SubQueryQuantifier subQueryQuantifier,string propertyName,object value)
        {
            _subOQL = subOQL;
            _subQueryOP = subQueryOP;
            _subQueryQuantifier = subQueryQuantifier;
            _propertyName = propertyName;
            _value = value;
        }


        public OQL SubOQL
        {
            get { return _subOQL; }
        }

        public string Propertyname
        {
            get { return _propertyName; }
        }

        public object Value
        {
            get { return _value; }
        }

        public SubQueryOP SubQueryOP
        {
            get { return _subQueryOP; }
        }

        public SubQueryQuantifier SubQueryQuantifier
        {
            get { return _subQueryQuantifier; }
        }

        public override string ToString()
        {
            string quantifierStr = "";
            switch (_subQueryQuantifier)
            {
                case SubQueryQuantifier.None:
                    quantifierStr = "";
                    break;
                case SubQueryQuantifier.Some:
                    quantifierStr = "Some";
                    break;
                case SubQueryQuantifier.All:
                    quantifierStr = "All";
                    break;
                default:
                    quantifierStr = "";
                    break;
            }
            string ret = "\r\n\t" + quantifierStr+ "(\r\n\t" +_subOQL.ToString().Replace("\r\n","\r\n\t")+"\r\n\t)";
            
            switch (_subQueryOP)
            {
                case SubQueryOP.Exists:
                    ret = "Exists" + ret;
                    break;
                case SubQueryOP.NotExists:
                    ret = "Not Exists" + ret;
                    break;
                case SubQueryOP.PropertyIn:
                    ret = _propertyName + " In" + ret;
                    break;
                case SubQueryOP.PropertyNotIn:
                    ret = _propertyName + " Not In" + ret;
                    break;
                case SubQueryOP.PropertyEq:
                    ret = _propertyName + " = " + ret;
                    break;
                case SubQueryOP.PropertyNe:
                    ret = _propertyName + " <>" + ret;
                    break;
                case SubQueryOP.PropertyGt:
                    ret = _propertyName + " >" + ret;
                    break;
                case SubQueryOP.PropertyLt:
                    ret = _propertyName + " <" + ret;
                    break;
                case SubQueryOP.PropertyGe:
                    ret = _propertyName + " >=" + ret;
                    break;
                case SubQueryOP.PropertyLe:
                    ret = _propertyName + " <=" + ret;
                    break;
                case SubQueryOP.ValueIn:
                    ret = "'"+Value.ToString() + "' In" + ret;
                    break;
                case SubQueryOP.ValueNotIn:
                    ret = "'" + Value.ToString() + "' Not In" + ret;
                    break;
                case SubQueryOP.ValueEq:
                    ret = "'" + Value.ToString() + "' =" + ret;
                    break;
                case SubQueryOP.ValueNe:
                    ret = "'" + Value.ToString() + "' <>" + ret;
                    break;
                case SubQueryOP.ValueGt:
                    ret = "'" + Value.ToString() + "' >" + ret;
                    break;
                case SubQueryOP.ValueLt:
                    ret = "'" + Value.ToString() + "' <" + ret;
                    break;
                case SubQueryOP.ValueGe:
                    ret = "'" + Value.ToString() + "' >=" + ret;
                    break;
                case SubQueryOP.ValueLe:
                    ret = "'" + Value.ToString() + "' <" + ret;
                    break;
                default:
                    break;
            }
            return ret;
        }

        public override System.Xml.XmlDocument ToXml()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
