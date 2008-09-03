using System;
using System.Collections.Generic;
using System.Text;

namespace GreenTea.OQL
{
    public class Association
    {
        private string _alias;
        private string _associationName;
        private JoinMode _joinMode;

        private Association()
        {
        }

        public Association(string associationName, string alias,JoinMode joinMode)
        {
            _associationName = associationName;
            _alias = alias;
            _joinMode = joinMode;
        }

        public string AssociationName
        {
            get { return _associationName; }
        }

        public string Alias
        {
            get { return _alias; }
        }

        public JoinMode JoinMode
        {
            get { return _joinMode; }
        }

        public override string ToString()
        {
            return _joinMode.ToString() + " " + _associationName + (string.IsNullOrEmpty(_alias) ? "" : " " + _alias);
        }


       

    }

    

    
       
}
