using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class Port
     {
         public PortList GetPortList(string portName)
         {
             OQL oql = new OQL(typeof(Port));
             if (!string.IsNullOrEmpty(portName))
                 oql.AddCondition(Condition.Like(Port.Properties.PortName, portName, LikeMode.Start));

             return new Port().GetList(oql);
         }
     }
}
