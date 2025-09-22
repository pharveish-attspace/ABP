using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using myproj.Configuration.Dto;

namespace myproj.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : myprojAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
