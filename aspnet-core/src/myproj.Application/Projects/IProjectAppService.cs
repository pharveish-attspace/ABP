using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using myproj.Projects.Dto;
using Abp.Application.Services.Dto;

namespace myproj.Projects
{
    public interface IProjectAppService : IApplicationService
    {
        GetProjectsOutput GetProjects(GetProjectsInput input);
        Task<ProjectDto> CreateAsync(CreateProjectInput input);
        Task<ProjectDto> UpdateAsync(UpdateProjectInput input);
        Task DeleteAsync(EntityDto<long> input);


    }
}