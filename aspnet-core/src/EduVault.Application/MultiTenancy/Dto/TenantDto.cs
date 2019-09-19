using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.MultiTenancy;
using EduVault.Common.Dto;

namespace EduVault.MultiTenancy.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantDto : EntityDto
    {
        [Required]
        [StringLength(AbpTenantBase.MaxTenancyNameLength)]
        [RegularExpression(AbpTenantBase.TenancyNameRegex)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(AbpTenantBase.MaxNameLength)]
        public string Name { get; set; }        
        
        public bool IsActive {get; set;}

        public long? SchoolLogoAttachmentId { get; set; }

        [Required]
        public List<AddressDto> Addresses { get; set; }

        [Required]
        public List<ContactDto> Contacts { get; set; }

        [MaxLength(100)]
        public string WebsiteAddress { get; set; }

        [Required]
        [MaxLength(100)]
        public string Principal { get; set; }

        [MaxLength(100)]
        public string DeputyPrincipal { get; set; }

        [MaxLength(100)]
        public string District { get; set; }
    }
}
