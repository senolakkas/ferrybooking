using System;
using System.Collections.Generic;
using System.Text;

namespace GreenTea.OQL
{
    [Serializable]
    public class LikeCondition : AbstractCondition
    {
        private readonly string _propertyName;
        private readonly object _value;
        private LikeMode _likeMode;

        public LikeCondition(string propertyName, object value)
        {
            _propertyName = propertyName;
            _value = value;
            _likeMode = LikeMode.Start;
        }

        public LikeCondition(string propertyName, object value, LikeMode matchMode)
        {
            _propertyName = propertyName;
            _value = value;
            _likeMode = matchMode; 

        }

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public object Value
        {
            get { return _value; }
        }



        public LikeMode LikeMode
        {
            get { return _likeMode; }
        }

        public override System.Xml.XmlDocument ToXml()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string ToString()
        {
            string likeValue = "";
            switch (_likeMode)
            {
                case LikeMode.Exact:
                    likeValue = _value.ToString();
                    break;
                case LikeMode.Start:
                    likeValue = _value.ToString() + "%";
                    break;
                case LikeMode.End:
                    likeValue = "%" + _value.ToString();
                    break;
                case LikeMode.Anywhere:
                    likeValue = "%" + _value.ToString() + "%";
                    break;
                default:
                    likeValue = "''";
                    break;
            }
            return _propertyName + " Like '" + likeValue+"'";
        }

        

    }
}
