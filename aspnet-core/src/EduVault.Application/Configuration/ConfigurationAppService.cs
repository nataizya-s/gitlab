using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using EduVault.Configuration.Dto;

namespace EduVault.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : EduVaultAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
