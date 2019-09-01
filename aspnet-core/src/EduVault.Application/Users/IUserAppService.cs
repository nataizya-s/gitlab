using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EduVault.Roles.Dto;
using EduVault.Users.Dto;

namespace EduVault.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
