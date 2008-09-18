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
     }
}
