using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    public interface IBookingDao : IDao<Booking, System.Int32, BookingList>
    {

    }
}
