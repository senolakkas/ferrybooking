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
        public RouteOrderPassengerDetailDto()
        {
        }
        public RouteOrderPassengerDetailDto(RouteOrderPassengerDetail routeOrderPassengerDetail)
            : base(routeOrderPassengerDetail)
        {
            _CountryID = routeOrderPassengerDetail.CountryID;
            _RequirementID = routeOrderPassengerDetail.RequirementID;
            _Age = routeOrderPassengerDetail.Age;
            _IsLeader2 = routeOrderPassengerDetail.IsLeader2;
            _FirstName2 = routeOrderPassengerDetail.FirstName2;
            _LastName2 = routeOrderPassengerDetail.LastName2;
            _MiddleName2 = routeOrderPassengerDetail.MiddleName2;
            _Title2 = routeOrderPassengerDetail.Title2;
            _Citizenship2 = routeOrderPassengerDetail.Citizenship2;
            _Passport2 = routeOrderPassengerDetail.Passport2;
            _Gender2 = routeOrderPassengerDetail.Gender2;
            _Brithday2 = routeOrderPassengerDetail.Brithday2;
            _Email2 = routeOrderPassengerDetail.Email2;
            _Address3 = routeOrderPassengerDetail.Address3;
            _Address4 = routeOrderPassengerDetail.Address4;
            _City2 = routeOrderPassengerDetail.City2;
            _Province2 = routeOrderPassengerDetail.Province2;
            _Postcode2 = routeOrderPassengerDetail.Postcode2;
            _Cellphone2 = routeOrderPassengerDetail.Cellphone2;
            _Telephone2 = routeOrderPassengerDetail.Telephone2;
            _Fax2 = routeOrderPassengerDetail.Fax2;
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


     }
}
