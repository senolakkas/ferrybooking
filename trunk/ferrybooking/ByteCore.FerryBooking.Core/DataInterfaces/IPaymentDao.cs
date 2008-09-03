using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    public interface IPaymentDao : IDao<Payment, System.Int32, PaymentList>
    {

    }
}
