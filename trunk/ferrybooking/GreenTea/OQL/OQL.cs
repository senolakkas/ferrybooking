using System;
using System.Collections.Generic;
using System.Text;

namespace GreenTea.OQL
{
    public class OQL
    {
        private Type _domainObjectType;
        //private int _maxResults;
        //private int _firstResult;
        private IList<SelectColumn> _selectColumns = new List<SelectColumn>();
        private IList<SelectColumn> _groupByColumns = new List<SelectColumn>();
        private IList<OrderByColumn> _orderByColumns = new List<OrderByColumn>();
        private IList<ICondition> _conditions = new List<ICondition>();
        private IList<Association> _associations = new List<Association>();
        private bool _isDistinct;

        public Type DomainObjectType
        {
            get { return _domainObjectType; }
        }

        //public int MaxResults
        //{
        //    get { return _maxResults; }
        //}

        //public int FirstResult
        //{
        //    get { return _firstResult; }
        //}

        public IList<SelectColumn> SelectColumns
        {
            get { return _selectColumns; }
        }

        public IList<SelectColumn> GroupByColumns
        {
            get { return _groupByColumns; }
        }

        public IList<OrderByColumn> OrderByColumns
        {
            get { return _orderByColumns; }
        }

        public IList<ICondition> Conditions
        {
            get { return _conditions; }
        }

        public IList<Association> Associations
        {
            get { return _associations; }
        }

        public bool IsDistinct
        {
            get { return _isDistinct; }
        }

        private OQL()
        {
        }

        public OQL(Type domainObjectType)
        {
            _domainObjectType = domainObjectType;
        }


        //public OQL SetMaxResults(int maxResults)
        //{
        //    _maxResults = maxResults;
        //    return this;
        //}

        //public OQL SetFirstResult(int firstResult)
        //{
        //    _firstResult = firstResult;
        //    return this;
        //}

        public OQL AddAssociation(string associationName)
        {
            return AddAssociation(associationName, associationName);
        }

        public OQL AddAssociation(string associationName, string alias)
        {
            return AddAssociation(associationName, alias, JoinMode.InnerJoin);
        }

        public OQL AddAssociation(string associationName, string alias, JoinMode joinMode)
        {
            Association association = new Association(associationName, alias, joinMode);
            _associations.Add(association);
            return this;
        }

        public OQL Distinct()
        {
            _isDistinct = true;
            return this;
        }

        public OQL SelectProperty(string propertyName)
        {
            return SelectProperty(propertyName, null);
        }
        public OQL SelectProperty(string propertyName, string alias)
        {
            _selectColumns.Add(new SelectColumn(SelectOP.Column, propertyName, alias));
            return this;
        }
        

        public OQL SelectRowCount()
        {
            _selectColumns.Add(new SelectColumn(SelectOP.RowCount, null, null));
            return this;
        }

      

        public OQL SelectCount(string propertyName)
        {
            return SelectCount(propertyName, null);
        }

        public OQL SelectCount(string propertyName, string alias)
        {
            _selectColumns.Add(new SelectColumn(SelectOP.RowCount, propertyName, alias));
            return this;
        }

        public OQL SelectDistinctCount(string propertyName)
        {
            return SelectDistinctCount(propertyName, null);
        }

        public OQL SelectDistinctCount(string propertyName, string alias)
        {
            _selectColumns.Add(new SelectColumn(SelectOP.RowCount, propertyName, alias,true));
            return this;
        }


        public OQL SelectMax(string propertyName)
        {
            return SelectMax(propertyName, null);
        }

        public OQL SelectMax(string propertyName, string alias)
        {
            _selectColumns.Add(new SelectColumn(SelectOP.Max, propertyName, alias));
            return this;
        }

       
        public OQL SelectMin(string propertyName)
        {
            return SelectMin(propertyName, null);
        }

        public OQL SelectMin(string propertyName, string alias)
        {
            _selectColumns.Add(new SelectColumn(SelectOP.Min, propertyName, alias));
            return this;
        }

      

        public OQL SelectSum(string propertyName)
        {
            return SelectSum(propertyName, null);
        }

        public OQL SelectSum(string propertyName, string alias)
        {
            _selectColumns.Add(new SelectColumn(SelectOP.Sum, propertyName, alias));
            return this;
        }


        public OQL SelectAvg(string propertyName)
        {
            return SelectAvg(propertyName, null);
        }

        public OQL SelectAvg(string propertyName, string alias)
        {
            _selectColumns.Add(new SelectColumn(SelectOP.Avg, propertyName, alias));
            return this;
        }



        public OQL GroupBy(string propertyName)
        {
            _groupByColumns.Add(new SelectColumn(SelectOP.GroupBy, propertyName, null));
            return this;
        }

        public OQL OrderBy(string propertyName)
        {
            return OrderBy(propertyName, OrderByDirect.Asc);
        }

        public OQL OrderBy(string propertyName, OrderByDirect orderbyDirect)
        {
            _orderByColumns.Add(new OrderByColumn(propertyName,orderbyDirect));
            return this;
        }

        public OQL AddCondition(ICondition condition)
        {
            _conditions.Add(condition);
            return this;
        }

        public override string ToString()
        {
            
            string selectStatement="";
            if (_selectColumns.Count == 0)
            {
                selectStatement = "*";
            }
            else
            {
                foreach (SelectColumn col in _selectColumns)
                {
                    selectStatement +=(string.IsNullOrEmpty(selectStatement)?"":",")+ "\r\n\t" + col.ToString();
                }
            }
            string fromStatement = "\r\nFrom " + _domainObjectType.Name;
            foreach (Association association in _associations)
            {
                fromStatement += "\r\n\t" + association.ToString();
            }

            string whereStatement = "";
            foreach (ICondition condition in _conditions)
            {
                whereStatement += "\r\n\t" + condition.ToString() + " and";
            }


            string groupbyStatement = "";
            foreach (SelectColumn groupbyColumn in _groupByColumns)
            {
                groupbyStatement += groupbyColumn.ToString() + ", ";

            }

            string orderbyStatement = "";
            foreach (OrderByColumn orderbyColumn in _orderByColumns)
            {
                orderbyStatement = orderbyColumn.ToString() + ", ";
            }

            string oqlStr = "";
            oqlStr = "Select " +(_isDistinct?" Distinct ":"") + selectStatement + fromStatement
                + (string.IsNullOrEmpty(whereStatement) ? "" : "\r\nWhere " + whereStatement.Substring(0, whereStatement.Length - 3))
                + (string.IsNullOrEmpty(groupbyStatement) ? "" : "\r\nGroup By " + groupbyStatement.Substring(0, groupbyStatement.Length - 2))
                + (string.IsNullOrEmpty(orderbyStatement) ? "" : "\r\nOrder By " + orderbyStatement.Substring(0, orderbyStatement.Length - 2));

            return oqlStr;
        }

    }
       
}
