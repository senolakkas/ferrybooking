using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class Payment : DomainObject<System.Int32>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string BookingID = "BookingID";
            public static readonly string PaymentTypeId = "PaymentTypeId";
            public static readonly string ResponseMessage = "ResponseMessage";
        }
        #endregion

        #region Fields
        private IPaymentDao _dao;
        private System.Int32? _BookingID;
        private System.Int32? _PaymentTypeId;
        private System.String _ResponseMessage;
        private Booking _Booking;
        private PaymentType _PaymentType;
        #endregion

        #region Constructor
        public Payment()
        {
        }

        public Payment(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.Int32? BookingID {
             get { return _BookingID; }
             set { _BookingID = value;}
         }

         public virtual System.Int32? PaymentTypeId {
             get { return _PaymentTypeId; }
             set { _PaymentTypeId = value;}
         }

         public virtual System.String ResponseMessage {
             get { return _ResponseMessage; }
             set { _ResponseMessage = value;}
         }

         public virtual Booking Booking{
             get { return _Booking; }
             set { _Booking = value;}
         }

         public virtual PaymentType PaymentType{
             get { return _PaymentType; }
             set { _PaymentType = value;}
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public IPaymentDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetPaymentDao();
                return _dao;
            }
        }

        public Payment GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public PaymentList GetList()
        {
            return Dao.GetList();
        }

        public PaymentList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public PaymentList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public PaymentList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public PaymentList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public Payment GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public Payment GetUnique(OQL oql)
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
