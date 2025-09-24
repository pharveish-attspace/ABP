using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myproj.Projects;
using System.ComponentModel;

namespace myproj.Projects.Dto
{
    public class GetProjectsInput
    {
        [DefaultValue(null)]
        public long? AssignedUserId { get; set; }
        public ProjectState? State { get; set; }
    }
}