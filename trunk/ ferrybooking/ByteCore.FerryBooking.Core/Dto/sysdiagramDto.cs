using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class sysdiagramDto
    {

        #region Fields
        private System.Int32 _diagramid;
        private System.String _name;
        private System.Int32 _principalid;
        private System.Int32? _version;
        private System.Byte[] _definition;
        #endregion

        #region Constructor
        public sysdiagramDto()
        {
        }
        public sysdiagramDto(sysdiagram sysdiagram)
        {
            _diagramid = sysdiagram.ID;
            _name = sysdiagram.name;
            _principalid = sysdiagram.principalid;
            _version = sysdiagram.version;
            _definition = sysdiagram.definition;
        }

        #endregion

        #region Properties
         public virtual System.Int32 diagramid {
             get { return _diagramid; }
             set { _diagramid = value;}
         }

         public virtual System.String name {
             get { return _name; }
             set { _name = value;}
         }

         public virtual System.Int32 principalid {
             get { return _principalid; }
             set { _principalid = value;}
         }

         public virtual System.Int32? version {
             get { return _version; }
             set { _version = value;}
         }

         public virtual System.Byte[] definition {
             get { return _definition; }
             set { _definition = value;}
         }

        #endregion


     }
}
