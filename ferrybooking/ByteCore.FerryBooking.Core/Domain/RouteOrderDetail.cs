using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class RouteOrderDetail : DomainObject<System.Int32>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string FareTypeId = "FareTypeId";
            public static readonly string RouteOrderID = "RouteOrderID";
            public static readonly string Quantity = "Quantity";
            public static readonly string Amount = "Amount";
        }
        #endregion

        #region Fields
        private IRouteOrderDetailDao _dao;
        private System.Int32? _FareTypeId;
        private System.Int32? _RouteOrderID;
        private System.Int32? _Quantity;
        private System.Decimal? _Amount;
        private FareType _FareType;
        private RouteOrder _RouteOrder;
        private IList<RouteOrderVehicleDetail> _RouteOrderVehicleDetails = new List<RouteOrderVehicleDetail>();
        #endregion

        #region Constructor
        public RouteOrderDetail()
        {
        }

        public RouteOrderDetail(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.Int32? FareTypeId {
             get { return _FareTypeId; }
             set { _FareTypeId = value;}
         }

         public virtual System.Int32? RouteOrderID {
             get { return _RouteOrderID; }
             set { _RouteOrderID = value;}
         }

         public virtual System.Int32? Quantity {
             get { return _Quantity; }
             set { _Quantity = value;}
         }

         public virtual System.Decimal? Amount {
             get { return _Amount; }
             set { _Amount = value;}
         }

         public virtual FareType FareType{
             get { return _FareType; }
             set { _FareType = value;}
         }

         public virtual RouteOrder RouteOrder{
             get { return _RouteOrder; }
             set { _RouteOrder = value;}
         }

         public virtual IList<RouteOrderVehicleDetail> RouteOrderVehicleDetails{
             get { return _RouteOrderVehicleDetails; }
             set { _RouteOrderVehicleDetails = value; }
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public IRouteOrderDetailDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetRouteOrderDetailDao();
                return _dao;
            }
        }

        public RouteOrderDetail GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public RouteOrderDetailList GetList()
        {
            return Dao.GetList();
        }

        public RouteOrderDetailList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public RouteOrderDetailList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public RouteOrderDetailList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public RouteOrderDetailList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public RouteOrderDetail GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public RouteOrderDetail GetUnique(OQL oql)
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
