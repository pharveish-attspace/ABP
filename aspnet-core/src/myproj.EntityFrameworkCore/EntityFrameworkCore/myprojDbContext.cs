using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using myproj.Authorization.Roles;
using myproj.Authorization.Users;
using myproj.MultiTenancy;
using myproj.Projects;

namespace myproj.EntityFrameworkCore
{
    public class myprojDbContext : AbpZeroDbContext<Tenant, Role, User, myprojDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Project> Projects {get; set;}
        
        public myprojDbContext(DbContextOptions<myprojDbContext> options)
            : base(options)
        {
        }
    }
}
