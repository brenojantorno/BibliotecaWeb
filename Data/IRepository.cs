using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
namespace BibliotecaWeb.Data
{
    public interface IRepository<T> where T : IBaseId
    {
        IQueryable<T> Collection(Expression<Func<T, bool>> conditions);
        IQueryable<T> Collection();
        ValueTask<T> LoadAsync(params object[] KeyValues);
        T Load(params object[] KeyValues);
        void AddOrUpdate(T entity);
        void Delete(T entity);
    }
}