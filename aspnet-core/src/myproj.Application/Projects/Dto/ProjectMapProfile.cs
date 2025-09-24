using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace myproj.Projects.Dto
{
    public class ProjectMapProfile : Profile
    {
        public ProjectMapProfile ()
        {

            CreateMap<CreateProjectDto, Project>();

            CreateMap<ProjectDto, Project>().ReverseMap();

        }
    }
}