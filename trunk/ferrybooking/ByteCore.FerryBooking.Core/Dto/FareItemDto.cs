using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class FareItemDto
    {

        #region Fields
        private System.Int32 _FareItemId;
        private System.Int32? _FareTypeId;
        private System.Int32? _FareId;
        private System.Decimal? _Amount;
        private System.Int32? _RangeStart;
        private System.Int32? _RangeEnd;
        private System.Decimal? _ByFootAmount;
        private System.Decimal? _RoundTripDiscount;
        #endregion

        #region Constructor
        public FareItemDto()
        {
        }
        public FareItemDto(FareItem fareItem)  
        {
            _FareItemId = fareItem.ID;
            _FareTypeId = fareItem.FareTypeId;
            _FareId = fareItem.FareId;
            _Amount = fareItem.Amount;
            _RangeStart = fareItem.RangeStart;
            _RangeEnd = fareItem.RangeEnd;
            _ByFootAmount = fareItem.ByFootAmount;
            _RoundTripDiscount = fareItem.RoundTripDiscount;
        }

        #endregion

        #region Properties
         public virtual System.Int32 FareItemId {
             get { return _FareItemId; }
             set { _FareItemId = value;}
         }

         public virtual System.Int32? FareTypeId {
             get { return _FareTypeId; }
             set { _FareTypeId = value;}
         }

         public virtual System.Int32? FareId {
             get { return _FareId; }
             set { _FareId = value;}
         }

         public virtual System.Decimal? Amount {
             get { return _Amount; }
             set { _Amount = value;}
         }

         public virtual System.Int32? RangeStart {
             get { return _RangeStart; }
             set { _RangeStart = value;}
         }

         public virtual System.Int32? RangeEnd {
             get { return _RangeEnd; }
             set { _RangeEnd = value;}
         }

         public virtual System.Decimal? ByFootAmount {
             get { return _ByFootAmount; }
             set { _ByFootAmount = value;}
         }

         public virtual System.Decimal? RoundTripDiscount {
             get { return _RoundTripDiscount; }
             set { _RoundTripDiscount = value;}
         }

        #endregion


     }
}
