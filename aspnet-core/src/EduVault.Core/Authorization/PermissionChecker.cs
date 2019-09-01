using Abp.Authorization;
using EduVault.Authorization.Roles;
using EduVault.Authorization.Users;

namespace EduVault.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
