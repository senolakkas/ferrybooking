using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class Route : DomainObject<System.Int32>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string OperatorId = "OperatorId";
            public static readonly string DeparturePortId = "DeparturePortId";
            public static readonly string ArriavlPortId = "ArriavlPortId";
            public static readonly string IsActive = "IsActive";
        }
        #endregion

        #region Fields
        private IRouteDao _dao;
        private System.Int32? _OperatorId;
        private System.String _DeparturePortId;
        private System.String _ArriavlPortId;
        private System.Boolean? _IsActive;
        private Company _Operator;
        private Port _DeparturePort;
        private Port _ArriavlPort;
        private IList<Fare> _Fares = new List<Fare>();
        #endregion

        #region Constructor
        public Route()
        {
        }

        public Route(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.Int32? OperatorId {
             get { return _OperatorId; }
             set { _OperatorId = value;}
         }

         public virtual System.String DeparturePortId {
             get { return _DeparturePortId; }
             set { _DeparturePortId = value;}
         }

         public virtual System.String ArriavlPortId {
             get { return _ArriavlPortId; }
             set { _ArriavlPortId = value;}
         }

         public virtual System.Boolean? IsActive {
             get { return _IsActive; }
             set { _IsActive = value;}
         }

         public virtual Company Operator{
             get { return _Operator; }
             set { _Operator = value;}
         }

         public virtual Port DeparturePort{
             get { return _DeparturePort; }
             set { _DeparturePort = value;}
         }

         public virtual Port ArriavlPort{
             get { return _ArriavlPort; }
             set { _ArriavlPort = value;}
         }

         public virtual IList<Fare> Fares{
             get { return _Fares; }
             set { _Fares = value; }
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public IRouteDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetRouteDao();
                return _dao;
            }
        }

        public Route GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public RouteList GetList()
        {
            return Dao.GetList();
        }

        public RouteList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public RouteList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public RouteList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public RouteList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public Route GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public Route GetUnique(OQL oql)
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
