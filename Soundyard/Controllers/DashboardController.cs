using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Soundyard.Models;

public class DashboardController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;

    public DashboardController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<ActionResult> Index()
    {
        var user = await _userManager.FindByIdAsync(User.Identity.GetUserId());
        if (user != null)
        {
            var roles = await _userManager.GetRolesAsync(user.Id);
            var agreement = string.Empty;


            foreach (var role in roles)
            {
                var applicationRole = await _roleManager.FindByNameAsync(role);
                if (applicationRole != null)
                {
                    agreement = applicationRole.Agreement;
                    break; 
                }
            }

            ViewBag.Agreement = agreement;
        }
        return View();
    }
}
