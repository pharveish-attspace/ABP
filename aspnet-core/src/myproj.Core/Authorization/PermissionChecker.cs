using Abp.Authorization;
using myproj.Authorization.Roles;
using myproj.Authorization.Users;

namespace myproj.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
