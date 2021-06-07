using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Get(int id);
        Task Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
