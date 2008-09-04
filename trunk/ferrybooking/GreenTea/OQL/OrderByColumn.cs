using System;
using System.Collections.Generic;
using System.Text;

namespace GreenTea.OQL
{
    public class OrderByColumn
    {
        private string _propertyName;
        private OrderByDirect _orderbyDirect;

        public OrderByColumn(string propertyName, OrderByDirect orderbyDirect)
        {
            _propertyName = propertyName;
            _orderbyDirect = orderbyDirect;
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public OrderByDirect OrderByDirect
        {
            get { return _orderbyDirect; }
        }

        public override string ToString()
        {
            return  _propertyName + " " + _orderbyDirect.ToString();
        }
    }
}
