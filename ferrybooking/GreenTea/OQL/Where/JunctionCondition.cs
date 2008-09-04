using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using GreenTea.Utils;


namespace GreenTea.OQL
{
    public class JunctionCondition : AbstractCondition
    {
        private IList<ICondition> _coditions = new List<ICondition>();
        private readonly LogicalOP _logicOP;

        public LogicalOP LogicalOP
        {
            get { return _logicOP; }
        }

        public JunctionCondition(LogicalOP logicOP)
        {
            _logicOP = logicOP;
        }

        public IList<ICondition> Conditions
        {
            get { return _coditions; }
        }

        public JunctionCondition AddCondition(ICondition condition)
        {
            _coditions.Add(condition);
            return this;
        }

        public override XmlDocument ToXml()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string ToString()
        {
            return '(' + StringUtils.Join(" " + _logicOP.ToString() + " ", _coditions) + ')';
        }

    }
}
