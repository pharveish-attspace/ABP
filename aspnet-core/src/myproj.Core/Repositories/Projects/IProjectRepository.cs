using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using myproj.Projects;

namespace myproj.Core.Repositories.Projects
{
    public interface IProjectRepository : IRepository<Project, long>
    {
        List<Project> GetAllWithPeople(long? assignedUserId, ProjectState? state);
    }
}