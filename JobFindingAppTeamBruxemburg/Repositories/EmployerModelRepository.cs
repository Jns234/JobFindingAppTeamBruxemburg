using JobFindingAppTeamBruxemburg.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.Repositories
{
    public class EmployerModelRepository
    {
        public EmployerModelRepository(ApplicationDbContext context) : base(context)
        {

        }

        public object DataContext { get; private set; }

        public Task<IList<EmployerModel>> List()
        {
            return null;
        }
        public async Task<PagedResult<EmployerModel>> List(int page, int pageSize)
        {
            var query = DataContext.WorkLogs.AsQueryable();

            var result = await query.Include(worklog => worklog.Task)
                                    .OrderBy(worklog => worklog.Id)
                                    .GetPagedAsync(page, pageSize);

            return result;
        }
    }
}
