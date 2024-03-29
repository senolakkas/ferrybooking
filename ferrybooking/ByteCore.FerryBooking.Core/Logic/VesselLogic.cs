using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class Vessel
     {
         public string FullName
         {
             get 
             {
                 return this.VesselName + " - " + this.VesselCode + "(" + this.Operator.CompanyShortName + ")";
             }
         }

         public VesselList GetAllList()
         {
             OQL oql = new OQL(typeof(Vessel));
             oql.OrderBy(Vessel.Properties.VesselCode);
             return new Vessel().GetList(oql);
         }

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

         public static void DoInsert(Vessel vessel)
         {
             //Vessel vessel = new Vessel();
             //vessel.VesselCode = vesselCode;
             //vessel.VesselName = vesselName;
             //vessel.OperatorId = operatorId;
             vessel.Create();
             //vessel.FareTypes
         }

         public void DoUpdate(int ID, string vesselCode, string vesselName, int operatorId, IList<FareType> ftList)
         {
             Vessel vessel = new Vessel().GetById(ID, true);
             vessel.VesselCode = vesselCode;
             vessel.VesselName = vesselName;
             vessel.OperatorId = operatorId;
             vessel.FareTypes.Clear();
             vessel.Update();
             vessel.FareTypes = ftList;
             vessel.Update();
             
         }

         public void DoDelete(int ID)
         {
             Vessel vessel = new Vessel().GetById(ID, false);
             vessel.Delete();
         }

         public static Vessel GetVesselByCode(string vesselCode)
         {
             OQL oql = new OQL(typeof(Vessel));
             oql.AddCondition(Condition.Eq(Vessel.Properties.VesselCode, vesselCode));
             VesselList list = new Vessel().GetList(oql);
             if (list.Count == 1)
                 return list[0];
             return null;
         }
     }
}
