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
            public static readonly string IsLeader = "IsLeader";
            public static readonly string FirstName = "FirstName";
            public static readonly string LastName = "LastName";
            public static readonly string MiddleName = "MiddleName";
            public static readonly string Title = "Title";
            public static readonly string Citizenship = "Citizenship";
            public static readonly string Passport = "Passport";
            public static readonly string Gender = "Gender";
            public static readonly string Brithday = "Brithday";
            public static readonly string Email = "Email";
            public static readonly string Address1 = "Address1";
            public static readonly string Address2 = "Address2";
            public static readonly string City = "City";
            public static readonly string Province = "Province";
            public static readonly string Postcode = "Postcode";
            public static readonly string Cellphone = "Cellphone";
            public static readonly string Telephone = "Telephone";
            public static readonly string Fax = "Fax";
        }
        #endregion

        #region Fields
        private IRouteOrderPassengerDetailDao _dao;
        private System.Int32? _CountryID;
        private System.Int32? _RequirementID;
        private System.Int32? _Age;
        private System.Boolean? _IsLeader;
        private System.String _FirstName;
        private System.String _LastName;
        private System.String _MiddleName;
        private System.String _Title;
        private System.String _Citizenship;
        private System.String _Passport;
        private System.String _Gender;
        private System.DateTime? _Brithday;
        private System.String _Email;
        private System.String _Address1;
        private System.String _Address2;
        private System.String _City;
        private System.String _Province;
        private System.String _Postcode;
        private System.String _Cellphone;
        private System.String _Telephone;
        private System.String _Fax;
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

         public virtual System.Boolean? IsLeader {
             get { return _IsLeader; }
             set { _IsLeader = value;}
         }

         public virtual System.String FirstName {
             get { return _FirstName; }
             set { _FirstName = value;}
         }

         public virtual System.String LastName {
             get { return _LastName; }
             set { _LastName = value;}
         }

         public virtual System.String MiddleName {
             get { return _MiddleName; }
             set { _MiddleName = value;}
         }

         public virtual System.String Title {
             get { return _Title; }
             set { _Title = value;}
         }

         public virtual System.String Citizenship {
             get { return _Citizenship; }
             set { _Citizenship = value;}
         }

         public virtual System.String Passport {
             get { return _Passport; }
             set { _Passport = value;}
         }

         public virtual System.String Gender {
             get { return _Gender; }
             set { _Gender = value;}
         }

         public virtual System.DateTime? Brithday {
             get { return _Brithday; }
             set { _Brithday = value;}
         }

         public virtual System.String Email {
             get { return _Email; }
             set { _Email = value;}
         }

         public virtual System.String Address1 {
             get { return _Address1; }
             set { _Address1 = value;}
         }

         public virtual System.String Address2 {
             get { return _Address2; }
             set { _Address2 = value;}
         }

         public virtual System.String City {
             get { return _City; }
             set { _City = value;}
         }

         public virtual System.String Province {
             get { return _Province; }
             set { _Province = value;}
         }

         public virtual System.String Postcode {
             get { return _Postcode; }
             set { _Postcode = value;}
         }

         public virtual System.String Cellphone {
             get { return _Cellphone; }
             set { _Cellphone = value;}
         }

         public virtual System.String Telephone {
             get { return _Telephone; }
             set { _Telephone = value;}
         }

         public virtual System.String Fax {
             get { return _Fax; }
             set { _Fax = value;}
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
