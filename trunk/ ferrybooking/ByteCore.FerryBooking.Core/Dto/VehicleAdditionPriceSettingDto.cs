using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class VehicleAdditionPriceSettingDto
    {

        #region Fields
        private System.Int32 _VAPSettingID;
        private System.Int32? _OperatorId;
        private System.Int32? _VAPSettingType;
        private System.String _VAPSettingName;
        private System.Decimal? _AdditionPrice;
        #endregion

        #region Constructor
        public VehicleAdditionPriceSettingDto()
        {
        }
        public VehicleAdditionPriceSettingDto(VehicleAdditionPriceSetting vehicleAdditionPriceSetting)
        {
            _VAPSettingID = vehicleAdditionPriceSetting.ID;
            _OperatorId = vehicleAdditionPriceSetting.OperatorId;
            _VAPSettingType = vehicleAdditionPriceSetting.VAPSettingType;
            _VAPSettingName = vehicleAdditionPriceSetting.VAPSettingName;
            _AdditionPrice = vehicleAdditionPriceSetting.AdditionPrice;
        }

        #endregion

        #region Properties
         public virtual System.Int32 VAPSettingID {
             get { return _VAPSettingID; }
             set { _VAPSettingID = value;}
         }

         public virtual System.Int32? OperatorId {
             get { return _OperatorId; }
             set { _OperatorId = value;}
         }

         public virtual System.Int32? VAPSettingType {
             get { return _VAPSettingType; }
             set { _VAPSettingType = value;}
         }

         public virtual System.String VAPSettingName {
             get { return _VAPSettingName; }
             set { _VAPSettingName = value;}
         }

         public virtual System.Decimal? AdditionPrice {
             get { return _AdditionPrice; }
             set { _AdditionPrice = value;}
         }

        #endregion


     }
}
