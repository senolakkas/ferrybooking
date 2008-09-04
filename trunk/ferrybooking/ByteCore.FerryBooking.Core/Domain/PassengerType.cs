using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class PassengerType : FareType
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string OperatorId = "OperatorId";
            public static readonly string CategoryId = "CategoryId";
            public static readonly string FareTypeName = "FareTypeName";
            public static readonly string FareTypeDescription = "FareTypeDescription";
            public static readonly string MinAge = "MinAge";
            public static readonly string MaxAge = "MaxAge";
        }
        #endregion

        #region Fields
        private IPassengerTypeDao _dao;
        private System.Int32? _MinAge;
        private System.Int32? _MaxAge;
        #endregion

        #region Constructor
        public PassengerType()
        {
        }

        public PassengerType(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.Int32? MinAge {
             get { return _MinAge; }
             set { _MinAge = value;}
         }

         public virtual System.Int32? MaxAge {
             get { return _MaxAge; }
             set { _MaxAge = value;}
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public IPassengerTypeDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetPassengerTypeDao();
                return _dao;
            }
        }

        public PassengerType GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public PassengerTypeList GetList()
        {
            return Dao.GetList();
        }

        public PassengerTypeList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public PassengerTypeList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public PassengerTypeList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public PassengerTypeList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public PassengerType GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public PassengerType GetUnique(OQL oql)
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
