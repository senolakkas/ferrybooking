using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class Fare
     {
         public Company company
         {
             get
             {
                 if (this.RoutesID.HasValue)
                 {
                     Route route = new Route().GetById(this.RoutesID.Value, false);
                     return route.Operator;
                 }
                 return null;
             }
         }

         public FareList GetAllList()
         {
             return new Fare().GetList();
         }

         public FareList GetFareList(int operatorId, int routeId, string startDate, string endDate)
         {
             OQL oql = new OQL(typeof(Fare))
               .AddAssociation("Routes", "r")
               .AddCondition(Condition.Eq("r.OperatorId", operatorId))
               .AddCondition(Condition.Eq(Fare.Properties.RoutesID, routeId));
            
             return new Fare().GetList(oql);
         }

         public void DoInsert(Fare fare)
         {
             fare.Create();
         }

         public void DoUpdate(Fare fare)
         {
             fare.Update();
         }

         public void DoDelete(int ID)
         {
             Fare fare = new Fare().GetById(ID, false);
             fare.Delete();
         }
     }
}
