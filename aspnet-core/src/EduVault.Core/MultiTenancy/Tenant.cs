using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.MultiTenancy;
using EduVault.Authorization.Users;
using EduVault.Common;

namespace EduVault.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public long? SchoolLogoAttachmentId { get; set; }

        [Required]
        public List<TenantAddress> Addresses { get; set; }

        [Required]
        public List<TenantContact> Contacts { get; set; }

        [MaxLength(100)]
        public string WebsiteAddress { get; set; }

        [Required]
        [MaxLength(100)]
        public string Principal { get; set; }

        [MaxLength(100)]
        public string DeputyPrincipal { get; set; }

        [MaxLength(100)]
        public string District { get; set; }

        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
