using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class Season : DomainObject<System.Int32>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string OperatorId = "OperatorId";
            public static readonly string StartMonth = "StartMonth";
            public static readonly string StartDay = "StartDay";
            public static readonly string EndMonth = "EndMonth";
            public static readonly string EndDay = "EndDay";
        }
        #endregion

        #region Fields
        private ISeasonDao _dao;
        private System.Int32? _OperatorId;
        private System.Int32? _StartMonth;
        private System.Int32? _StartDay;
        private System.Int32? _EndMonth;
        private System.Int32? _EndDay;
        private Company _Operator;
        #endregion

        #region Constructor
        public Season()
        {
        }

        public Season(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.Int32? OperatorId {
             get { return _OperatorId; }
             set { _OperatorId = value;}
         }

         public virtual System.Int32? StartMonth {
             get { return _StartMonth; }
             set { _StartMonth = value;}
         }

         public virtual System.Int32? StartDay {
             get { return _StartDay; }
             set { _StartDay = value;}
         }

         public virtual System.Int32? EndMonth {
             get { return _EndMonth; }
             set { _EndMonth = value;}
         }

         public virtual System.Int32? EndDay {
             get { return _EndDay; }
             set { _EndDay = value;}
         }

         public virtual Company Operator{
             get { return _Operator; }
             set { _Operator = value;}
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public ISeasonDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetSeasonDao();
                return _dao;
            }
        }

        public Season GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public SeasonList GetList()
        {
            return Dao.GetList();
        }

        public SeasonList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public SeasonList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public SeasonList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public SeasonList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public Season GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public Season GetUnique(OQL oql)
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
