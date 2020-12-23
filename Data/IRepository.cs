using System.Reflection.Metadata;
using System.Linq;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BibliotecaWeb.Data
{
    public interface IRepository<T> where T : class
    {
        T Load(params object[] keyValues);
        IQueryable<T> Load(IEnumerable<int> ids);
        ValueTask<T> LoadAsync(params object[] keyValues);
        IQueryable<T> Collection(Expression<Func<T, bool>> where);
        void UpdateOrAdd(T entity);
        void Delete(T entity);
    }
}