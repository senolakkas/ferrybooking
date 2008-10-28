using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class RouteOrderVehicleDetailDto : RouteOrderDetailDto
    {

        #region Fields
        private System.Int32? _VAPSettingID;
        private System.Int32? _VehVAPSettingID;
        private System.String _FareTypeName;
        private System.Int32? _Length;
        private System.String _LicensePlate;
        private System.String _MakeModel;
        #endregion

        #region Constructor
        public RouteOrderVehicleDetailDto()
        {
        }
        public RouteOrderVehicleDetailDto(RouteOrderVehicleDetail routeOrderVehicleDetail) :base(routeOrderVehicleDetail) 
        {
            _VAPSettingID = routeOrderVehicleDetail.VAPSettingID;
            _VehVAPSettingID = routeOrderVehicleDetail.VehVAPSettingID;
            _FareTypeName = routeOrderVehicleDetail.FareTypeName;
            _Length = routeOrderVehicleDetail.Length;
            _LicensePlate = routeOrderVehicleDetail.LicensePlate;
            _MakeModel = routeOrderVehicleDetail.MakeModel;
        }

        #endregion

        #region Properties
         public virtual System.Int32? VAPSettingID {
             get { return _VAPSettingID; }
             set { _VAPSettingID = value;}
         }

         public virtual System.Int32? VehVAPSettingID {
             get { return _VehVAPSettingID; }
             set { _VehVAPSettingID = value;}
         }

         public virtual System.String FareTypeName {
             get { return _FareTypeName; }
             set { _FareTypeName = value;}
         }

         public virtual System.Int32? Length {
             get { return _Length; }
             set { _Length = value;}
         }

         public virtual System.String LicensePlate {
             get { return _LicensePlate; }
             set { _LicensePlate = value;}
         }

         public virtual System.String MakeModel {
             get { return _MakeModel; }
             set { _MakeModel = value;}
         }

        #endregion


     }
}
