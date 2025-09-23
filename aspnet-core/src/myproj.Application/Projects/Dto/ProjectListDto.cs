using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myproj.Projects;
using myproj.Authorization.Users;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using Abp.AutoMapper;

namespace myproj.Projects.Dto
{
    [AutoMapFrom(typeof(Project))]
    public class ProjectListDto : EntityDto, IHasCreationTime
    {
        public User AssignedUser { get; set; }
        public string Title { get; set; }    
        public string Description { get; set; }    
        public DateTime CreationTime { get; set; }    
        public ProjectState State { get; set; }    
    }
}