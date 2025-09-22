using Abp.Application.Services;
using myproj.MultiTenancy.Dto;

namespace myproj.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

