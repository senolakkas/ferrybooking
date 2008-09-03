using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GreenTea.OQL
{
    public class ExampleCondition : AbstractCondition
    {
        private readonly object _entity;
        private bool _isLikeEnabled;
        private LikeMode _likeMode;

        public override string ToString()
        {
            return "For Example " + _entity.GetType().Name;
        }

        public override System.Xml.XmlDocument ToXml()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ExampleCondition (object entity,bool isLikeEnabled,LikeMode likeMode)
        {
            _entity = entity;
            _isLikeEnabled = isLikeEnabled;
            _likeMode = likeMode;
        }

        public object Entity
        { 
            get { return _entity; } 
        }
        public bool IsLikeEnabled
        {
            get { return _isLikeEnabled; }
        }

        public LikeMode LikeMode
        {
            get { return _likeMode; }
        }

    }
}
