using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace myproj.Projects.Dto
{
    public class CreateProjectDto
    {
        [Required]
        [StringLength(Project.MaxTitleLength)]
        public string Title { get; set; }

        [StringLength(Project.MaxDescriptionLength)]
        public string Description { get; set; }

        public long? AssignedUserId { get; set; }
    }
}