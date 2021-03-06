﻿using Microsoft.EntityFrameworkCore;
using System.Linq;
using VariantTypesGenerics.Final.Models;

namespace VariantTypesGenerics.Final.DbAccess
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