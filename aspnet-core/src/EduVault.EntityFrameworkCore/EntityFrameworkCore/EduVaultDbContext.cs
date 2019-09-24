using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using EduVault.Authorization.Roles;
using EduVault.Authorization.Users;
using EduVault.Common;
using EduVault.MultiTenancy;
using EduVault.LearnerProfile;

namespace EduVault.EntityFrameworkCore
{
    public class EduVaultDbContext : AbpZeroDbContext<Tenant, Role, User, EduVaultDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<TenantContact> TenantContacts { get; set; }
        public DbSet<TenantAddress> TenantAddresses { get; set; }
        public DbSet<LearnerProfile.LearnerProfile> LearnerProfiles { get; set; }
        public DbSet<LearnerProfileAttachment> LearnerProfileAttachments { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<ChronicIllness> ChronicIllnesses { get; set; }
        public DbSet<SchoolAttended> SchoolsAttended { get; set; }
        public DbSet<Absent> Absence { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public EduVaultDbContext(DbContextOptions<EduVaultDbContext> options)
            : base(options)
        {
        }
    }
}
