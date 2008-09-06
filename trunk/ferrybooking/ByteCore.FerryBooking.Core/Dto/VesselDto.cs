using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class VesselDto
    {

        #region Fields
        private System.Int32 _VesselId;
        private System.Int32? _OperatorId;
        private System.String _VesselCode;
        private System.String _VesselName;
        #endregion

        #region Constructor
        public VesselDto()
        {
        }
        public VesselDto(Vessel vessel)  
        {
            _VesselId = vessel.ID;
            _OperatorId = vessel.OperatorId;
            _VesselCode = vessel.VesselCode;
            _VesselName = vessel.VesselName;
        }

        #endregion

        #region Properties
         public virtual System.Int32 VesselId {
             get { return _VesselId; }
             set { _VesselId = value;}
         }

         public virtual System.Int32? OperatorId {
             get { return _OperatorId; }
             set { _OperatorId = value;}
         }

         public virtual System.String VesselCode {
             get { return _VesselCode; }
             set { _VesselCode = value;}
         }

         public virtual System.String VesselName {
             get { return _VesselName; }
             set { _VesselName = value;}
         }

        #endregion


     }
}
