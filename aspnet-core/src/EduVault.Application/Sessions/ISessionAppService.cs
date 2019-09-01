using System.Threading.Tasks;
using Abp.Application.Services;
using EduVault.Sessions.Dto;

namespace EduVault.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
