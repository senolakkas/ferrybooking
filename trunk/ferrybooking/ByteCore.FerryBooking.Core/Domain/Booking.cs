using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class Booking : DomainObject<System.Int32>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string BookingDate = "BookingDate";
            public static readonly string Comment = "Comment";
            public static readonly string Status = "Status";
        }
        #endregion

        #region Fields
        private IBookingDao _dao;
        private System.DateTime? _BookingDate;
        private System.String _Comment;
        private System.Int32? _Status;
        private IList<Payment> _Payments = new List<Payment>();
        private IList<RouteOrder> _RouteOrders = new List<RouteOrder>();
        #endregion

        #region Constructor
        public Booking()
        {
        }

        public Booking(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
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

         public virtual IList<Payment> Payments{
             get { return _Payments; }
             set { _Payments = value; }
         }

         public virtual IList<RouteOrder> RouteOrders{
             get { return _RouteOrders; }
             set { _RouteOrders = value; }
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public IBookingDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetBookingDao();
                return _dao;
            }
        }

        public Booking GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public BookingList GetList()
        {
            return Dao.GetList();
        }

        public BookingList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public BookingList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public BookingList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public BookingList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public Booking GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public Booking GetUnique(OQL oql)
        {
            return Dao.GetUnique(oql);
        }

        public void Create()
        {
            //Check.Ensure(this.IsTransient(), "This object already has been created");
            Dao.Create(this);
        }

        public void Update()
        {
            Check.Ensure(!this.IsTransient(), "This object already has not been created, so it can not be update");
            Dao.Update(this);
        }

        public void CreateOrUpdate()
        {
            Dao.CreateOrUpdate(this);
        }

        public void Delete()
        {
            Dao.Delete(this);
        }

        public void CommitChanges()
        {
            Dao.CommitChanges();
        }

        #endregion

     }
}
