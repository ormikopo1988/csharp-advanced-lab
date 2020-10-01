using System;
using System.Linq;

namespace VariantTypesGenerics.Starter.DbAccess
{
    public interface IRepositoryWriteOnly<in T> : IDisposable
    {
        void Add(T newEntity);
        void Delete(T entity);
        int Commit();

    }
    public interface IRepositoryReadOnly<out T> : IDisposable
    {
        T FindById(int id);
        IQueryable<T> FindAll();
    }
    public interface IRepository<T> : IRepositoryReadOnly<T>, IRepositoryWriteOnly<T>
    {
    }

 
}