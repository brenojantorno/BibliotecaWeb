// using System.Collections;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using Microsoft.EntityFrameworkCore;
// using System.Threading.Tasks;


// namespace BibliotecaWeb.Data
// {
//     public class Repository<T> : IRepository<T> where T : class, IBaseId
//     {
//         protected readonly BibliotecaDataContext context;
//         private DbSet<T> entities;

//         public Repository(BibliotecaDataContext _context)
//         {
//             context = _context;
//             entities = context.Set<T>();
//         }

//         public T Load(params object[] Keys)
//         {
//             return context.Set<T>().Find(Keys);
//         }

//         public ValueTask<T> LoadAsync(params object[] Keys)
//         {
//             return context.Set<T>().FindAsync(Keys);
//         }

//         public virtual IQueryable<T> Load(IEnumerable<int> ids)
//         {
//             return context.Set<T>().Where(t => ids.Contains(t.Id));
//         }

//         public IQueryable<T> Collection(Expression<Func<T, bool>> expression)
//         {
//             return context.Set<T>().Where(expression).AsQueryable();
//         }

//         public IQueryable<T> Collection()
//         {
//             return context.Set<T>().AsQueryable();
//         }


//         public void Delete(T entity)
//         {
//             context.Set<T>().Remove(entity);
//         }

//         public void UpdateOrAdd(T entity)
//         {
//             if (entity.Id == 0)
//                 context.Add(entity);
//             else
//             {
//                 var e = context.Set<T>().Find(entity.Id);
//                 if (e != null)
//                     context.Set<T>().Update(entity);
//             }
//         }
//     }
// }