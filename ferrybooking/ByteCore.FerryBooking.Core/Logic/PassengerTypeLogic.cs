using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class PassengerType
     {
         public static void DoInsert(PassengerType passengerType)
         {
             passengerType.Create();
         }

         public static PassengerType GetByPassengerTypeId(int passengerTypeId)
         {
             return new PassengerType().GetById(passengerTypeId, false);
         }
     }
}
