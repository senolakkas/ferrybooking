using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class RouteOrderPassengerDetail
     {
         public RouteOrderPassengerDetailList GetPassengerList(int bookingId)
         {

             OQL oql = new OQL(typeof(RouteOrderPassengerDetail));
             if (bookingId != 0)
                 oql.AddAssociation("RouteOrder", "ro")
                     .AddCondition(Condition.Eq("ro.BookingID", bookingId));

             return new RouteOrderPassengerDetail().GetList(oql);
         }
     }
}
