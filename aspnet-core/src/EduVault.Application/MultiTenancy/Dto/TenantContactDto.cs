using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EduVault.Common.Dto;

namespace EduVault.MultiTenancy.Dto
{
    [AutoMap(typeof(TenantContact))]
    public class TenantContactDto : EntityDto  
    {
        public ContactDto Contact { get; set; }
        public int ContactId { get; set; }

        public int TenantId { get; set; }
    }
}