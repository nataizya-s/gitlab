using Abp.Domain.Entities.Auditing;
using EduVault.Common;

namespace EduVault.MultiTenancy
{
    public class TenantContact : FullAuditedEntity
    {
        public Contact Contact { get; set; }
        public int ContactId { get; set; }

        public Tenant Tenant { get; set; }
        public int TenantId { get; set; }
    }
}