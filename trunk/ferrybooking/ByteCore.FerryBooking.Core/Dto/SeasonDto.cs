using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class SeasonDto
    {

        #region Fields
        private System.Int32 _SeasonID;
        private System.Int32? _OperatorId;
        private System.Int32? _StartMonth;
        private System.Int32? _StartDay;
        private System.Int32? _EndMonth;
        private System.Int32? _EndDay;
        #endregion

        #region Constructor
        public SeasonDto()
        {
        }
        public SeasonDto(Season season)  
        {
            _SeasonID = season.ID;
            _OperatorId = season.OperatorId;
            _StartMonth = season.StartMonth;
            _StartDay = season.StartDay;
            _EndMonth = season.EndMonth;
            _EndDay = season.EndDay;
        }

        #endregion

        #region Properties
         public virtual System.Int32 SeasonID {
             get { return _SeasonID; }
             set { _SeasonID = value;}
         }

         public virtual System.Int32? OperatorId {
             get { return _OperatorId; }
             set { _OperatorId = value;}
         }

         public virtual System.Int32? StartMonth {
             get { return _StartMonth; }
             set { _StartMonth = value;}
         }

         public virtual System.Int32? StartDay {
             get { return _StartDay; }
             set { _StartDay = value;}
         }

         public virtual System.Int32? EndMonth {
             get { return _EndMonth; }
             set { _EndMonth = value;}
         }

         public virtual System.Int32? EndDay {
             get { return _EndDay; }
             set { _EndDay = value;}
         }

        #endregion


     }
}
