using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class PortDto
    {

        #region Fields
        private System.String _PortId;
        private System.String _PortName;
        #endregion

        #region Constructor
        public PortDto()
        {
        }
        public PortDto(Port port)  
        {
            _PortId = port.ID;
            _PortName = port.PortName;
        }

        #endregion

        #region Properties
         public virtual System.String PortId {
             get { return _PortId; }
             set { _PortId = value;}
         }

         public virtual System.String PortName {
             get { return _PortName; }
             set { _PortName = value;}
         }

        #endregion


     }
}
