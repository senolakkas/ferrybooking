using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class RouteOrderPassengerDetailDto : RouteOrderDetailDto
    {

        #region Fields
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
        public RouteOrderPassengerDetailDto()
        {
        }
        public RouteOrderPassengerDetailDto(RouteOrderPassengerDetail routeOrderPassengerDetail) :base(routeOrderPassengerDetail) 
        {
            _CountryID = routeOrderPassengerDetail.CountryID;
            _RequirementID = routeOrderPassengerDetail.RequirementID;
            _Age = routeOrderPassengerDetail.Age;
            _IsLeader = routeOrderPassengerDetail.IsLeader;
            _FirstName = routeOrderPassengerDetail.FirstName;
            _LastName = routeOrderPassengerDetail.LastName;
            _MiddleName = routeOrderPassengerDetail.MiddleName;
            _Title = routeOrderPassengerDetail.Title;
            _Citizenship = routeOrderPassengerDetail.Citizenship;
            _Passport = routeOrderPassengerDetail.Passport;
            _Gender = routeOrderPassengerDetail.Gender;
            _Brithday = routeOrderPassengerDetail.Brithday;
            _Email = routeOrderPassengerDetail.Email;
            _Address1 = routeOrderPassengerDetail.Address1;
            _Address2 = routeOrderPassengerDetail.Address2;
            _City = routeOrderPassengerDetail.City;
            _Province = routeOrderPassengerDetail.Province;
            _Postcode = routeOrderPassengerDetail.Postcode;
            _Cellphone = routeOrderPassengerDetail.Cellphone;
            _Telephone = routeOrderPassengerDetail.Telephone;
            _Fax = routeOrderPassengerDetail.Fax;
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


     }
}
