using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class BookingDto
    {

        #region Fields
        private System.Int32 _BookingID;
        private System.DateTime? _BookingDate;
        private System.String _Comment;
        private System.Int32? _Status;
        #endregion

        #region Constructor
        public BookingDto()
        {
        }
        public BookingDto(Booking booking)
        {
            _BookingID = booking.ID;
            _BookingDate = booking.BookingDate;
            _Comment = booking.Comment;
            _Status = booking.Status;
        }

        #endregion

        #region Properties
         public virtual System.Int32 BookingID {
             get { return _BookingID; }
             set { _BookingID = value;}
         }

         public virtual System.DateTime? BookingDate {
             get { return _BookingDate; }
             set { _BookingDate = value;}
         }

         public virtual System.String Comment {
             get { return _Comment; }
             set { _Comment = value;}
         }

         public virtual System.Int32? Status {
             get { return _Status; }
             set { _Status = value;}
         }

        #endregion


     }
}
