using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VariantTypesGenerics.Starter.Models;

namespace VariantTypesGenerics.Starter.DbAccess
{
    public class SqlLiteRepository<T> : IRepository<T>
        where T : class, IEntity
    {
        DbContext _ctx;
        DbSet<T> _set;

        public SqlLiteRepository(DbContext ctx)
        {
            _ctx = ctx;
            _set = _ctx.Set<T>();
        }

        public void Add(T newEntity)
        {
            if (newEntity.IsValid())
            {
                _set.Add(newEntity);
            }
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
        }

        public T FindById(int id)
        {
            return _set.Find(id);
        }

        public IQueryable<T> FindAll()
        {
            return _set;
        }

        public int Commit()
        {
            return _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
