using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class RouteOrder
     {
         public RouteOrderList GetRouteOrderList(int bookingId)
         {
             OQL oql = new OQL(typeof(RouteOrder));
             oql.AddCondition(Condition.Eq(RouteOrder.Properties.BookingID, bookingId));
             oql.OrderBy(RouteOrder.Properties.IsPrimary);
             oql.OrderBy(RouteOrder.Properties.ID);
             return new RouteOrder().GetList(oql);
         }
     }
}
