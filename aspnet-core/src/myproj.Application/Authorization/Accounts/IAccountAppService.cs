using System.Threading.Tasks;
using Abp.Application.Services;
using myproj.Authorization.Accounts.Dto;

namespace myproj.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
