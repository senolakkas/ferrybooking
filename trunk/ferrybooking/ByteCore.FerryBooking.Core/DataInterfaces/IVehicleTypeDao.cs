using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    public interface IVehicleTypeDao : IDao<VehicleType, System.Int32, VehicleTypeList>
    {

    }
}
