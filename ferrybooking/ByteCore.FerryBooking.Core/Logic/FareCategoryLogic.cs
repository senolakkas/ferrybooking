using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class FareCategory
     {
         public static FareCategory GetCategoryByName(string categoryName)
         {
             OQL oql = new OQL(typeof(FareCategory));
             if (!string.IsNullOrEmpty(categoryName))
                 oql.AddCondition(Condition.Eq(FareCategory.Properties.CategoryName, categoryName.Trim()));
             FareCategoryList list = new FareCategory().GetList(oql);
             if (list.Count == 1)
                 return list[0];
             else if (list.Count > 1)
                 throw new Exception("Duplicate Fare Category found.");
             else
                 return null;
         }

     }
}
