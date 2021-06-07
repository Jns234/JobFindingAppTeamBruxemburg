using JobFindingAppTeamBruxemburg.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JobFindingAppTeamBruxemburg.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(ApplicationDbContext context) : base(context)
        {
        }
        public Task<IList<Tag>> List()
        {
            return null; 
        }
        public async Task<PagedResult<Tag>> List(int page, int pageSize)
        {
            var query = DataContext.Tags.AsQueryable();

            var result = await query.OrderBy(tag => tag.Title)
                                    .GetPagedAsync(page, pageSize);

            return result;

        }
    }
}
