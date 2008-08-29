using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    public interface IVesselDao : IDao<Vessel, System.Int32, VesselList>
    {

    }
}
