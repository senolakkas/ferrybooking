using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Expression;
using System.Collections;
using System.Data;
using System.Reflection;
using GreenTea.OQL;
using GreenTea.Utils;

namespace GreenTea.DAO
{
    public abstract class AbstractNHibernateDao<T, IdT, ListT> : IDao<T, IdT, ListT>
    {

        /// <summary>
        /// Method that returns a common/simple Criteria for the Domain Object
        /// </summary>
        private ICriteria GetBasicCriteria()
        {
            ICriteria _criteria = NHibernateSession.CreateCriteria(typeof(T), typeof(T).Name);
            if (_criteria == null) throw new NHibernate.MappingException("Failed to create criteria for " + typeof(T).Name);
            return _criteria;
        }

        /// <param name="sessionFactoryConfigFileName">Fully qualified path of the session factory's config file</param>
        public AbstractNHibernateDao()
        {
            
        }

        /// <summary>
        /// Loads an instance of type T from the DB based on its ID.
        /// </summary>
        public T GetById(IdT id, bool shouldLock)
        {
            T entity;

            try
            {
                if (shouldLock)
                {
                    entity = (T)NHibernateSession.Load(typeof(T), id, LockMode.Upgrade);
                }
                else
                {
                    entity = (T)NHibernateSession.Load(typeof(T), id);
                }
            }
            catch(ObjectNotFoundException onfe)
            {
                return default(T);
            }

            return entity;
        }

        /// <summary>
        /// Loads every instance of the requested type with no filtering.
        /// </summary>
        public ListT GetList()
        {
            ListT retList = (ListT)Activator.CreateInstance(typeof(ListT));
            GetBasicCriteria().List((IList)retList);
            return retList;
        }

        public ListT GetList(OQL.OQL oql)
        {

            ICriteria criteria = OQLConvertor.ConvertOQL2NHCriteria(oql).GetExecutableCriteria(NHibernateSession);
            ListT retList = (ListT)Activator.CreateInstance(typeof(ListT));
            criteria.List((IList)retList);

            return retList;
        }

        public ListT GetList(GreenTea.OQL.OQL oql, int startRow, int pageSize)
        {
            ICriteria criteria = OQLConvertor.ConvertOQL2NHCriteria(oql).GetExecutableCriteria(NHibernateSession);
            criteria.SetFirstResult(startRow).SetMaxResults(pageSize);
            ListT retList = (ListT)Activator.CreateInstance(typeof(ListT));
            criteria.List((IList)retList);

            return retList;
        }

        /// <summary>
        /// Looks for a instances using the example provided.
        /// </summary>
        /// <exception cref="NonUniqueResultException" />
        public ListT GetListByExample(T exampleInstance)
        {

            OQL.OQL oql = new OQL.OQL(typeof(T)).AddCondition(OQL.Condition.EqExample(exampleInstance));
            Object o = GetList(oql);
            return (ListT)o;
        }

        public ListT GetListByExample(T exampleInstance,int startRow, int pageSize)
        {
            OQL.OQL oql = new OQL.OQL(typeof(T)).AddCondition(OQL.Condition.EqExample(exampleInstance));
            return GetList(oql, startRow, pageSize);
        }

        public T GetUniqueByExample(T exampleInstance)
        {
            IList foundList = (IList)GetListByExample(exampleInstance);
            if (foundList.Count > 1)
            {
                throw new NonUniqueResultException(foundList.Count);
            }

            if (foundList.Count > 0)
            {
                return (T)foundList[0];
            }
            else
            {
                return default(T);
            }
            
        }

        public T GetUnique(GreenTea.OQL.OQL oql)
        {
            IList foundList = (IList)GetList(oql);
            if (foundList.Count > 1)
            {
                throw new NonUniqueResultException(foundList.Count);
            }

            if (foundList.Count > 0)
            {
                return (T)foundList[0];
            }
            else
            {
                return default(T);
            }
        }
       
        

        /// <summary>
        /// For entities that have assigned ID's, you must explicitly call Save to add a new one.
        /// See http://www.hibernate.org/hib_docs/reference/en/html/mapping.html#mapping-declaration-id-assigned.
        /// </summary>
        public T Create(T entity)
        {
            NHibernateSession.Save(entity);
            return entity;
        }

        /// <summary>
        /// For entities with automatatically generated IDs, such as identity, SaveOrUpdate may 
        /// be called when saving a new entity.  SaveOrUpdate can also be called to _update_ any 
        /// entity, even if its ID is assigned.
        /// </summary>
        public T Update(T entity)
        {
            NHibernateSession.Update(entity);
            return entity;
        }

