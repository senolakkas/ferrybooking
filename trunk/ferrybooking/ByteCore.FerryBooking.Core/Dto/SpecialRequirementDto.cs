using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class SpecialRequirementDto
    {

        #region Fields
        private System.Int32 _RequirementID;
        private System.String _RequirementDesc;
        #endregion

        #region Constructor
        public SpecialRequirementDto()
        {
        }
        public SpecialRequirementDto(SpecialRequirement specialRequirement)  
        {
            _RequirementID = specialRequirement.ID;
            _RequirementDesc = specialRequirement.RequirementDesc;
        }

        #endregion

        #region Properties
         public virtual System.Int32 RequirementID {
             get { return _RequirementID; }
             set { _RequirementID = value;}
         }

         public virtual System.String RequirementDesc {
             get { return _RequirementDesc; }
             set { _RequirementDesc = value;}
         }

        #endregion


     }
}
