using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class CurrencyDto
    {

        #region Fields
        private System.Int32 _CurrencyId;
        private System.String _CurrencySymbol;
        #endregion

        #region Constructor
        public CurrencyDto()
        {
        }
        public CurrencyDto(Currency currency)
        {
            _CurrencyId = currency.ID;
            _CurrencySymbol = currency.CurrencySymbol;
        }

        #endregion

        #region Properties
         public virtual System.Int32 CurrencyId {
             get { return _CurrencyId; }
             set { _CurrencyId = value;}
         }

         public virtual System.String CurrencySymbol {
             get { return _CurrencySymbol; }
             set { _CurrencySymbol = value;}
         }

        #endregion


     }
}
