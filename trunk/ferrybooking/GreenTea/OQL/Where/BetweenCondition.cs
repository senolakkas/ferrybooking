using System;
using System.Collections.Generic;
using System.Text;

namespace GreenTea.OQL
{
    [Serializable]
    public class BetweenCondition : AbstractCondition
    {
        private readonly string _propertyName;
		private readonly object _lo;
		private readonly object _hi;

		/// <summary>
		/// Initialize a new instance of the <see cref="BetweenExpression" /> class for
		/// the named Property.
		/// </summary>
		/// <param name="propertyName">The name of the Property of the Class.</param>
		/// <param name="lo">The low value for the BetweenExpression.</param>
		/// <param name="hi">The high value for the BetweenExpression.</param>
        public BetweenCondition(string propertyName, object lo, object hi)
		{
			_propertyName = propertyName;
			_lo = lo;
			_hi = hi;
		}

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public object LowValue
        {
            get { return _lo; }
        }

        public object HightValue
        {
            get { return _hi; }
        }

        public override System.Xml.XmlDocument ToXml()
        {
            throw new Exception("The method or operation is not implemented.");
        }
        		
		/// <summary></summary>
		public override string ToString()
		{
			return _propertyName + " between '" + _lo + "' and '" + _hi + "'";
		}
    }
}
