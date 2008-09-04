using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    public interface ICurrencyDao : IDao<Currency, System.Int32, CurrencyList>
    {

    }
}
