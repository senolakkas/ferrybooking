using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class Currency
     {
         public CurrencyList GetCurrencyList()
         {
            return new Currency().GetList();
         }
     }
}
