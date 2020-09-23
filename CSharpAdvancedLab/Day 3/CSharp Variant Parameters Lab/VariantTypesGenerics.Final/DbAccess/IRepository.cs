using System;
using System.Linq;

namespace VariantTypesGenerics.Final.DbAccess
{
    public interface IRepository<T> : IReadOnlyRepository<T>, IWriteOnlyRepository<T>
    {
    }

    public interface IReadOnlyRepository<out T> : IDisposable
    {
        T FindById(int id);
        IQueryable<T> FindAll();
    }

    public interface IWriteOnlyRepository<in T> : IDisposable
    {
        int Commit();
        void Add(T newEntity);
        void Delete(T entity);
    }
}