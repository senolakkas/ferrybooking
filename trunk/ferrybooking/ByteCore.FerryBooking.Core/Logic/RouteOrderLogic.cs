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

         public decimal RouteTotalAmount
         {
             get
             {
                 decimal total = 0.0m;
                 foreach (RouteOrderDetail item in this.RouteOrderDetails)
                 {
                     total += item.Amount.GetValueOrDefault(0m); 
                 }
                 return total;
             }
         }

         public RouteOrderDetailList GetListByRoute(int categoryId)
         {
             OQL oql = new OQL(typeof(RouteOrderDetail));
             oql.AddAssociation("FareType", "ft")
                 .AddCondition(Condition.Eq("ft.CategoryId", categoryId));
             oql.AddCondition(Condition.Eq(RouteOrderDetail.Properties.RouteOrderID, this.ID));
             return new RouteOrderDetail().GetList(oql);
         }
     }
}
