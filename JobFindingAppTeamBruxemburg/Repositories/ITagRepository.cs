using JobFindingAppTeamBruxemburg.Data;
using JobFindingAppTeamBruxemburg.Repositories;
using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.Data
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<PagedResult<Tag>> List(int page, int pageSize);
    }
}
