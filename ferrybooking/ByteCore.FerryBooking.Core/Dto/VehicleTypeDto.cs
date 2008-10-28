using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class VehicleTypeDto : FareTypeDto
    {

        #region Fields
        private System.Int32? _MinLegth;
        private System.Int32? _MaxLegth;
        private System.Decimal? _ByFootAmount;
        #endregion

        #region Constructor
        public VehicleTypeDto()
        {
        }
        public VehicleTypeDto(VehicleType vehicleType) :base(vehicleType) 
        {
            _MinLegth = vehicleType.MinLegth;
            _MaxLegth = vehicleType.MaxLegth;
            _ByFootAmount = vehicleType.ByFootAmount;
        }

        #endregion

        #region Properties
         public virtual System.Int32? MinLegth {
             get { return _MinLegth; }
             set { _MinLegth = value;}
         }

         public virtual System.Int32? MaxLegth {
             get { return _MaxLegth; }
             set { _MaxLegth = value;}
         }

         public virtual System.Decimal? ByFootAmount {
             get { return _ByFootAmount; }
             set { _ByFootAmount = value;}
         }

        #endregion


     }
}
