using JobFindingAppTeamBruxemburg.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.Repositories
{

        public interface IEmployerRepository : IRepository<Employer>
    {
        Task<PagedResult<Employer>> List(int page, int pageSize);
    }
}
