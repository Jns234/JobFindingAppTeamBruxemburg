using JobFindingAppTeamBruxemburg.Data;
using JobFindingAppTeamBruxemburg.Repositories;
using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.Data
{
    public class ITagRepository : IRepository<Tag>
    {
        public void Delete(Tag entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Tag> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Insert(Tag entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<PagedResult<Tag>> List<Tag>(int page, int pageSize);

        public void Update(Tag entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
