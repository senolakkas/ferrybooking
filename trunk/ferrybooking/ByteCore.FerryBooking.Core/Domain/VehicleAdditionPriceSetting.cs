using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class VehicleAdditionPriceSetting : DomainObject<System.Int32>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string OperatorId = "OperatorId";
            public static readonly string VAPSettingType = "VAPSettingType";
            public static readonly string VAPSettingName = "VAPSettingName";
            public static readonly string AdditionPrice = "AdditionPrice";
        }
        #endregion

        #region Fields
        private IVehicleAdditionPriceSettingDao _dao;
        private System.Int32? _OperatorId;
        private System.Int32? _VAPSettingType;
        private System.String _VAPSettingName;
        private System.Decimal? _AdditionPrice;
        private Company _Operator;
        private IList<RouteOrderVehicleDetail> _VAPSettingID_RouteOrderVehicleDetails = new List<RouteOrderVehicleDetail>();
        private IList<RouteOrderVehicleDetail> _VehVAPSettingID_RouteOrderVehicleDetails = new List<RouteOrderVehicleDetail>();
        #endregion

        #region Constructor
        public VehicleAdditionPriceSetting()
        {
        }

        public VehicleAdditionPriceSetting(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.Int32? OperatorId {
             get { return _OperatorId; }
             set { _OperatorId = value;}
         }

         public virtual System.Int32? VAPSettingType {
             get { return _VAPSettingType; }
             set { _VAPSettingType = value;}
         }

         public virtual System.String VAPSettingName {
             get { return _VAPSettingName; }
             set { _VAPSettingName = value;}
         }

         public virtual System.Decimal? AdditionPrice {
             get { return _AdditionPrice; }
             set { _AdditionPrice = value;}
         }

         public virtual Company Operator{
             get { return _Operator; }
             set { _Operator = value;}
         }

         public virtual IList<RouteOrderVehicleDetail> VAPSettingID_RouteOrderVehicleDetails{
             get { return _VAPSettingID_RouteOrderVehicleDetails; }
             set { _VAPSettingID_RouteOrderVehicleDetails = value; }
         }

         public virtual IList<RouteOrderVehicleDetail> VehVAPSettingID_RouteOrderVehicleDetails{
             get { return _VehVAPSettingID_RouteOrderVehicleDetails; }
             set { _VehVAPSettingID_RouteOrderVehicleDetails = value; }
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public IVehicleAdditionPriceSettingDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetVehicleAdditionPriceSettingDao();
                return _dao;
            }
        }

        public VehicleAdditionPriceSetting GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public VehicleAdditionPriceSettingList GetList()
        {
            return Dao.GetList();
        }

        public VehicleAdditionPriceSettingList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public VehicleAdditionPriceSettingList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public VehicleAdditionPriceSettingList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public VehicleAdditionPriceSettingList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public VehicleAdditionPriceSetting GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public VehicleAdditionPriceSetting GetUnique(OQL oql)
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
