using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class RouteOrderDto
    {

        #region Fields
        private System.Int32 _RouteOrderID;
        private System.Int32? _ScheduleId;
        private System.Int32? _BookingID;
        private System.Boolean? _IsPrimary;
        #endregion

        #region Constructor
        public RouteOrderDto()
        {
        }
        public RouteOrderDto(RouteOrder routeOrder)  
        {
            _RouteOrderID = routeOrder.ID;
            _ScheduleId = routeOrder.ScheduleId;
            _BookingID = routeOrder.BookingID;
            _IsPrimary = routeOrder.IsPrimary;
        }

        #endregion

        #region Properties
         public virtual System.Int32 RouteOrderID {
             get { return _RouteOrderID; }
             set { _RouteOrderID = value;}
         }

         public virtual System.Int32? ScheduleId {
             get { return _ScheduleId; }
             set { _ScheduleId = value;}
         }

         public virtual System.Int32? BookingID {
             get { return _BookingID; }
             set { _BookingID = value;}
         }

         public virtual System.Boolean? IsPrimary {
             get { return _IsPrimary; }
             set { _IsPrimary = value;}
         }

        #endregion


     }
}
