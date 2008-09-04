using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class RouteOrder : DomainObject<System.Int32>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string ScheduleId = "ScheduleId";
            public static readonly string BookingID = "BookingID";
            public static readonly string IsPrimary = "IsPrimary";
        }
        #endregion

        #region Fields
        private IRouteOrderDao _dao;
        private System.Int32? _ScheduleId;
        private System.Int32? _BookingID;
        private System.Boolean? _IsPrimary;
        private Booking _Booking;
        private Schedule _Schedule;
        private IList<RouteOrderDetail> _RouteOrderDetails = new List<RouteOrderDetail>();
        #endregion

        #region Constructor
        public RouteOrder()
        {
        }

        public RouteOrder(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
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

         public virtual Booking Booking{
             get { return _Booking; }
             set { _Booking = value;}
         }

         public virtual Schedule Schedule{
             get { return _Schedule; }
             set { _Schedule = value;}
         }

         public virtual IList<RouteOrderDetail> RouteOrderDetails{
             get { return _RouteOrderDetails; }
             set { _RouteOrderDetails = value; }
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public IRouteOrderDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetRouteOrderDao();
                return _dao;
            }
        }

        public RouteOrder GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public RouteOrderList GetList()
        {
            return Dao.GetList();
        }

        public RouteOrderList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public RouteOrderList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public RouteOrderList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public RouteOrderList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public RouteOrder GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public RouteOrder GetUnique(OQL oql)
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
