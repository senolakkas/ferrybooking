using System;
using System.Collections.Generic;
using System.Text;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

namespace ByteCore.FerryBooking.Core
{
    public sealed class DaoFactoryExposer
    {
        private IDaoFactory _daoFactory = null;

        public static DaoFactoryExposer Instance
        {
            get
            {
                return Nested.DaoFactoryExposer;
            }
        }

        private DaoFactoryExposer()
        {
            InitDaoFactory();
        }

        private void InitDaoFactory()
        {
            IWindsorContainer container = new WindsorContainer(new XmlInterpreter());
            _daoFactory = container["DaoFactory"] as IDaoFactory;
        }

        private class Nested
        {
            static Nested() { }
            internal static readonly DaoFactoryExposer DaoFactoryExposer = new DaoFactoryExposer();
        }

        public IDaoFactory DaoFactory
        {
            get
            {
                if (_daoFactory != null)
                {
                    return _daoFactory;
                }
                else
                {
                    throw new TypeLoadException("Can not load dao factory from container!");
                }
            }
        }
        
    }
}
