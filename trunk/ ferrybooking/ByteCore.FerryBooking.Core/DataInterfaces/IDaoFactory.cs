using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
   public interface IDaoFactory
    {

        IAppSettingDao GetAppSettingDao();

        IBookingDao GetBookingDao();

        ICompanyDao GetCompanyDao();

        ICountryDao GetCountryDao();

        ICurrencyDao GetCurrencyDao();

        IFareDao GetFareDao();

        IFareCategoryDao GetFareCategoryDao();

        IFareItemDao GetFareItemDao();

        IFareTypeDao GetFareTypeDao();

        IPassengerTypeDao GetPassengerTypeDao();

        IPaymentDao GetPaymentDao();

        IPaymentTypeDao GetPaymentTypeDao();

        IPortDao GetPortDao();

        IRouteDao GetRouteDao();

        IRouteOrderDao GetRouteOrderDao();

        IRouteOrderDetailDao GetRouteOrderDetailDao();

        IRouteOrderPassengerDetailDao GetRouteOrderPassengerDetailDao();

        IRouteOrderVehicleDetailDao GetRouteOrderVehicleDetailDao();

        IScheduleDao GetScheduleDao();

        ISeasonDao GetSeasonDao();

        ISpecialRequirementDao GetSpecialRequirementDao();

        IsysdiagramDao GetsysdiagramDao();

        IVehicleAdditionPriceSettingDao GetVehicleAdditionPriceSettingDao();

        IVehicleTypeDao GetVehicleTypeDao();

        IVesselDao GetVesselDao();

    }

}
