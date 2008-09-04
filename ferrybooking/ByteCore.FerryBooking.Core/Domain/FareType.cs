using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class FareType : DomainObject<System.Int32>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string OperatorId = "OperatorId";
            public static readonly string CategoryId = "CategoryId";
            public static readonly string FareTypeName = "FareTypeName";
            public static readonly string FareTypeDescription = "FareTypeDescription";
        }
        #endregion

        #region Fields
        private IFareTypeDao _dao;
        private System.Int32? _OperatorId;
        private System.Int32? _CategoryId;
        private System.String _FareTypeName;
        private System.String _FareTypeDescription;
        private FareCategory _Category;
        private Company _Operator;
        private IList<FareItem> _FareItems = new List<FareItem>();
        private IList<RouteOrderDetail> _RouteOrderDetails = new List<RouteOrderDetail>();
        private IList<Vessel> _Vessels = new List<Vessel>();
        #endregion

        #region Constructor
        public FareType()
        {
        }

        public FareType(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.Int32? OperatorId {
             get { return _OperatorId; }
             set { _OperatorId = value;}
         }

         public virtual System.Int32? CategoryId {
             get { return _CategoryId; }
             set { _CategoryId = value;}
         }

         public virtual System.String FareTypeName {
             get { return _FareTypeName; }
             set { _FareTypeName = value;}
         }

         public virtual System.String FareTypeDescription {
             get { return _FareTypeDescription; }
             set { _FareTypeDescription = value;}
         }

         public virtual FareCategory Category{
             get { return _Category; }
             set { _Category = value;}
         }

         public virtual Company Operator{
             get { return _Operator; }
             set { _Operator = value;}
         }

         public virtual IList<FareItem> FareItems{
             get { return _FareItems; }
             set { _FareItems = value; }
         }

         public virtual IList<RouteOrderDetail> RouteOrderDetails{
             get { return _RouteOrderDetails; }
             set { _RouteOrderDetails = value; }
         }

         public virtual IList<Vessel> Vessels{
             get { return _Vessels; }
             set { _Vessels = value; }
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public IFareTypeDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetFareTypeDao();
                return _dao;
            }
        }

        public FareType GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public FareTypeList GetList()
        {
            return Dao.GetList();
        }

        public FareTypeList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public FareTypeList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public FareTypeList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public FareTypeList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public FareType GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public FareType GetUnique(OQL oql)
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
