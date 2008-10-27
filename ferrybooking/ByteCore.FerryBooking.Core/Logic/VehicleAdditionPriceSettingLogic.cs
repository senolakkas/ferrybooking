using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class VehicleAdditionPriceSetting
     {
         public enum AdditionPriceType
         {
             Height = 1,
             Width =2
         }

         public VehicleAdditionPriceSettingList GetList(int companyId, AdditionPriceType additionPriceType)
         {
             OQL oql = new OQL(typeof(VehicleAdditionPriceSetting));
             oql.AddCondition(Condition.Eq(VehicleAdditionPriceSetting.Properties.OperatorId, companyId));
             oql.AddCondition(Condition.Eq(VehicleAdditionPriceSetting.Properties.VAPSettingType, Convert.ToInt32(additionPriceType)));
             return this.GetList(oql);
         }
     }
}
