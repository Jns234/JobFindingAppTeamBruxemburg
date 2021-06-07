using JobFindingAppTeamBruxemburg.Data;
using JobFindingAppTeamBruxemburg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.Services
{
    public interface IEmployeeService
    {
        Task<PagedResult<EmployeeModel>> List(int page, int pageSize);
        Task<EmployeeModel> GetEmployeeForEdit(int id);
        Task<EmployeeModel> GetEmployeeDetails(int id);
        Task SaveEmployee(EmployeeModel model);
        Task UpdateAndSave(Employee employee);
        Task RemoveAndSave(int id);
        Task DeleteEmployee(int id);
    }
}
