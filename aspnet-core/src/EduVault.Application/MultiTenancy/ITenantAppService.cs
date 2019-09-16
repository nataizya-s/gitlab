using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EduVault.MultiTenancy.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduVault.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
        Task<long?> UploadFile([FromForm] IFormFile file);
    }
}

