using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class FareDto
    {

        #region Fields
        private System.Int32 _FareId;
        private System.Int32? _RoutesID;
        private System.DateTime? _StartDate;
        private System.DateTime? _EndDate;
        #endregion

        #region Constructor
        public FareDto()
        {
        }
        public FareDto(Fare fare)
        {
            _FareId = fare.ID;
            _RoutesID = fare.RoutesID;
            _StartDate = fare.StartDate;
            _EndDate = fare.EndDate;
        }

        #endregion

        #region Properties
         public virtual System.Int32 FareId {
             get { return _FareId; }
             set { _FareId = value;}
         }

         public virtual System.Int32? RoutesID {
             get { return _RoutesID; }
             set { _RoutesID = value;}
         }

         public virtual System.DateTime? StartDate {
             get { return _StartDate; }
             set { _StartDate = value;}
         }

         public virtual System.DateTime? EndDate {
             get { return _EndDate; }
             set { _EndDate = value;}
         }

        #endregion


     }
}
