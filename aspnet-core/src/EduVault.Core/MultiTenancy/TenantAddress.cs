using Abp.Domain.Entities.Auditing;
using EduVault.Common;

namespace EduVault.MultiTenancy
{

    public class TenantAddress: FullAuditedEntity
    {
        public Address Address { get; set; }
        public int AddressId { get; set; }

        public Tenant Tenant { get; set; }
        public int TenantId { get; set; }
    }
}