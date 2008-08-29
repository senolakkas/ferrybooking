using System;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class RouteOrderDetailDto
    {

        #region Fields
        private System.Int32 _RouteOrderDetailId;
        private System.Int32? _FareTypeId;
        private System.Int32? _RouteOrderID;
        private System.Int32? _Quantity;
        private System.Decimal? _Amount;
        #endregion

        #region Constructor
        public RouteOrderDetailDto()
        {
        }
        public RouteOrderDetailDto(RouteOrderDetail routeOrderDetail)
        {
            _RouteOrderDetailId = routeOrderDetail.ID;
            _FareTypeId = routeOrderDetail.FareTypeId;
            _RouteOrderID = routeOrderDetail.RouteOrderID;
            _Quantity = routeOrderDetail.Quantity;
            _Amount = routeOrderDetail.Amount;
        }

        #endregion

        #region Properties
         public virtual System.Int32 RouteOrderDetailId {
             get { return _RouteOrderDetailId; }
             set { _RouteOrderDetailId = value;}
         }

         public virtual System.Int32? FareTypeId {
             get { return _FareTypeId; }
             set { _FareTypeId = value;}
         }

         public virtual System.Int32? RouteOrderID {
             get { return _RouteOrderID; }
             set { _RouteOrderID = value;}
         }

         public virtual System.Int32? Quantity {
             get { return _Quantity; }
             set { _Quantity = value;}
         }

         public virtual System.Decimal? Amount {
             get { return _Amount; }
             set { _Amount = value;}
         }

        #endregion


     }
}
