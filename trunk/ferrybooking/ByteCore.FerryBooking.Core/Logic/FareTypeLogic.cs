using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class FareType
     {
         public FareTypeList GetFareTypeList(int operatorId, int fareCategoryId)
         {
             OQL oql = new OQL(typeof(FareType));
             if (operatorId != 0)
                 oql.AddCondition(Condition.Eq(FareType.Properties.OperatorId, operatorId));
             if (fareCategoryId != 0)
                 oql.AddCondition(Condition.Eq(FareType.Properties.CategoryId, fareCategoryId));

             return new FareType().GetList(oql);
         }

         public string FullFareTypeName
         {
             get 
             {
                 return this.FareTypeName + "(" + this.FareTypeDescription + ")";
             }
         }

         public static FareType GetFareTypeByValue(int operatorId, int categoryId, string fareTypeName)
         {
             OQL oql = new OQL(typeof(FareType));
             if (string.IsNullOrEmpty(fareTypeName) || operatorId <= 0 || categoryId <= 0)
                 return null;

             oql.AddCondition(Condition.Eq(FareType.Properties.OperatorId, operatorId));
             oql.AddCondition(Condition.Eq(FareType.Properties.CategoryId, categoryId));
             oql.AddCondition(Condition.Eq(FareType.Properties.FareTypeName, fareTypeName));
             //oql.AddCondition(Condition.Eq(FareType.Properties.FareTypeDescription, fareTypeDesc));

             FareTypeList list = new FareType().GetList(oql);
             if (list.Count == 1)
                 return list[0];
             else
                 return null;
         }

         public static void DoInsert(FareType fareType)
         {
             fareType.Create();
         }
     }
}
