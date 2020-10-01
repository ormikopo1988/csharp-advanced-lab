using System;
using System.Collections.Generic;
using System.Text;

namespace VariantTypesGenerics.Starter.DbAccess
{
    public interface IWriteRepo<in T>
    {
        void Add(T newEntity);
        void Delete(T entity);
        int Commit();
    }
}
