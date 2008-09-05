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

         public void DoInsert(string portId, string portName)
         {
             Port port = new Port(portId);
             port.PortName = PortName;
             port.Create();
         }

         public void DoUpdate(string portId, string portName)
         {
             Port port= new Port().GetById(portId, true);
             port.PortName = PortName;
             port.Update();
         }

         public void DoDelete(string portId)
         {
             Port port = new Port().GetById(portId, false);
             port.Delete();
         }
     }
}
