using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace EduVault.EntityFrameworkCore
{
    public static class EduVaultDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<EduVaultDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<EduVaultDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
