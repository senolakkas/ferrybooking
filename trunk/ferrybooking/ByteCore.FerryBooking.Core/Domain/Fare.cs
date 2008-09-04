using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class Fare : DomainObject<System.Int32>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string RoutesID = "RoutesID";
            public static readonly string StartDate = "StartDate";
            public static readonly string EndDate = "EndDate";
        }
        #endregion

        #region Fields
        private IFareDao _dao;
        private System.Int32? _RoutesID;
        private System.DateTime? _StartDate;
        private System.DateTime? _EndDate;
        private Route _Routes;
        private IList<FareItem> _FareItems = new List<FareItem>();
        private IList<Schedule> _Schedules = new List<Schedule>();
        #endregion

        #region Constructor
        public Fare()
        {
        }

        public Fare(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.Int32? RoutesID {
             get { return _RoutesID; }
             set { _RoutesID = value;}
         }

         public virtual System.DateTime? StartDate {
             get { return _StartDate; }
             set { _StartDate = value;}
         }

         public virtual System.DateTime? EndDate {
             get { return _EndDate; }
             set { _EndDate = value;}
         }

         public virtual Route Routes{
             get { return _Routes; }
             set { _Routes = value;}
         }

         public virtual IList<FareItem> FareItems{
             get { return _FareItems; }
             set { _FareItems = value; }
         }

         public virtual IList<Schedule> Schedules{
             get { return _Schedules; }
             set { _Schedules = value; }
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public IFareDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetFareDao();
                return _dao;
            }
        }

        public Fare GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public FareList GetList()
        {
            return Dao.GetList();
        }

        public FareList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public FareList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public FareList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public FareList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public Fare GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public Fare GetUnique(OQL oql)
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
