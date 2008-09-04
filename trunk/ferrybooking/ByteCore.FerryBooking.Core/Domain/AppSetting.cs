using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class AppSetting : DomainObject<System.String>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string SettingValue = "SettingValue";
        }
        #endregion

        #region Fields
        private IAppSettingDao _dao;
        private System.String _SettingValue;
        #endregion

        #region Constructor
        public AppSetting()
        {
        }

        public AppSetting(System.String id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.String SettingValue {
             get { return _SettingValue; }
             set { _SettingValue = value;}
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public IAppSettingDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetAppSettingDao();
                return _dao;
            }
        }

        public AppSetting GetById(System.String id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public AppSettingList GetList()
        {
            return Dao.GetList();
        }

        public AppSettingList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public AppSettingList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public AppSettingList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public AppSettingList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public AppSetting GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public AppSetting GetUnique(OQL oql)
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
