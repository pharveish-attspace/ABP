using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using myproj.Authorization;

namespace myproj
{
    [DependsOn(
        typeof(myprojCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class myprojApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<myprojAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(myprojApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
