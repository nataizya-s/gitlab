using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EduVault.Authorization;

namespace EduVault
{
    [DependsOn(
        typeof(EduVaultCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class EduVaultApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<EduVaultAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(EduVaultApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
