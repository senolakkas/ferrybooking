using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class FareItem
     {
         public static void DoInsert(FareItem fareItem)
         {
             fareItem.Create();
         }

         public void DoUpdate(int ID, int fareTypeId, int rangeStart, int rangeEnd, decimal amount, decimal byFootAmount)
         {
             FareItem fareItem = new FareItem().GetById(ID, true);
             fareItem.FareTypeId = fareTypeId;
             fareItem.RangeStart = rangeStart;
             fareItem.RangeEnd = rangeEnd;
             fareItem.Amount = amount;
             fareItem.ByFootAmount = byFootAmount;
             fareItem.Update();
         }

         public void DoDelete(int ID)
         {
             FareItem fareItem = new FareItem().GetById(ID, false);
             fareItem.Delete();
         }

         public static FareItem GetFareItemByValues(int fareTypeId, int fareId, int rangeStart, int rangeEnd, decimal amount)
         {
             OQL oql = new OQL(typeof(FareItem));
             oql.AddCondition(Condition.Eq(FareItem.Properties.FareTypeId, fareTypeId));
             oql.AddCondition(Condition.Eq(FareItem.Properties.FareId, fareId));
             oql.AddCondition(Condition.Eq(FareItem.Properties.RangeStart, rangeStart));
             oql.AddCondition(Condition.Eq(FareItem.Properties.RangeEnd, rangeEnd));
             oql.AddCondition(Condition.Eq(FareItem.Properties.Amount, amount));

             FareItemList list = new FareItem().GetList(oql);
             if (list.Count == 1)
                 return list[0];
             else if (list.Count > 1)
                 throw new Exception("Duplicate FareItem Found");
             else
                 return null;
         }

         public FareItemList GetFareItemList(int categoryId, int fareId)
         {
             OQL oql = new OQL(typeof(FareItem));
             if (categoryId != 0)
                 oql.AddAssociation("FareType", "ft")
                     .AddCondition(Condition.Eq("ft.CategoryId", categoryId));
             if (fareId != 0)
                 oql.AddCondition(Condition.Eq(FareItem.Properties.FareId, fareId));

             return new FareItem().GetList(oql);
         }
     }
}
