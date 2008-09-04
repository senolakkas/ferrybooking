using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class Schedule : DomainObject<System.Int32>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string VesselId = "VesselId";
            public static readonly string FareId = "FareId";
            public static readonly string SailingTime = "SailingTime";
            public static readonly string ArrivalTime = "ArrivalTime";
        }
        #endregion

        #region Fields
        private IScheduleDao _dao;
        private System.Int32? _VesselId;
        private System.Int32? _FareId;
        private System.DateTime? _SailingTime;
        private System.DateTime? _ArrivalTime;
        private Fare _Fare;
        private Vessel _Vessel;
        private IList<RouteOrder> _RouteOrders = new List<RouteOrder>();
        #endregion

        #region Constructor
        public Schedule()
        {
        }

        public Schedule(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
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

         public virtual Fare Fare{
             get { return _Fare; }
             set { _Fare = value;}
         }

         public virtual Vessel Vessel{
             get { return _Vessel; }
             set { _Vessel = value;}
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

        public IScheduleDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetScheduleDao();
                return _dao;
            }
        }

        public Schedule GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public ScheduleList GetList()
        {
            return Dao.GetList();
        }

        public ScheduleList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public ScheduleList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public ScheduleList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public ScheduleList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public Schedule GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public Schedule GetUnique(OQL oql)
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
