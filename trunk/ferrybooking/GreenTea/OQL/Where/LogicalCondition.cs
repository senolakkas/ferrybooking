using System;
using System.Collections.Generic;
using System.Text;

namespace GreenTea.OQL
{
    [Serializable]
    public class LogicalCondition: AbstractCondition
    {
        private ICondition _lhs;
        private ICondition _rhs;
        private LogicalOP _lop;

        public LogicalCondition(ICondition lhs, ICondition rhs, LogicalOP lop)
        {
            _lhs = lhs;
            _rhs = rhs;
            _lop = lop;
        }

        public ICondition LeftHandSide
        {
            get { return _lhs; }
        }

        public ICondition RightHandSide
        {
            get { return _rhs; }
        }

        public LogicalOP Op
        {
            get { return _lop; }
        }

        public override System.Xml.XmlDocument ToXml()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string ToString()
        {
            return '(' + _lhs.ToString() + ' ' + Op + ' ' + _rhs.ToString() + ')';
        }


    }
}
