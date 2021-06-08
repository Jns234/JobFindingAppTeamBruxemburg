using AutoMapper;
using JobFindingAppTeamBruxemburg.Data;
using JobFindingAppTeamBruxemburg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.MappingProfile
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {

            CreateMap<Tag, TagModel>();
            CreateMap<Tag, TagListModel>();
            CreateMap<TagModel, Tag>();
            CreateMap<TagListModel, Tag>();

            CreateMap<Employee, EmployeeModel>();
            CreateMap<EmployeeModel, Employee>();
            CreateMap<Employee, EmployeeListModel>();
            CreateMap<EmployeeListModel, Employee>();

            CreateMap<Employer, EmployerModel>();
            CreateMap<EmployerModel, Employer>();
            CreateMap<Employer, EmployerListModel>();
            CreateMap<EmployerListModel, Employer>();

            CreateMap<PagedResult<Tag>, PagedResult<TagListModel>>();
            CreateMap<PagedResult<Tag>, PagedResult<TagModel>>();

            CreateMap<PagedResult<Employee>, PagedResult<EmployeeListModel>>();
            CreateMap<PagedResult<Employee>, PagedResult<EmployeeModel>>();

            CreateMap<PagedResult<Employer>, PagedResult<EmployerListModel>>();
            CreateMap<PagedResult<Employer>, PagedResult<EmployerModel>>();
        }
    }
}
