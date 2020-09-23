using System;
using System.Linq;

namespace VariantTypesGenerics.Starter.DbAccess
{
    public interface IRepository<T> : IDisposable
    {
        void Add(T newEntity);
        void Delete(T entity);
        int Commit();
        T FindById(int id);
        IQueryable<T> FindAll();
    }
}