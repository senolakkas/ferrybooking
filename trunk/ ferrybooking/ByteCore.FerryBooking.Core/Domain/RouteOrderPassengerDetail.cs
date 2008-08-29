using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class RouteOrderPassengerDetail : RouteOrderDetail
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string FareTypeId = "FareTypeId";
            public static readonly string RouteOrderID = "RouteOrderID";
            public static readonly string Quantity = "Quantity";
            public static readonly string Amount = "Amount";
            public static readonly string CountryID = "CountryID";
            public static readonly string RequirementID = "RequirementID";
            public static readonly string Age = "Age";
            public static readonly string IsLeader2 = "IsLeader2";
            public static readonly string FirstName2 = "FirstName2";
            public static readonly string LastName2 = "LastName2";
            public static readonly string MiddleName2 = "MiddleName2";
            public static readonly string Title2 = "Title2";
            public static readonly string Citizenship2 = "Citizenship2";
            public static readonly string Passport2 = "Passport2";
            public static readonly string Gender2 = "Gender2";
            public static readonly string Brithday2 = "Brithday2";
            public static readonly string Email2 = "Email2";
            public static readonly string Address3 = "Address3";
            public static readonly string Address4 = "Address4";
            public static readonly string City2 = "City2";
            public static readonly string Province2 = "Province2";
            public static readonly string Postcode2 = "Postcode2";
            public static readonly string Cellphone2 = "Cellphone2";
            public static readonly string Telephone2 = "Telephone2";
            public static readonly string Fax2 = "Fax2";
        }
        #endregion

        #region Fields
        private IRouteOrderPassengerDetailDao _dao;
        private System.Int32? _CountryID;
        private System.Int32? _RequirementID;
        private System.Int32? _Age;
        private System.Boolean? _IsLeader2;
        private System.String _FirstName2;
        private System.String _LastName2;
        private System.String _MiddleName2;
        private System.String _Title2;
        private System.String _Citizenship2;
        private System.String _Passport2;
        private System.String _Gender2;
        private System.DateTime? _Brithday2;
        private System.String _Email2;
        private System.String _Address3;
        private System.String _Address4;
        private System.String _City2;
        private System.String _Province2;
        private System.String _Postcode2;
        private System.String _Cellphone2;
        private System.String _Telephone2;
        private System.String _Fax2;
        #endregion

        #region Constructor
        public RouteOrderPassengerDetail()
        {
        }

        public RouteOrderPassengerDetail(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.Int32? CountryID {
             get { return _CountryID; }
             set { _CountryID = value;}
         }

         public virtual System.Int32? RequirementID {
             get { return _RequirementID; }
             set { _RequirementID = value;}
         }

         public virtual System.Int32? Age {
             get { return _Age; }
             set { _Age = value;}
         }

         public virtual System.Boolean? IsLeader2 {
             get { return _IsLeader2; }
             set { _IsLeader2 = value;}
         }

         public virtual System.String FirstName2 {
             get { return _FirstName2; }
             set { _FirstName2 = value;}
         }

         public virtual System.String LastName2 {
             get { return _LastName2; }
             set { _LastName2 = value;}
         }

         public virtual System.String MiddleName2 {
             get { return _MiddleName2; }
             set { _MiddleName2 = value;}
         }

         public virtual System.String Title2 {
             get { return _Title2; }
             set { _Title2 = value;}
         }

         public virtual System.String Citizenship2 {
             get { return _Citizenship2; }
             set { _Citizenship2 = value;}
         }

         public virtual System.String Passport2 {
             get { return _Passport2; }
             set { _Passport2 = value;}
         }

         public virtual System.String Gender2 {
             get { return _Gender2; }
             set { _Gender2 = value;}
         }

         public virtual System.DateTime? Brithday2 {
             get { return _Brithday2; }
             set { _Brithday2 = value;}
         }

         public virtual System.String Email2 {
             get { return _Email2; }
             set { _Email2 = value;}
         }

         public virtual System.String Address3 {
             get { return _Address3; }
             set { _Address3 = value;}
         }

         public virtual System.String Address4 {
             get { return _Address4; }
             set { _Address4 = value;}
         }

         public virtual System.String City2 {
             get { return _City2; }
             set { _City2 = value;}
         }

         public virtual System.String Province2 {
             get { return _Province2; }
             set { _Province2 = value;}
         }

         public virtual System.String Postcode2 {
             get { return _Postcode2; }
             set { _Postcode2 = value;}
         }

         public virtual System.String Cellphone2 {
             get { return _Cellphone2; }
             set { _Cellphone2 = value;}
         }

         public virtual System.String Telephone2 {
             get { return _Telephone2; }
             set { _Telephone2 = value;}
         }

         public virtual System.String Fax2 {
             get { return _Fax2; }
             set { _Fax2 = value;}
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public IRouteOrderPassengerDetailDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetRouteOrderPassengerDetailDao();
                return _dao;
            }
        }

        public RouteOrderPassengerDetail GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public RouteOrderPassengerDetailList GetList()
        {
            return Dao.GetList();
        }

        public RouteOrderPassengerDetailList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public RouteOrderPassengerDetailList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public RouteOrderPassengerDetailList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public RouteOrderPassengerDetailList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public RouteOrderPassengerDetail GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public RouteOrderPassengerDetail GetUnique(OQL oql)
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
