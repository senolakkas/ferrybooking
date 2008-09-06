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

             oql.OrderBy(Company.Properties.CompanyName);

             return new Company().GetList(oql);
         }

         public void DoInsert(string name, string shortName, int currencyId, string logoImage, string terms, bool isActive)
         {
             Company company = new Company();
             company.CompanyName = name;
             company.CompanyShortName = shortName;
             if (currencyId != 0)
                 company.CurrencyId = currencyId;
             company.LogoImage = logoImage;
             company.Terms = terms;
             company.IsActive = IsActive;
             company.Create();
         }

         public void DoUpdate(int ID, string name, string shortName, int currencyId, string logoImage, string terms, bool isActive)
         {
             Company company = new Company().GetById(ID, true);
             company.CompanyName = name;
             company.CompanyShortName = shortName;
             if (currencyId != 0)
                 company.CurrencyId = currencyId;
             company.LogoImage = logoImage;
             company.Terms = terms;
             company.IsActive = IsActive;
             company.Update();
         }

         public void DoDelete(int ID)
         {
             Company company = new Company().GetById(ID, false);
             company.Delete();
         }
     }
}