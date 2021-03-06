using JobFindingAppTeamBruxemburg.Data;
using JobFindingAppTeamBruxemburg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.Services
{
    public interface IEmployerService
    {
        Task<PagedResult<EmployerModel>> List(int page, int pageSize);
        Task<EmployerModel> GetEmployerForEdit(int id);
        Task<EmployerModel> GetEmployerDetails(int id);
        Task SaveEmployer(EmployerModel model);
        Task UpdateAndSave(Employer employer);
        Task RemoveAndSave(int id);
        Task DeleteEmployer(int id);
    }
}
