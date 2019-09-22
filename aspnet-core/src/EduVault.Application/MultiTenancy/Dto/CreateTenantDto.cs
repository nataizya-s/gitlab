using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.MultiTenancy;
using EduVault.Common.Dto;

namespace EduVault.MultiTenancy.Dto
{
    [AutoMapTo(typeof(Tenant))]
    public class CreateTenantDto
    {
        [Required]
        [StringLength(AbpTenantBase.MaxTenancyNameLength)]
        [RegularExpression(AbpTenantBase.TenancyNameRegex)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(AbpTenantBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string AdminEmailAddress { get; set; }

        [StringLength(AbpTenantBase.MaxConnectionStringLength)]
        public string ConnectionString { get; set; }

        public bool IsActive {get; set;}

        public long? SchoolLogoAttachmentId { get; set; }

        [Required]
        public List<TenantAddressDto> Addresses { get; set; }

        [Required]
        public List<TenantContactDto> Contacts { get; set; }

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
