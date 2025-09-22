using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace myproj.Controllers
{
    public abstract class myprojControllerBase: AbpController
    {
        protected myprojControllerBase()
        {
            LocalizationSourceName = myprojConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
