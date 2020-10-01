using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VariantTypesGenerics.Starter.DbAccess
{
    public interface IReadRepo<out T>
    {
        T FindById(int id);
        IQueryable<T> FindAll();
    }
}
