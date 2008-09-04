using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class Vessel : DomainObject<System.Int32>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string OperatorId = "OperatorId";
            public static readonly string VesselName = "VesselName";
        }
        #endregion

        #region Fields
        private IVesselDao _dao;
        private System.Int32? _OperatorId;
        private System.String _VesselName;
        private Company _Operator;
        private IList<Schedule> _Schedules = new List<Schedule>();
        private IList<FareType> _FareTypes = new List<FareType>();
        #endregion

        #region Constructor
        public Vessel()
        {
        }

        public Vessel(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.Int32? OperatorId {
             get { return _OperatorId; }
             set { _OperatorId = value;}
         }

         public virtual System.String VesselName {
             get { return _VesselName; }
             set { _VesselName = value;}
         }

         public virtual Company Operator{
             get { return _Operator; }
             set { _Operator = value;}
         }

         public virtual IList<Schedule> Schedules{
             get { return _Schedules; }
             set { _Schedules = value; }
         }

         public virtual IList<FareType> FareTypes{
             get { return _FareTypes; }
             set { _FareTypes = value; }
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public IVesselDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetVesselDao();
                return _dao;
            }
        }

        public Vessel GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public VesselList GetList()
        {
            return Dao.GetList();
        }

        public VesselList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public VesselList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public VesselList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public VesselList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public Vessel GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public Vessel GetUnique(OQL oql)
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
