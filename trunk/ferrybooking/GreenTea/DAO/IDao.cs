using System;
using System.Collections.Generic;
using System.Text;
using GreenTea.OQL;
using System.Data;

namespace GreenTea.DAO
{
    public interface IDao<T, IdT, ListT>
    {
        T GetById(IdT id, bool shouldLock);
        ListT GetList();
        ListT GetListByExample(T exampleInstance);
        ListT GetListByExample(T exampleInstance, int startRow, int pageSize);
        ListT GetList(GreenTea.OQL.OQL oql);
        ListT GetList(GreenTea.OQL.OQL oql, int startRow, int pageSize);
        T GetUniqueByExample(T exampleInstance);
        T GetUnique(GreenTea.OQL.OQL oql);
        T Create(T entity);
        T Update(T entity);
        T CreateOrUpdate(T entity);
        void Delete(T entity);
        void CommitChanges();
        DataTable GetTable(GreenTea.OQL.OQL oql);
        DataTable GetTable(GreenTea.OQL.OQL oql, int startRow, int pageSize);
    }
}
