using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Castle.DynamicProxy;
using System.Reflection;


namespace GreenTea.DAO.Transaction
{
    public sealed class ServiceFactory
    {
        private Hashtable _servicesHashtable;
        private ProxyGenerator _proxyGenerator;

        public static ServiceFactory Instance
        {
            get
            {
                return Nested.ServiceFactory;
            }
        }

        private ServiceFactory()
        {
            InitDaoFactory();
        }

        private void InitDaoFactory()
        {
            _servicesHashtable = new Hashtable();
            _proxyGenerator = new ProxyGenerator();
        }

        private class Nested
        {
            static Nested() { }
            internal static readonly ServiceFactory ServiceFactory = new ServiceFactory();
        }

        public T GetService<T>()
        {
            string hashKey = typeof(T).FullName;

            if (!_servicesHashtable.ContainsKey(hashKey))
            {
                foreach (MethodInfo method in typeof(T).GetMethods())
                {
                    object[] attrs = method.GetCustomAttributes(typeof(OpenSessionAttribute),true);
                    if (attrs != null && attrs.Length > 0 && !method.IsVirtual)
                    {
                        throw new MethodAccessException("The Method "+typeof(T).Name + "." + method.Name 
                            + "(...) needs open session, so it must be declared as Virtual");
                    }
                }
                _servicesHashtable.Add(hashKey, _proxyGenerator.CreateClassProxy(typeof(T), new ServiceInterceptor()));
            }
            
            return (T)_servicesHashtable[hashKey];
            

        }

    }

    
}
