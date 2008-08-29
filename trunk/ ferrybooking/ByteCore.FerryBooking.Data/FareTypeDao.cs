using System;
using System.Collections.Generic;
using ByteCore.FerryBooking.Core;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Data
{
    public class FareTypeDao :AbstractNHibernateDao<FareType,System.Int32,FareTypeList>, IFareTypeDao
    {
    }
}
