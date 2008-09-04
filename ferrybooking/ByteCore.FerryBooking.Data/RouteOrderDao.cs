using System;
using System.Collections.Generic;
using ByteCore.FerryBooking.Core;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Data
{
    public class RouteOrderDao :AbstractNHibernateDao<RouteOrder,System.Int32,RouteOrderList>, IRouteOrderDao
    {
    }
}
