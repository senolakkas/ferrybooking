using System;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace GreenTea.DAO
{
    [Serializable]
    public class DomainList<T> : BindingList<T>
    {
        #region Method

        public void AddRange(IList pList)
        {
            foreach (T _item in pList)
            {
                Add(_item);
            }
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
        }

        public DataTable ConvertToDataTable()
        {
            DataTable dt = new DataTable(typeof(T).Name);
            dt = Convert(dt);
            return dt;
        }

        public DataTable ConvertToDataTable(string tblName)
        {
            DataTable dt = new DataTable(tblName);
            dt = Convert(dt);
            return dt;
        }

        private DataTable Convert(DataTable dt)
        {
            foreach (PropertyInfo pi in typeof(T).GetProperties())
            {
                if (pi.PropertyType.IsValueType || pi.PropertyType.Name.ToLower() == "string")
                {
                    Type t = pi.PropertyType.Name.StartsWith("Nullable") ? pi.PropertyType.GetProperty("Value").PropertyType : pi.PropertyType;
                    DataColumn dc = new DataColumn(pi.Name, t);
                    dt.Columns.Add(dc);
                }
            }

            foreach (T entity in this)
            {
                DataRow dr = dt.NewRow();
                foreach (PropertyInfo pi in typeof(T).GetProperties())
                {
                    if (pi.PropertyType.IsValueType || pi.PropertyType.Name.ToLower() == "string")
                    {
                        object value = pi.GetValue(entity, null);
                        dr[pi.Name] = value == null ? DBNull.Value : value;
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
        }
        #endregion


        #region Sorting Support

        private bool _isSorted = false;

        /// <summary>
        /// Support sorting
        /// </summary>
        /// <value></value>
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override bool IsSortedCore
        {
            get { return _isSorted; }
        }

        [NonSerialized]
        private ListSortDirection _currentDirection = ListSortDirection.Ascending;
        [NonSerialized]
        private PropertyDescriptor _currentSortProp = null;

        protected override void ApplySortCore(PropertyDescriptor pProperty, ListSortDirection pDirection)
        {
            // Get list to sort
            List<T> items = this.Items as List<T>;

            // Apply and set the sort, if items to sort
            if (items != null)
            {
                PropertyComparer<T> pc = new PropertyComparer<T>(pProperty, _currentDirection);
                items.Sort(pc);
                SwitchDirection();
                _isSorted = true;
            }

            _currentSortProp = pProperty;

            // Let bound controls know they should refresh their views
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        /// <summary>
        /// Switched from ascending to descending.
        /// </summary>
        /// <param name="pDirection"></param>
        /// <returns></returns>
        private void SwitchDirection()
        {
            if (_currentDirection == ListSortDirection.Ascending)
                _currentDirection = ListSortDirection.Descending;
            else
                _currentDirection = ListSortDirection.Ascending;
        }
        protected override void RemoveSortCore()
        {
            _isSorted = false;
        }


        protected override PropertyDescriptor SortPropertyCore
        {
            get { return _currentSortProp; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return _currentDirection; }
        }


        #endregion
    }
}
