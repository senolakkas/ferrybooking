using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class Company
     {
         public string FullName
         {
             get
             {
                 return this.CompanyName + " (" + this.CompanyShortName + ")";
             }
         }

         public CompanyList GetAllList()
         {
             OQL oql = new OQL(typeof(Company));
             oql.OrderBy(Company.Properties.CompanyName);
             return new Company().GetList(oql);
         }

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
             company.IsActive = isActive;
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
             company.IsActive = isActive;
             company.Update();
         }

         public void DoDelete(int ID)
         {
             Company company = new Company().GetById(ID, false);
             company.Delete();
         }

         public static Company GetCompanyByShortName(string shortName)
         {
             OQL oql = new OQL(typeof(Company));
             if (string.IsNullOrEmpty(shortName))
                 return null;

             oql.AddCondition(Condition.Eq(Company.Properties.CompanyShortName, shortName));
             CompanyList list = new Company().GetList(oql);
             if (list.Count == 1)
                 return list[0];
             else
                 return null;
         }
     }
}
