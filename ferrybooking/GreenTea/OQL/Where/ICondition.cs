using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace GreenTea.OQL
{
    public interface ICondition
    {
        XmlDocument ToXml();
    }
}
