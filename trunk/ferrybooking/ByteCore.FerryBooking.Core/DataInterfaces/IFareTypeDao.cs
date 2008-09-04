using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    public interface IFareTypeDao : IDao<FareType, System.Int32, FareTypeList>
    {

    }
}
