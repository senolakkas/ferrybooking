using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class SpecialRequirement : DomainObject<System.Int32>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string RequirementDesc = "RequirementDesc";
        }
        #endregion

        #region Fields
        private ISpecialRequirementDao _dao;
        private System.String _RequirementDesc;
        private IList<RouteOrderPassengerDetail> _RouteOrderPassengerDetails = new List<RouteOrderPassengerDetail>();
        #endregion

        #region Constructor
        public SpecialRequirement()
        {
        }

        public SpecialRequirement(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.String RequirementDesc {
             get { return _RequirementDesc; }
             set { _RequirementDesc = value;}
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

        public ISpecialRequirementDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetSpecialRequirementDao();
                return _dao;
            }
        }

        public SpecialRequirement GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public SpecialRequirementList GetList()
        {
            return Dao.GetList();
        }

        public SpecialRequirementList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public SpecialRequirementList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public SpecialRequirementList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public SpecialRequirementList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public SpecialRequirement GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public SpecialRequirement GetUnique(OQL oql)
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
