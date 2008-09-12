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
     }
}
