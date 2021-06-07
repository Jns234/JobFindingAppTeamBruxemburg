using JobFindingAppTeamBruxemburg.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.Repositories
{
    public class EmployerRepository : BaseRepository<Employer>
    {
        public EmployerRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Task<IList<Employer>> List()
        {
            return null;
        }
        public async Task<PagedResult<Employer>> List(int page, int pageSize)
        {
            var query = DataContext.Employers.AsQueryable();

            var result = await query.Include(employer => employer.Name)
                                    .OrderBy(employer => employer.Id)
                                    .GetPagedAsync(page, pageSize);

            return result;
        }
    }
}
