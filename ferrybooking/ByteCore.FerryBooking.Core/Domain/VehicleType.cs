using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class VehicleType : FareType
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string OperatorId = "OperatorId";
            public static readonly string CategoryId = "CategoryId";
            public static readonly string FareTypeName = "FareTypeName";
            public static readonly string FareTypeDescription = "FareTypeDescription";
            public static readonly string MinLegth = "MinLegth";
            public static readonly string MaxLegth = "MaxLegth";
            public static readonly string ByFootAmount = "ByFootAmount";
        }
        #endregion

        #region Fields
        private IVehicleTypeDao _dao;
        private System.Int32? _MinLegth;
        private System.Int32? _MaxLegth;
        private System.Decimal? _ByFootAmount;
        #endregion

        #region Constructor
        public VehicleType()
        {
        }

        public VehicleType(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.Int32? MinLegth {
             get { return _MinLegth; }
             set { _MinLegth = value;}
         }

         public virtual System.Int32? MaxLegth {
             get { return _MaxLegth; }
             set { _MaxLegth = value;}
         }

         public virtual System.Decimal? ByFootAmount {
             get { return _ByFootAmount; }
             set { _ByFootAmount = value;}
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public IVehicleTypeDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetVehicleTypeDao();
                return _dao;
            }
        }

        public VehicleType GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public VehicleTypeList GetList()
        {
            return Dao.GetList();
        }

        public VehicleTypeList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public VehicleTypeList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public VehicleTypeList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public VehicleTypeList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public VehicleType GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public VehicleType GetUnique(OQL oql)
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
