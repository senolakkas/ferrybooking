using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class Country : DomainObject<System.Int32>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string CountryName = "CountryName";
        }
        #endregion

        #region Fields
        private ICountryDao _dao;
        private System.String _CountryName;
        private IList<RouteOrderPassengerDetail> _RouteOrderPassengerDetails = new List<RouteOrderPassengerDetail>();
        #endregion

        #region Constructor
        public Country()
        {
        }

        public Country(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.String CountryName {
             get { return _CountryName; }
             set { _CountryName = value;}
         }

         public virtual IList<RouteOrderPassengerDetail> RouteOrderPassengerDetails{
             get { return _RouteOrderPassengerDetails; }
             set { _RouteOrderPassengerDetails = value; }
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public ICountryDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetCountryDao();
                return _dao;
            }
        }

        public Country GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public CountryList GetList()
        {
            return Dao.GetList();
        }

        public CountryList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public CountryList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public CountryList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public CountryList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public Country GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public Country GetUnique(OQL oql)
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
