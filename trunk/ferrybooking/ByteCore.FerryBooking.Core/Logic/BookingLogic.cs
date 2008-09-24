using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class Booking
     {
         public BookingList GetBookingList(int statusId, DateTime startDate, DateTime endDate)
         {
             OQL oql = new OQL(typeof(Booking));
             if (statusId != 0)
                 oql.AddCondition(Condition.Eq(Booking.Properties.Status, statusId));

             oql.AddCondition(Condition.Ge(Booking.Properties.BookingDate, startDate));
             oql.AddCondition(Condition.Le(Booking.Properties.BookingDate, endDate));

             oql.OrderBy(Booking.Properties.BookingDate, OrderByDirect.Desc);

             return new Booking().GetList(oql);
         }

     }
}
