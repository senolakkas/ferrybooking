using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class Vessel
     {
         public VesselList GetVesselList(int operatorId, string vesselCode)
         {
             OQL oql = new OQL(typeof(Vessel));
             if (operatorId != 0)
                 oql.AddCondition(Condition.Eq(Vessel.Properties.OperatorId, operatorId));
             if (!string.IsNullOrEmpty(vesselCode))
                 oql.AddCondition(Condition.Like(Vessel.Properties.VesselCode, vesselCode, LikeMode.Start));

             oql.OrderBy(Vessel.Properties.VesselCode);

             return new Vessel().GetList(oql);
         }

         public void DoInsert(string vesselCode, string vesselName, int operatorId)
         {
             Vessel vessel = new Vessel();
             vessel.VesselCode = vesselCode;
             vessel.VesselName = vesselName;
             vessel.OperatorId = operatorId;
             vessel.Create();
             //vessel.FareTypes
         }

         public void DoUpdate(int ID, string vesselCode, string vesselName, int operatorId)
         {
             Vessel vessel = new Vessel().GetById(ID, true);
             vessel.VesselCode = vesselCode;
             vessel.VesselName = vesselName;
             vessel.OperatorId = operatorId;
             vessel.Update();
         }

         public void DoDelete(int ID)
         {
             Vessel vessel = new Vessel().GetById(ID, false);
             vessel.Delete();
         }
     }
}
