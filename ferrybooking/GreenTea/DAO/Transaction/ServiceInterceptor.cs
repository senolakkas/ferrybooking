using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Castle.DynamicProxy;
using System.Reflection;


namespace GreenTea.DAO.Transaction
{
    public class ServiceInterceptor : StandardInterceptor
    {
        //protected override void PreProceed(IInvocation invocation, params object[] args)
        //{

        //    base.PreProceed(invocation, args);
        //}

        //protected override void PostProceed(IInvocation invocation, ref object returnValue, params object[] args)
        //{
        //    base.PostProceed(invocation, ref returnValue, args);
        //}

        public override object Intercept(IInvocation invocation, params object[] args)
        {
            object o;
            object[] attributes = null;
            attributes = invocation.Method.GetCustomAttributes(typeof(OpenSessionAttribute), true);
            if (attributes == null || attributes.Length != 1)
                return base.Intercept(invocation, args);

            OpenSessionAttribute ta = (OpenSessionAttribute)attributes[0];
            if (ta.ReadOnly)
                NHibernateSessionManager.Instance.OpenSession(true);
            else
                NHibernateSessionManager.Instance.BeginTransaction();

            try
            {
                o = base.Intercept(invocation, args);
                if (ta.ReadOnly)
                    NHibernateSessionManager.Instance.CloseSession();
                else
                    NHibernateSessionManager.Instance.CommitTransaction();

            }
            catch
            {
                if (ta.ReadOnly)
                    NHibernateSessionManager.Instance.CloseSession();
                else
                    NHibernateSessionManager.Instance.RollbackTransaction();
                throw;
            }
            return o;
        }
    }
}
