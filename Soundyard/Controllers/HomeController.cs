using System.Web.Mvc;
using Soundyard.Models;
using Microsoft.AspNet.Identity;
using System.Linq;

namespace Soundyard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [Authorize]
        public ActionResult Dashboard()
        {
            var agreementValue = GetAgreementValue();
            ViewBag.Agreement = agreementValue;

            return View();
        }

        private string GetAgreementValue()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);

            if (user != null)
            {
                var roles = db.Roles.Where(r => user.Roles.Any(ur => ur.RoleId == r.Id)).ToList();
                foreach (var role in roles)
                {

                    var appRole = role as ApplicationRole;
                    if (appRole != null)
                    {
                        return appRole.Agreement; 
                    }
                }
            }

            return "No agreement found";
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}