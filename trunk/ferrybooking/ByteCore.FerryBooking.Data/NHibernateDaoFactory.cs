using System;
using System.Collections.Generic;
using System.Text;
using ByteCore.FerryBooking.Core;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Data
{
   public class NHibernateDaoFactory:IDaoFactory
    {

        public IAppSettingDao GetAppSettingDao()
        {
            return new AppSettingDao();
        }

        public IBookingDao GetBookingDao()
        {
            return new BookingDao();
        }

        public ICompanyDao GetCompanyDao()
        {
            return new CompanyDao();
        }

        public ICountryDao GetCountryDao()
        {
            return new CountryDao();
        }

        public ICurrencyDao GetCurrencyDao()
        {
            return new CurrencyDao();
        }

        public IFareDao GetFareDao()
        {
            return new FareDao();
        }

        public IFareCategoryDao GetFareCategoryDao()
        {
            return new FareCategoryDao();
        }

        public IFareItemDao GetFareItemDao()
        {
            return new FareItemDao();
        }

        public IFareTypeDao GetFareTypeDao()
        {
            return new FareTypeDao();
        }

        public IPassengerTypeDao GetPassengerTypeDao()
        {
            return new PassengerTypeDao();
        }

        public IPaymentDao GetPaymentDao()
        {
            return new PaymentDao();
        }

        public IPaymentTypeDao GetPaymentTypeDao()
        {
            return new PaymentTypeDao();
        }

        public IPortDao GetPortDao()
        {
            return new PortDao();
        }

        public IRouteDao GetRouteDao()
        {
            return new RouteDao();
        }

        public IRouteOrderDao GetRouteOrderDao()
        {
            return new RouteOrderDao();
        }

        public IRouteOrderDetailDao GetRouteOrderDetailDao()
        {
            return new RouteOrderDetailDao();
        }

        public IRouteOrderPassengerDetailDao GetRouteOrderPassengerDetailDao()
        {
            return new RouteOrderPassengerDetailDao();
        }

        public IRouteOrderVehicleDetailDao GetRouteOrderVehicleDetailDao()
        {
            return new RouteOrderVehicleDetailDao();
        }

        public IScheduleDao GetScheduleDao()
        {
            return new ScheduleDao();
        }

        public ISeasonDao GetSeasonDao()
        {
            return new SeasonDao();
        }

        public ISpecialRequirementDao GetSpecialRequirementDao()
        {
            return new SpecialRequirementDao();
        }

        public IVehicleAdditionPriceSettingDao GetVehicleAdditionPriceSettingDao()
        {
            return new VehicleAdditionPriceSettingDao();
        }

        public IVehicleTypeDao GetVehicleTypeDao()
        {
            return new VehicleTypeDao();
        }

        public IVesselDao GetVesselDao()
        {
            return new VesselDao();
        }

    }

}
