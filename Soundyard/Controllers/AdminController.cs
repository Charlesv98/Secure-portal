using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Soundyard.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Web;

namespace Soundyard.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public AdminController()
        {
        }

        public AdminController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public ApplicationUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            private set => _userManager = value;
        }

        public ApplicationRoleManager RoleManager
        {
            get => _roleManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            private set => _roleManager = value;
        }

        public async Task<ActionResult> Dashboard()
        {
            var user = await UserManager.FindByNameAsync(User.Identity.Name);

            var roles = await UserManager.GetRolesAsync(user.Id);

            if (roles.Count > 0)
            {
                var role = await RoleManager.FindByNameAsync(roles[0]);
                ViewBag.Agreement = role?.Agreement;
            }

            return View();
        }

        public ActionResult Report()
        {
            return View();
        }

        public ActionResult Administrace()
        {
            return View();
        }
    }
}
