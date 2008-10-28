using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class FareCategoryDto
    {

        #region Fields
        private System.Int32 _CategoryId;
        private System.String _CategoryName;
        #endregion

        #region Constructor
        public FareCategoryDto()
        {
        }
        public FareCategoryDto(FareCategory fareCategory)  
        {
            _CategoryId = fareCategory.ID;
            _CategoryName = fareCategory.CategoryName;
        }

        #endregion

        #region Properties
         public virtual System.Int32 CategoryId {
             get { return _CategoryId; }
             set { _CategoryId = value;}
         }

         public virtual System.String CategoryName {
             get { return _CategoryName; }
             set { _CategoryName = value;}
         }

        #endregion


     }
}
