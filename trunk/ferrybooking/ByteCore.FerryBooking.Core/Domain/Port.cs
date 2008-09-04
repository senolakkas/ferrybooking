using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class Port : DomainObject<System.String>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string PortName = "PortName";
        }
        #endregion

        #region Fields
        private IPortDao _dao;
        private System.String _PortName;
        private IList<Route> _DeparturePortId_Routes = new List<Route>();
        private IList<Route> _ArriavlPortId_Routes = new List<Route>();
        #endregion

        #region Constructor
        public Port()
        {
        }

        public Port(System.String id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.String PortName {
             get { return _PortName; }
             set { _PortName = value;}
         }

         public virtual IList<Route> DeparturePortId_Routes{
             get { return _DeparturePortId_Routes; }
             set { _DeparturePortId_Routes = value; }
         }

         public virtual IList<Route> ArriavlPortId_Routes{
             get { return _ArriavlPortId_Routes; }
             set { _ArriavlPortId_Routes = value; }
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public IPortDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetPortDao();
                return _dao;
            }
        }

        public Port GetById(System.String id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public PortList GetList()
        {
            return Dao.GetList();
        }

        public PortList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public PortList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public PortList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public PortList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public Port GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public Port GetUnique(OQL oql)
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
