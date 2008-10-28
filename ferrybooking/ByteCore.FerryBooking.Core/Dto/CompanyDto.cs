using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class CompanyDto
    {

        #region Fields
        private System.Int32 _CompanyId;
        private System.Int32? _CurrencyId;
        private System.String _CompanyName;
        private System.String _CompanyShortName;
        private System.String _LogoImage;
        private System.String _Terms;
        private System.Boolean? _IsActive;
        #endregion

        #region Constructor
        public CompanyDto()
        {
        }
        public CompanyDto(Company company)  
        {
            _CompanyId = company.ID;
            _CurrencyId = company.CurrencyId;
            _CompanyName = company.CompanyName;
            _CompanyShortName = company.CompanyShortName;
            _LogoImage = company.LogoImage;
            _Terms = company.Terms;
            _IsActive = company.IsActive;
        }

        #endregion

        #region Properties
         public virtual System.Int32 CompanyId {
             get { return _CompanyId; }
             set { _CompanyId = value;}
         }

         public virtual System.Int32? CurrencyId {
             get { return _CurrencyId; }
             set { _CurrencyId = value;}
         }

         public virtual System.String CompanyName {
             get { return _CompanyName; }
             set { _CompanyName = value;}
         }

         public virtual System.String CompanyShortName {
             get { return _CompanyShortName; }
             set { _CompanyShortName = value;}
         }

         public virtual System.String LogoImage {
             get { return _LogoImage; }
             set { _LogoImage = value;}
         }

         public virtual System.String Terms {
             get { return _Terms; }
             set { _Terms = value;}
         }

         public virtual System.Boolean? IsActive {
             get { return _IsActive; }
             set { _IsActive = value;}
         }

        #endregion


     }
}
