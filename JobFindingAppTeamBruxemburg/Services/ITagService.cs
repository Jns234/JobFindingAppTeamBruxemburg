using JobFindingAppTeamBruxemburg.Data;
using JobFindingAppTeamBruxemburg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.Services
{
    public interface ITagService
    {
        Task<PagedResult<TagModel>> List(int page, int pageSize);
        Task<TagModel> GetTagForEdit(int id);
        Task<TagModel> GetTagDetails(int id);
        Task SaveTag(TagModel model);
        Task UpdateAndSave(Tag tag);
        Task RemoveAndSave(int id);
        Task DeleteTag(int id);
    }
}
