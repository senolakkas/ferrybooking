using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
    [Serializable]
    public partial class PaymentType : DomainObject<System.Int32>
    {

        #region Columns Names nested class
        public class Properties
        {
            public static readonly string ID = "ID";
            public static readonly string PaymentTypeName = "PaymentTypeName";
        }
        #endregion

        #region Fields
        private IPaymentTypeDao _dao;
        private System.String _PaymentTypeName;
        private IList<Payment> _Payments = new List<Payment>();
        #endregion

        #region Constructor
        public PaymentType()
        {
        }

        public PaymentType(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.String PaymentTypeName {
             get { return _PaymentTypeName; }
             set { _PaymentTypeName = value;}
         }

         public virtual IList<Payment> Payments{
             get { return _Payments; }
             set { _Payments = value; }
         }

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public IPaymentTypeDao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = DaoFactoryExposer.Instance.DaoFactory.GetPaymentTypeDao();
                return _dao;
            }
        }

        public PaymentType GetById(System.Int32 id, bool shouldLock)
        {
            return Dao.GetById(id, shouldLock);
        }

        public PaymentTypeList GetList()
        {
            return Dao.GetList();
        }

        public PaymentTypeList GetListLikeMe()
        {
            return Dao.GetListByExample(this);
        }

        public PaymentTypeList GetListLikeMe(int startRow, int pageSize)
        {
            return Dao.GetListByExample(this, startRow, pageSize);
        }

        public PaymentTypeList GetList(OQL oql)
        {
            return Dao.GetList(oql);
        }

        public PaymentTypeList GetList(OQL oql, int startRow, int pageSize)
        {
            return Dao.GetList(oql, startRow, pageSize);
        }

        public PaymentType GetUniqueLikeMe()
        {
            return Dao.GetUniqueByExample(this);
        }

        public PaymentType GetUnique(OQL oql)
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
