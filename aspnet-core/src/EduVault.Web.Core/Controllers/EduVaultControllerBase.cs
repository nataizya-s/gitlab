using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace EduVault.Controllers
{
    public abstract class EduVaultControllerBase: AbpController
    {
        protected EduVaultControllerBase()
        {
            LocalizationSourceName = EduVaultConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
