using System;
using System.Collections.Generic;
using System.Text;

namespace GreenTea.DAO.Transaction
{
    [AttributeUsage(AttributeTargets.Method,Inherited = true)]
    [Serializable]
    public class OpenSessionAttribute: Attribute
    {
        private bool _readOnly = false;

        public OpenSessionAttribute()
        {

        }

        public bool ReadOnly
        {
            get { return _readOnly; }
            set { _readOnly = value; }
        }
    }
}
