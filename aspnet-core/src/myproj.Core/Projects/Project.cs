using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace myproj.Projects
{
    [Table("Projects")]
    public class Project : Entity, IHasCreationTime
    {
        public const int MaxTitleLength = 256;
        public const int MaxDescriptionLength = 64 * 1024; //64KB

        [Required]
        [StringLength(MaxTitleLength)]
        public string Title { get; set; }

        [StringLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public ProjectState State { get; set; }

        public Project()
        {
            CreationTime = Clock.Now;
            State = ProjectState.Open;
        }

        public Project(string title, string description = null)
            : this()
        {
            Title = title;
            Description = description;
        }
    }

    public enum ProjectState : byte
    {
        Open = 0,
        Completed = 1
    }
}