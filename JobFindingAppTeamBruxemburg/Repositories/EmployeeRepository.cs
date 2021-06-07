using JobFindingAppTeamBruxemburg.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Task<IList<Employee>> List()
        {
            return null;
        }
        public async Task<PagedResult<Employee>> List(int page, int pageSize)
        {
            var query = DataContext.Employees.AsQueryable();

            var result = await query.Include(employee => employee.Name)
                                    .OrderBy(employee => employee.Id)
                                    .GetPagedAsync(page, pageSize);

            return result;
        }
    }
}
