using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class CountryDto
    {

        #region Fields
        private System.Int32 _CountryID;
        private System.String _CountryName;
        #endregion

        #region Constructor
        public CountryDto()
        {
        }
        public CountryDto(Country country)
        {
            _CountryID = country.ID;
            _CountryName = country.CountryName;
        }

        #endregion

        #region Properties
         public virtual System.Int32 CountryID {
             get { return _CountryID; }
             set { _CountryID = value;}
         }

         public virtual System.String CountryName {
             get { return _CountryName; }
             set { _CountryName = value;}
         }

        #endregion


     }
}
