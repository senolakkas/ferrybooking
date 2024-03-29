using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class VehicleType
     {
         public static void DoInsert(VehicleType vehicleType)
         {
             vehicleType.Create();
         }

         public static VehicleType GetByVehicleTypeId(int vehicleTypeId)
         {
             return new VehicleType().GetById(vehicleTypeId, false);
         }

     }
}
