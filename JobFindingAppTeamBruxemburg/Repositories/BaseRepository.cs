using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KooliProjekt.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        public ApplicationDbContext DataContext { get; private set; }

        public BaseRepository(ApplicationDbContext context)
        {
            DataContext = context;
        }

        public void Delete(T entity)
        {
            DataContext.Remove(entity);
        }

        public async Task Insert(T entity)
        {
            await DataContext.AddAsync(entity);
        }

        public void Update(T entity)
        {
            DataContext.Update(entity);
        }
        public async Task<T> Get(int id)
        {
            return await DataContext.Get<T>(id);
        }
    }
}
