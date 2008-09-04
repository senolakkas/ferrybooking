using System;
using System.Collections.Generic;
using System.Text;

namespace GreenTea.OQL
{
    public class SelectColumn
    {
        private SelectOP _selectOP;
        private string _propertyName;
        private string _alias;
        private bool _isDistinct;



        public SelectColumn(SelectOP selectOP, string propertyName, string alias) :
            this(selectOP, propertyName, alias, false)
        {
            
        }



        public SelectColumn(SelectOP selectOP, string propertyName, string alias, bool isDistinct)
        {
            _selectOP = selectOP;
            _propertyName = propertyName;
            _alias = alias;
            _isDistinct = isDistinct;
        }

        public SelectOP SelectOP
        {
            get { return _selectOP; }
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public string Alias
        {
            get { return _alias; }
        }


        public bool IsDistinct
        {
            get { return _isDistinct; }
        }

        public override string ToString()
        {
            string ret="";
            switch (SelectOP)
            {
                case SelectOP.Column:
                    ret = PropertyName;
                    break;
                case SelectOP.RowCount:
                    ret = "RowCount(" + (string.IsNullOrEmpty(PropertyName) ? "*" : PropertyName) + ")";
                    break;
                case SelectOP.Sum:
                    ret = "Sum(" + PropertyName + ")";
                    break;
                case SelectOP.Avg:
                    ret = "Avg(" + PropertyName + ")";
                    break;
                case SelectOP.Max:
                    ret = "Max(" + PropertyName + ")";
                    break;
                case SelectOP.Min:
                    ret = "Min(" + PropertyName + ")";
                    break;
                case SelectOP.GroupBy:
                    ret = PropertyName;
                    break;
                default:
                    ret = "";
                    break;
            }

            if (!string.IsNullOrEmpty(Alias))
                ret += (" as " + Alias);

            return ret;

        }
    }
}
