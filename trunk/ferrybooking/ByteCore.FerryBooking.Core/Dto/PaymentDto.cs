using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class PaymentDto
    {

        #region Fields
        private System.Int32 _PaymentID;
        private System.Int32? _BookingID;
        private System.Int32? _PaymentTypeId;
        private System.String _ResponseMessage;
        #endregion

        #region Constructor
        public PaymentDto()
        {
        }
        public PaymentDto(Payment payment)  
        {
            _PaymentID = payment.ID;
            _BookingID = payment.BookingID;
            _PaymentTypeId = payment.PaymentTypeId;
            _ResponseMessage = payment.ResponseMessage;
        }

        #endregion

        #region Properties
         public virtual System.Int32 PaymentID {
             get { return _PaymentID; }
             set { _PaymentID = value;}
         }

         public virtual System.Int32? BookingID {
             get { return _BookingID; }
             set { _BookingID = value;}
         }

         public virtual System.Int32? PaymentTypeId {
             get { return _PaymentTypeId; }
             set { _PaymentTypeId = value;}
         }

         public virtual System.String ResponseMessage {
             get { return _ResponseMessage; }
             set { _ResponseMessage = value;}
         }

        #endregion


     }
}
