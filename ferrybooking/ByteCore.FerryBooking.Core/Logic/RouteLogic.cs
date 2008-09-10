using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class Route
     {
         public string FullName
         {
             get
             {
                 return this.DeparturePortId + " - " + this.ArriavlPortId + "(" + this.Operator.CompanyShortName + ")";
             }
         }

         public RouteList GetRouteList(int operatorId)
         {
             OQL oql = new OQL(typeof(Route));
             if (operatorId != 0)
                 oql.AddCondition(Condition.Eq(Route.Properties.OperatorId, operatorId));

             oql.OrderBy(Route.Properties.DeparturePortId)
                 .OrderBy(Route.Properties.ArriavlPortId);

             return new Route().GetList(oql);
         }

         public static void DoInsert(Route route)
         {
             route.Create();
         }

         public void DoUpdate(int ID, int operatorId, string departurePortId, string arrivalPortId)
         {
             Route route = new Route().GetById(ID, true);
             route.OperatorId = operatorId;
             route.DeparturePortId = departurePortId;
             route.ArriavlPortId = arrivalPortId;
             route.Update();
         }

         public void DoDelete(int ID)
         {
             Route route = new Route().GetById(ID, false);
             route.Delete();
         }

         public static Route GetRouteByPortId(string depPortId, string arrPortId, int operatorId)
         {
             OQL oql = new OQL(typeof(Route));
             if (string.IsNullOrEmpty(depPortId) || string.IsNullOrEmpty(arrPortId) || operatorId <= 0)
                 return null;
             
             oql.AddCondition(Condition.Eq(Route.Properties.OperatorId, operatorId));
             oql.AddCondition(Condition.Eq(Route.Properties.DeparturePortId, depPortId));
             oql.AddCondition(Condition.Eq(Route.Properties.ArriavlPortId, arrPortId));

             RouteList list = new Route().GetList(oql);
             if (list.Count == 1)
                 return list[0];
             else
                 return null;
         }
     }
}
