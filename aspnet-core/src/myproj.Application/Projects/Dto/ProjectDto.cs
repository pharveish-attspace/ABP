using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;


namespace myproj.Projects.Dto
{
    public class ProjectDto : EntityDto<long>, IHasCreationTime
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public ProjectState State { get; set; }
        public long? AssignedUserId { get; set; }

    }
}