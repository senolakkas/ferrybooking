using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class FareTypeDto
    {

        #region Fields
        private System.Int32 _FareTypeId;
        private System.Int32? _OperatorId;
        private System.Int32? _CategoryId;
        private System.String _FareTypeName;
        private System.String _FareTypeDescription;
        #endregion

        #region Constructor
        public FareTypeDto()
        {
        }
        public FareTypeDto(FareType fareType)  
        {
            _FareTypeId = fareType.ID;
            _OperatorId = fareType.OperatorId;
            _CategoryId = fareType.CategoryId;
            _FareTypeName = fareType.FareTypeName;
            _FareTypeDescription = fareType.FareTypeDescription;
        }

        #endregion

        #region Properties
         public virtual System.Int32 FareTypeId {
             get { return _FareTypeId; }
             set { _FareTypeId = value;}
         }

         public virtual System.Int32? OperatorId {
             get { return _OperatorId; }
             set { _OperatorId = value;}
         }

         public virtual System.Int32? CategoryId {
             get { return _CategoryId; }
             set { _CategoryId = value;}
         }

         public virtual System.String FareTypeName {
             get { return _FareTypeName; }
             set { _FareTypeName = value;}
         }

         public virtual System.String FareTypeDescription {
             get { return _FareTypeDescription; }
             set { _FareTypeDescription = value;}
         }

        #endregion


     }
}
