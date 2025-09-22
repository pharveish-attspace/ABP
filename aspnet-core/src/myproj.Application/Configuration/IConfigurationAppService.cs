using System.Threading.Tasks;
using myproj.Configuration.Dto;

namespace myproj.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
