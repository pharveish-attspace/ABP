using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using myproj.Projects.Dto;
using myproj.Core.Repositories.Projects;
using Abp.AutoMapper;
using Abp.Application.Services.Dto;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using myproj.Authorization;
using myproj.Authorization.Roles;
using myproj.Authorization.Users;

namespace myproj.Projects
{
    [AbpAuthorize(PermissionNames.Pages_Roles)]
    public class ProjectAppService : ApplicationService, IProjectAppService
    {
       private readonly IProjectRepository _projectRepository;

       public ProjectAppService(IProjectRepository projectRepository)
       {
            _projectRepository = projectRepository;
       }

        public GetProjectsOutput GetProjects(GetProjectsInput input)
        {
            //Called specific GetAllWithPeople method of task repository.
            var tasks = _projectRepository.GetAllWithPeople(input.AssignedUserId, input.State);

            //Used AutoMapper to automatically convert List<Task> to List<TaskDto>.
            return new GetProjectsOutput
            {
                Projects = ObjectMapper.Map<List<ProjectDto>>(tasks)
            };
        }
        
        public async Task<ProjectDto> CreateAsync(CreateProjectInput input)
        {
            var project = new Project(input.Title, input.Description)
            {
                AssignedUserId = input.AssignedUserId
            };

            project = await _projectRepository.InsertAsync(project);
            return project.MapTo<ProjectDto>();

        }

        public async Task<ProjectDto> UpdateAsync(UpdateProjectInput input)
        {
            var project = await _projectRepository.GetAsync(input.Id);

            project.Title = input.Title;
            project.Description = input.Description;
            project.AssignedUserId = input.AssignedUserId;
            project.State = input.State;

            project = await _projectRepository.UpdateAsync(project);
            return project.MapTo<ProjectDto>();

        }

        public async Task DeleteAsync(EntityDto<long> input)
        {
            await _projectRepository.DeleteAsync(input.Id);
        }


    }
}