using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class FareItem : DomainObject<System.Int32>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string FareTypeId = "FareTypeId";
            public static readonly string FareId = "FareId";
            public static readonly string Amount = "Amount";
            public static readonly string RangeStart = "RangeStart";
            public static readonly string RangeEnd = "RangeEnd";
            public static readonly string ByFootAmount = "ByFootAmount";
            public static readonly string RoundTripDiscount = "RoundTripDiscount";
        }
        #endregion

        #region Fields
        private IFareItemDao _dao;
        private System.Int32? _FareTypeId;
        private System.Int32? _FareId;
        private System.Decimal? _Amount;
        private System.Int32? _RangeStart;
        private System.Int32? _RangeEnd;
        private System.Decimal? _ByFootAmount;
        private System.Decimal? _RoundTripDiscount;
        private Fare _Fare;
        private FareType _FareType;
        #endregion

        #region Constructor
        public FareItem()
        {
        }

        public FareItem(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.Int32? FareTypeId {
             get { return _FareTypeId; }
             set { _FareTypeId = value;}
         }

         public virtual System.Int32? FareId {
             get { return _FareId; }
             set { _FareId = value;}
         }

         public virtual System.Decimal? Amount {
             get { return _Amount; }
             set { _Amount = value;}
         }

         public virtual System.Int32? RangeStart {
             get { return _RangeStart; }
             set { _RangeStart = value;}
         }

         public virtual System.Int32? RangeEnd {
             get { return _RangeEnd; }
             set { _RangeEnd = value;}
         }

         public virtual System.Decimal? ByFootAmount {
             get { return _ByFootAmount; }
             set { _ByFootAmount = value;}
         }

         public virtual System.Decimal? RoundTripDiscount {
             get { return _RoundTripDiscount; }
             set { _RoundTripDiscount = value;}
         }

         public virtual Fare Fare{
             get { return _Fare; }
             set { _Fare = value;}
         }

         public virtual FareType FareType{
             get { return _FareType; }
             set { _FareType = value;}
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public IFareItemDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetFareItemDao();
                return _dao;
            }
        }

        public FareItem GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public FareItemList GetList()
        {
            return Dao.GetList();
        }

        public FareItemList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public FareItemList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public FareItemList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public FareItemList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public FareItem GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public FareItem GetUnique(OQL oql)
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
