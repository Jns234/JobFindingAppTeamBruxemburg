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
            CreateMap<TagModel, Tag>();
        }
    }
}
