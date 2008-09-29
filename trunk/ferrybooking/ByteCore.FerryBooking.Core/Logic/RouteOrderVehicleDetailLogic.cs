using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class RouteOrderVehicleDetail
     {
         public RouteOrderVehicleDetailList GetVehicleListByRoute(int routeOrderId)
         {
             OQL oql = new OQL(typeof(RouteOrderVehicleDetail));
             RouteOrderVehicleDetail v = new RouteOrderVehicleDetail();
             oql.AddAssociation("RouteOrderDetail", "rod")
                 .AddCondition(Condition.Eq("rod.RouteOrderID", routeOrderId));
             oql.AddAssociation("RouteOrderDetail.FareType", "ft")
                 .AddCondition(Condition.Eq("ft.CategoryId", 2));
             return new RouteOrderVehicleDetail().GetList(oql);
         }
     }
}
