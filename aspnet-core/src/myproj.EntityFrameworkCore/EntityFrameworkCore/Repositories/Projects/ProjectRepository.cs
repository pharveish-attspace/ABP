using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myproj.Projects;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using myproj.Core.Repositories.Projects;


namespace myproj.EntityFrameworkCore.Repositories.Projects
{
    public class ProjectRepository : myprojRepositoryBase<Project, long>, IProjectRepository
    {
        public ProjectRepository(IDbContextProvider<myprojDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public List<Project> GetAllWithPeople(long? assignedUserId, ProjectState? state)
        {
            //In repository methods, we do not deal with create/dispose DB connections, DbContexes and transactions. ABP handles it.
            
            try
            {
            var query = GetAll(); //GetAll() returns IQueryable<T>, so we can query over it.
            //var query = Context.Tasks.AsQueryable(); //Alternatively, we can directly use EF's DbContext object.
            //var query = Table.AsQueryable(); //Another alternative: We can directly use 'Table' property instead of 'Context.Tasks', they are identical.
            
            //Add some Where conditions...

            if (assignedUserId.HasValue)
            {
                query = query.Where(project => project.AssignedUser.Id == assignedUserId.Value);
            }

            if (state.HasValue)
            {
                query = query.Where(project => project.State == state);
            }

            return query
                .OrderByDescending(project => project.CreationTime)
                .Include(project => project.AssignedUser) //Include assigned person in a single query
                .ToList();
                
            }
            catch (System.Exception ex)
            {
                    Console.WriteLine(ex);

                throw new UserFriendlyException("GetProjects failed", ex.Message);
            }
        }
        
    }
}