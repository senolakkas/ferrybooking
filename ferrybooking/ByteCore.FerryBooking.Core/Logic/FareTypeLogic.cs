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
     }
}
