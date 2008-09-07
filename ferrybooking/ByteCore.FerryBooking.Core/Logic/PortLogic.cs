using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class Port
     {
         public PortList GetAllList()
         {
             OQL oql = new OQL(typeof(Port));
             oql.OrderBy(Port.Properties.PortName);
             return new Port().GetList(oql);
         }

         public PortList GetPortList(string portName)
         {
             OQL oql = new OQL(typeof(Port));
             if (!string.IsNullOrEmpty(portName))
                 oql.AddCondition(Condition.Like(Port.Properties.PortName, portName, LikeMode.Start));

             oql.OrderBy(Port.Properties.ID);

             return new Port().GetList(oql);
         }

         public void DoInsert(string ID, string portName)
         {
             Port port = new Port(ID);
             port.PortName = portName;
             port.Create();
         }

         public void DoUpdate(string ID, string portName)
         {
             Port port= new Port().GetById(ID, true);
             port.PortName = portName;
             port.Update();
         }

         public void DoDelete(string ID)
         {
             Port port = new Port().GetById(ID, false);
             port.Delete();
         }
     }
}
