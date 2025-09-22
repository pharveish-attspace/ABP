using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using myproj.EntityFrameworkCore;
using myproj.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace myproj.Web.Tests
{
    [DependsOn(
        typeof(myprojWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class myprojWebTestModule : AbpModule
    {
        public myprojWebTestModule(myprojEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(myprojWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(myprojWebMvcModule).Assembly);
        }
    }
}