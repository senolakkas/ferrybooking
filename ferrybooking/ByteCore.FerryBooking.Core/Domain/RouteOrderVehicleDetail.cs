using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class RouteOrderVehicleDetail : RouteOrderDetail
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string FareTypeId = "FareTypeId";
            public static readonly string RouteOrderID = "RouteOrderID";
            public static readonly string Quantity = "Quantity";
            public static readonly string Amount = "Amount";
            public static readonly string VAPSettingID = "VAPSettingID";
            public static readonly string VehVAPSettingID = "VehVAPSettingID";
            public static readonly string FareTypeName = "FareTypeName";
            public static readonly string Length = "Length";
            public static readonly string LicensePlate = "LicensePlate";
            public static readonly string MakeModel = "MakeModel";
        }
        #endregion

        #region Fields
        private IRouteOrderVehicleDetailDao _dao;
        private System.Int32? _VAPSettingID;
        private System.Int32? _VehVAPSettingID;
        private System.String _FareTypeName;
        private System.Int32? _Length;
        private System.String _LicensePlate;
        private System.String _MakeModel;
        #endregion

        #region Constructor
        public RouteOrderVehicleDetail()
        {
        }

        public RouteOrderVehicleDetail(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.Int32? VAPSettingID {
             get { return _VAPSettingID; }
             set { _VAPSettingID = value;}
         }

         public virtual System.Int32? VehVAPSettingID {
             get { return _VehVAPSettingID; }
             set { _VehVAPSettingID = value;}
         }

         public virtual System.String FareTypeName {
             get { return _FareTypeName; }
             set { _FareTypeName = value;}
         }

         public virtual System.Int32? Length {
             get { return _Length; }
             set { _Length = value;}
         }

         public virtual System.String LicensePlate {
             get { return _LicensePlate; }
             set { _LicensePlate = value;}
         }

         public virtual System.String MakeModel {
             get { return _MakeModel; }
             set { _MakeModel = value;}
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public IRouteOrderVehicleDetailDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetRouteOrderVehicleDetailDao();
                return _dao;
            }
        }

        public RouteOrderVehicleDetail GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public RouteOrderVehicleDetailList GetList()
        {
            return Dao.GetList();
        }

        public RouteOrderVehicleDetailList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public RouteOrderVehicleDetailList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public RouteOrderVehicleDetailList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public RouteOrderVehicleDetailList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public RouteOrderVehicleDetail GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public RouteOrderVehicleDetail GetUnique(OQL oql)
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
