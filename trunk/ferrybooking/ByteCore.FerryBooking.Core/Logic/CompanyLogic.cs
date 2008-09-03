using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class Company
     {
         public CompanyList GetCompanyList(string companyName)
         {
             OQL oql = new OQL(typeof(Company));
             if (!string.IsNullOrEmpty(companyName))
                 oql.AddCondition(Condition.Like(Company.Properties.CompanyName, companyName, LikeMode.Start));

             return new Company().GetList(oql);
         }
     }
}
