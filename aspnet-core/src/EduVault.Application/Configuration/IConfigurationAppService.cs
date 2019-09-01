using System.Threading.Tasks;
using EduVault.Configuration.Dto;

namespace EduVault.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
