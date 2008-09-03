using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class Company : DomainObject<System.Int32>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string CurrencyId = "CurrencyId";
            public static readonly string CompanyName = "CompanyName";
            public static readonly string CompanyShortName = "CompanyShortName";
            public static readonly string LogoImage = "LogoImage";
            public static readonly string Terms = "Terms";
            public static readonly string IsActive = "IsActive";
        }
        #endregion

        #region Fields
        private ICompanyDao _dao;
        private System.Int32? _CurrencyId;
        private System.String _CompanyName;
        private System.String _CompanyShortName;
        private System.String _LogoImage;
        private System.String _Terms;
        private System.Boolean? _IsActive;
        private Currency _Currency;
        private IList<FareType> _FareTypes = new List<FareType>();
        private IList<Route> _Routes = new List<Route>();
        private IList<Season> _Seasons = new List<Season>();
        private IList<VehicleAdditionPriceSetting> _VehicleAdditionPriceSettings = new List<VehicleAdditionPriceSetting>();
        private IList<Vessel> _Vessels = new List<Vessel>();
        #endregion

        #region Constructor
        public Company()
        {
        }

        public Company(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.Int32? CurrencyId {
             get { return _CurrencyId; }
             set { _CurrencyId = value;}
         }

         public virtual System.String CompanyName {
             get { return _CompanyName; }
             set { _CompanyName = value;}
         }

         public virtual System.String CompanyShortName {
             get { return _CompanyShortName; }
             set { _CompanyShortName = value;}
         }

         public virtual System.String LogoImage {
             get { return _LogoImage; }
             set { _LogoImage = value;}
         }

         public virtual System.String Terms {
             get { return _Terms; }
             set { _Terms = value;}
         }

         public virtual System.Boolean? IsActive {
             get { return _IsActive; }
             set { _IsActive = value;}
         }

         public virtual Currency Currency{
             get { return _Currency; }
             set { _Currency = value;}
         }

         public virtual IList<FareType> FareTypes{
             get { return _FareTypes; }
             set { _FareTypes = value; }
         }

         public virtual IList<Route> Routes{
             get { return _Routes; }
             set { _Routes = value; }
         }

         public virtual IList<Season> Seasons{
             get { return _Seasons; }
             set { _Seasons = value; }
         }

         public virtual IList<VehicleAdditionPriceSetting> VehicleAdditionPriceSettings{
             get { return _VehicleAdditionPriceSettings; }
             set { _VehicleAdditionPriceSettings = value; }
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

        public ICompanyDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetCompanyDao();
                return _dao;
            }
        }

        public Company GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public CompanyList GetList()
        {
            return Dao.GetList();
        }

        public CompanyList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public CompanyList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public CompanyList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public CompanyList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public Company GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public Company GetUnique(OQL oql)
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
