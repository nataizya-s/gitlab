using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using EduVault.Authorization.Roles;
using EduVault.Authorization.Users;
using EduVault.General;
using EduVault.MultiTenancy;

namespace EduVault.EntityFrameworkCore
{
    public class EduVaultDbContext : AbpZeroDbContext<Tenant, Role, User, EduVaultDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Attachment> Attachments { get; set; }

        public EduVaultDbContext(DbContextOptions<EduVaultDbContext> options)
            : base(options)
        {
        }
    }
}
