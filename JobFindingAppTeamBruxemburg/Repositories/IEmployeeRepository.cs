using JobFindingAppTeamBruxemburg.Data;
using JobFindingAppTeamBruxemburg.Repositories;
using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.Data
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<PagedResult<Employee>> List(int page, int pageSize);
    }
}
