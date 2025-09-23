using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks;
using myproj.Projects;

namespace myproj.Projects.Dto
{
    public class GetProjectsInput
    {
        public long AssignedUserId { get; set; }
        public ProjectState State { get; set; }
    }
}