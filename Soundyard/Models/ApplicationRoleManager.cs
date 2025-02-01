using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Soundyard.Models;

namespace Soundyard
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> roleStore)
            : base(roleStore)
        {
        }
    }
}
