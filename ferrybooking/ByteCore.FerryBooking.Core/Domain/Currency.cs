using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class Currency : DomainObject<System.Int32>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string CurrencySymbol = "CurrencySymbol";
        }
        #endregion

        #region Fields
        private ICurrencyDao _dao;
        private System.String _CurrencySymbol;
        private IList<Company> _Companies = new List<Company>();
        #endregion

        #region Constructor
        public Currency()
        {
        }

        public Currency(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.String CurrencySymbol {
             get { return _CurrencySymbol; }
             set { _CurrencySymbol = value;}
         }

         public virtual IList<Company> Companies{
             get { return _Companies; }
             set { _Companies = value; }
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public ICurrencyDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetCurrencyDao();
                return _dao;
            }
        }

        public Currency GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public CurrencyList GetList()
        {
            return Dao.GetList();
        }

        public CurrencyList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public CurrencyList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public CurrencyList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public CurrencyList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public Currency GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public Currency GetUnique(OQL oql)
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
