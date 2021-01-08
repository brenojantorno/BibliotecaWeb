using System;
using System.Linq.Expressions;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BibliotecaWeb.Data
{
    public class GenericRepository<T> : IRepository<T> where T : class, IBaseId
    {
        private readonly BibliotecaDataContext context;
        private DbSet<T> entities;

        public GenericRepository(BibliotecaDataContext _db)
        {
            context = _db;
            entities = _db.Set<T>();
        }

        public IQueryable<T> Collection(Expression<Func<T, bool>> conditions)
        {
            return entities.Where(conditions).AsNoTracking().AsQueryable();
        }

        public IQueryable<T> Collection()
        {
            return entities.AsNoTracking().AsQueryable();
        }

        public ValueTask<T> LoadAsync(params object[] KeyValues)
        {
            return entities.FindAsync(KeyValues);
        }

        public T Load(params object[] KeyValues)
        {
            return entities.Find(KeyValues);
        }

        public void AddOrUpdate(T element)
        {
            if (Load(element.Id) != null)
                entities.Update(element);
            else
                entities.Add(element);
        }

        public void Delete(T element)
        {
            if (context.Set<T>().Any(e => e.Id == element.Id))
                context.Set<T>().Remove(element);
        }
    }
}