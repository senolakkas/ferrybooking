using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class RouteDto
    {

        #region Fields
        private System.Int32 _RoutesID;
        private System.Int32? _OperatorId;
        private System.String _DeparturePortId;
        private System.String _ArriavlPortId;
        private System.Boolean? _IsActive;
        #endregion

        #region Constructor
        public RouteDto()
        {
        }
        public RouteDto(Route route)
        {
            _RoutesID = route.ID;
            _OperatorId = route.OperatorId;
            _DeparturePortId = route.DeparturePortId;
            _ArriavlPortId = route.ArriavlPortId;
            _IsActive = route.IsActive;
        }

        #endregion

        #region Properties
         public virtual System.Int32 RoutesID {
             get { return _RoutesID; }
             set { _RoutesID = value;}
         }

         public virtual System.Int32? OperatorId {
             get { return _OperatorId; }
             set { _OperatorId = value;}
         }

         public virtual System.String DeparturePortId {
             get { return _DeparturePortId; }
             set { _DeparturePortId = value;}
         }

         public virtual System.String ArriavlPortId {
             get { return _ArriavlPortId; }
             set { _ArriavlPortId = value;}
         }

         public virtual System.Boolean? IsActive {
             get { return _IsActive; }
             set { _IsActive = value;}
         }

        #endregion


     }
}
