using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class FareCategory : DomainObject<System.Int32>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string CategoryName = "CategoryName";
        }
        #endregion

        #region Fields
        private IFareCategoryDao _dao;
        private System.String _CategoryName;
        private IList<FareType> _FareTypes = new List<FareType>();
        #endregion

        #region Constructor
        public FareCategory()
        {
        }

        public FareCategory(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.String CategoryName {
             get { return _CategoryName; }
             set { _CategoryName = value;}
         }

         public virtual IList<FareType> FareTypes{
             get { return _FareTypes; }
             set { _FareTypes = value; }
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public IFareCategoryDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetFareCategoryDao();
                return _dao;
            }
        }

        public FareCategory GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public FareCategoryList GetList()
        {
            return Dao.GetList();
        }

        public FareCategoryList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public FareCategoryList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public FareCategoryList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public FareCategoryList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public FareCategory GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public FareCategory GetUnique(OQL oql)
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
