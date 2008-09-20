using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class Fare
     {
         public string FullName
         {
             get
             {
                 return this.Routes.DeparturePort.PortName + " - " + this.Routes.ArriavlPort.PortName
                     + " (" + this.StartDate.Value.ToString("MMM d, yyyy") + " - " + this.EndDate.Value.ToString("MMM d, yyyy") + ")";
             }
         }

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
             OQL oql = new OQL(typeof(Fare));
             oql.OrderBy(Fare.Properties.RoutesID).OrderBy(Fare.Properties.StartDate);
             return new Fare().GetList(oql);
         }

         public FareList GetFareList(int operatorId, int routeId, DateTime startDate, DateTime endDate)
         {
             OQL oql = new OQL(typeof(Fare));
             if (operatorId != 0)
                 oql.AddAssociation("Routes", "r")
                     .AddCondition(Condition.Eq("r.OperatorId", operatorId));
             if (routeId != 0)
                 oql.AddCondition(Condition.Eq(Fare.Properties.RoutesID, routeId));
             oql.AddCondition(Condition.Ge(Fare.Properties.StartDate, startDate));
             oql.AddCondition(Condition.Le(Fare.Properties.EndDate, endDate));
            
             return new Fare().GetList(oql);
         }

         public static void DoInsert(Fare fare)
         {
             fare.Create();
         }

         public void DoUpdate(Fare fare)
         {
             fare.Update();
         }

         public void DoUpdate(int ID, int routeId, DateTime startDate, DateTime endDate)
         {
             Fare fare = new Fare().GetById(ID, true);
             fare.RoutesID = routeId;
             fare.StartDate = startDate;
             fare.EndDate = endDate;
             fare.Update();
         }

         public void DoDelete(int ID)
         {
             Fare fare = new Fare().GetById(ID, false);
             fare.Delete();
         }

         public static Fare GetFareByRouteAndDateRange(int routeId, DateTime startDate, DateTime endDate)
         {
             OQL oql = new OQL(typeof(Fare));
             oql.AddCondition(Condition.Eq(Fare.Properties.RoutesID, routeId));
             oql.AddCondition(Condition.Eq(Fare.Properties.StartDate, startDate));
             oql.AddCondition(Condition.Eq(Fare.Properties.EndDate, endDate));

             FareList list = new Fare().GetList(oql);
             if (list.Count == 1)
                 return list[0];
             else if (list.Count > 1)
                 throw new Exception("Duplicate fare record found.");
             else
                 return null;
         }

         public static Fare GetFareForSchedule(int routeId, DateTime depDateTime)
         {
             OQL oql = new OQL(typeof(Fare));
             oql.AddCondition(Condition.Eq(Fare.Properties.RoutesID, routeId));
             oql.AddCondition(Condition.Le(Fare.Properties.StartDate, depDateTime));
             oql.AddCondition(Condition.Ge(Fare.Properties.EndDate, depDateTime));

             FareList list = new Fare().GetList(oql);
             if (list.Count >= 1)
                 return list[0];
             else
                 return null;
         }
     }
}