        public T CreateOrUpdate(T entity)
        {
            NHibernateSession.SaveOrUpdate(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            NHibernateSession.Delete(entity);
        }

        /// <summary>
        /// Commits changes regardless of whether there's an open transaction or not
        /// </summary>
        public void CommitChanges()
        {
            if (NHibernateSessionManager.Instance.HasOpenTransaction())
            {
                NHibernateSessionManager.Instance.CommitTransaction();
            }
            else
            {
                // If there's no transaction, just flush the changes
                NHibernateSessionManager.Instance.GetSession().Flush();
            }
        }

        /// <summary>
        /// Exposes the ISession used within the DAO.
        /// </summary>
        private ISession NHibernateSession
        {
            get
            {
                return NHibernateSessionManager.Instance.GetSession();
            }
        }


        #region IDao<T,IdT,ListT> Members


        public DataTable GetTable(GreenTea.OQL.OQL oql)
        {
            return GetTable(oql, -1, -1);
        }

        public DataTable GetTable(OQL.OQL oql, int startRow, int pageSize)
        {
            ICriteria criteria;
            if(oql.SelectColumns.Count==0)
            {
                criteria = OQLConvertor.ConvertOQL2NHCriteria(oql).GetExecutableCriteria(NHibernateSession);
                if(pageSize>0)
                    criteria.SetFirstResult(startRow).SetMaxResults(pageSize);
                DomainList<T> dl = new DomainList<T>();
                criteria.List(dl);

                return dl.ConvertToDataTable();
            }

            DataTable dt = GetTableSchemaFromOQL(oql);
            criteria = OQLConvertor.ConvertOQL2NHCriteria(oql).GetExecutableCriteria(NHibernateSession);
            if (pageSize > 0)
                criteria.SetFirstResult(startRow).SetMaxResults(pageSize);
            IList list = criteria.List();
            foreach (object o in list)
            {
                DataRow dr = dt.NewRow();
                if (dt.Columns.Count == 1)
                    dr[0] = o==null?(dt.Columns[0].DataType==typeof(string)?null:DBNull.Value):o;
                else
                {
                    object[] objList = (object[])o;
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (objList != null)
                            dr[i] = objList[i] == null ? (dt.Columns[i].DataType==typeof(string) ? null : DBNull.Value) : objList[i];
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }


        private DataTable GetTableSchemaFromOQL(GreenTea.OQL.OQL oql)
        {
            DataTable dt = new DataTable();


            foreach (OQL.SelectColumn sc in oql.SelectColumns)
            {
                string columnName;
                Type columnType = null;

                if (sc.SelectOP == SelectOP.GroupBy) continue;

                if (!string.IsNullOrEmpty(sc.Alias))
                {
                    columnName = sc.Alias;
                }
                else
                {
                    if (sc.PropertyName.IndexOf(".") == -1)
                    {
                        columnName = sc.PropertyName;
                    }
                    else
                    {
                        columnName = (sc.PropertyName.Split('.'))[1];
                    }
                }

                switch (sc.SelectOP)
                {
                    case SelectOP.RowCount:
                        columnType = typeof(Int32);
                        break;
                    case SelectOP.Avg:
                        columnType = typeof(System.Double);
                        break;
                }

                if (columnType == null)
                {
                    if (sc.PropertyName.IndexOf(".") == -1)
                    {
                        columnType = GetPropretyTypeForTableSchema(sc.PropertyName, oql.DomainObjectType);
                    }
                    else
                    {
                        string assoAlias = (sc.PropertyName.Split('.'))[0];
                        string assoName = null;
                        foreach (Association asso in oql.Associations)
                        {
                            if (asso.Alias == assoAlias)
                                assoName = asso.AssociationName;
                        }

                        PropertyInfo pi = oql.DomainObjectType.GetProperty(assoName);

                        Check.Ensure(pi != null,
                        string.Format("Can't found the property name:{0} in the class {1} when try to get table schema",
                        string.IsNullOrEmpty(assoName)?"null":assoName, oql.DomainObjectType.Name));

                        columnType = GetPropretyTypeForTableSchema((sc.PropertyName.Split('.'))[1], pi.PropertyType);
                    }
                }

                DataColumn dc = new DataColumn(columnName, columnType);
                dt.Columns.Add(dc);

            }
            return dt;
        }

        private Type GetPropretyTypeForTableSchema(string propertyName, Type objectType)
        {
            PropertyInfo pi = objectType.GetProperty(propertyName);
            Check.Ensure(pi != null,
                string.Format("Can't found the property name:{0} in the class {1} when try to get table schema",
                propertyName, objectType.Name));
            Check.Ensure(pi.PropertyType.IsValueType || pi.PropertyType.Name.ToLower() == "string",
                string.Format("The property:{0} in class {1} is not a value type, can not be convert to table schema",
                propertyName, objectType.Name));
            Type t = pi.PropertyType.Name.StartsWith("Nullable") ? pi.PropertyType.GetProperty("Value").PropertyType : pi.PropertyType;
            return t;
        }
        #endregion
    }
}
