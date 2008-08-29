using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class sysdiagram : DomainObject<System.Int32>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string name = "name";
            public static readonly string principalid = "principalid";
            public static readonly string version = "version";
            public static readonly string definition = "definition";
        }
        #endregion

        #region Fields
        private IsysdiagramDao _dao;
        private System.String _name;
        private System.Int32 _principalid;
        private System.Int32? _version;
        private System.Byte[] _definition;
        #endregion

        #region Constructor
        public sysdiagram()
        {
        }

        public sysdiagram(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.String name {
             get { return _name; }
             set { _name = value;}
         }

         public virtual System.Int32 principalid {
             get { return _principalid; }
             set { _principalid = value;}
         }

         public virtual System.Int32? version {
             get { return _version; }
             set { _version = value;}
         }

         public virtual System.Byte[] definition {
             get { return _definition; }
             set { _definition = value;}
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public IsysdiagramDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetsysdiagramDao();
                return _dao;
            }
        }

        public sysdiagram GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public sysdiagramList GetList()
        {
            return Dao.GetList();
        }

        public sysdiagramList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public sysdiagramList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public sysdiagramList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public sysdiagramList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public sysdiagram GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public sysdiagram GetUnique(OQL oql)
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
