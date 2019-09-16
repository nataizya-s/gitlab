using Abp.MultiTenancy;
using EduVault.Authorization.Users;

namespace EduVault.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public long? ProfilePhotoAttachmentId { get; set; }

        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
