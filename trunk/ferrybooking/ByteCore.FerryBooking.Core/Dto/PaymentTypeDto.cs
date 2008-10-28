using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class PaymentTypeDto
    {

        #region Fields
        private System.Int32 _PaymentTypeId;
        private System.String _PaymentTypeName;
        #endregion

        #region Constructor
        public PaymentTypeDto()
        {
        }
        public PaymentTypeDto(PaymentType paymentType)  
        {
            _PaymentTypeId = paymentType.ID;
            _PaymentTypeName = paymentType.PaymentTypeName;
        }

        #endregion

        #region Properties
         public virtual System.Int32 PaymentTypeId {
             get { return _PaymentTypeId; }
             set { _PaymentTypeId = value;}
         }

         public virtual System.String PaymentTypeName {
             get { return _PaymentTypeName; }
             set { _PaymentTypeName = value;}
         }

        #endregion


     }
}
