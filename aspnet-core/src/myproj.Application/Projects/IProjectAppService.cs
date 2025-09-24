using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using myproj.Projects.Dto;
using Abp.Application.Services.Dto;

namespace myproj.Projects
{
    public interface IProjectAppService : IAsyncCrudAppService< ProjectDto, long, PagedProjectResultRequestDto, CreateProjectDto, ProjectDto>
    {
    }
}