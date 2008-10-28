using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class ScheduleDto
    {

        #region Fields
        private System.Int32 _ScheduleId;
        private System.Int32? _VesselId;
        private System.Int32? _FareId;
        private System.DateTime? _SailingTime;
        private System.DateTime? _ArrivalTime;
        #endregion

        #region Constructor
        public ScheduleDto()
        {
        }
        public ScheduleDto(Schedule schedule)  
        {
            _ScheduleId = schedule.ID;
            _VesselId = schedule.VesselId;
            _FareId = schedule.FareId;
            _SailingTime = schedule.SailingTime;
            _ArrivalTime = schedule.ArrivalTime;
        }

        #endregion

        #region Properties
         public virtual System.Int32 ScheduleId {
             get { return _ScheduleId; }
             set { _ScheduleId = value;}
         }

         public virtual System.Int32? VesselId {
             get { return _VesselId; }
             set { _VesselId = value;}
         }

         public virtual System.Int32? FareId {
             get { return _FareId; }
             set { _FareId = value;}
         }

         public virtual System.DateTime? SailingTime {
             get { return _SailingTime; }
             set { _SailingTime = value;}
         }

         public virtual System.DateTime? ArrivalTime {
             get { return _ArrivalTime; }
             set { _ArrivalTime = value;}
         }

        #endregion


     }
}
