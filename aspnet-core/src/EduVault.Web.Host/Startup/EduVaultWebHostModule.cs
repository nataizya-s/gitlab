using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EduVault.Configuration;

namespace EduVault.Web.Host.Startup
{
    [DependsOn(
       typeof(EduVaultWebCoreModule))]
    public class EduVaultWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public EduVaultWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EduVaultWebHostModule).GetAssembly());
        }
    }
}
