using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EduVault.MultiTenancy.Dto;

namespace EduVault.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

