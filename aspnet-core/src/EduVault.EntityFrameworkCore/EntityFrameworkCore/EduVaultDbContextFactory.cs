using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using EduVault.Configuration;
using EduVault.Web;

namespace EduVault.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class EduVaultDbContextFactory : IDesignTimeDbContextFactory<EduVaultDbContext>
    {
        public EduVaultDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<EduVaultDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            EduVaultDbContextConfigurer.Configure(builder, configuration.GetConnectionString(EduVaultConsts.ConnectionStringName));

            return new EduVaultDbContext(builder.Options);
        }
    }
}
