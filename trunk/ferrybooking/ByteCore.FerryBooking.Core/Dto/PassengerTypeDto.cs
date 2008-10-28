using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class PassengerTypeDto : FareTypeDto
    {

        #region Fields
        private System.Int32? _MinAge;
        private System.Int32? _MaxAge;
        #endregion

        #region Constructor
        public PassengerTypeDto()
        {
        }
        public PassengerTypeDto(PassengerType passengerType) :base(passengerType) 
        {
            _MinAge = passengerType.MinAge;
            _MaxAge = passengerType.MaxAge;
        }

        #endregion

        #region Properties
         public virtual System.Int32? MinAge {
             get { return _MinAge; }
             set { _MinAge = value;}
         }

         public virtual System.Int32? MaxAge {
             get { return _MaxAge; }
             set { _MaxAge = value;}
         }

        #endregion


     }
}
