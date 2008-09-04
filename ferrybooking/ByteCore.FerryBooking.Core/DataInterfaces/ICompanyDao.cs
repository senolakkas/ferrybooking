using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    public interface ICompanyDao : IDao<Company, System.Int32, CompanyList>
    {

    }
}
