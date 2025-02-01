using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Soundyard.Models;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.Net.Mail;
using System;

namespace Soundyard.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set { _userManager = value; }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                var result = await UserManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    SendActivationEmail(user.Email);

                    return RedirectToAction("CheckYourEmail", "Account");
                }

                AddErrors(result);
            }

            return View(model);
        }

        public ActionResult CheckYourEmail()
        {
            return View();
        }

        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }

            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }

            var result = await UserManager.ConfirmEmailAsync(user.Id, code);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }

            return View("Error");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private void SendActivationEmail(string email)
        {
            var mailMessage = new MailMessage("noreply@soundyard.club", email)
            {
                Subject = "Aktivace účtu",
                Body = "Klikněte na tento odkaz pro aktivaci vašeho účtu: [odkaz]"
            };

            var smtpClient = new SmtpClient("212.71.162.103")
            {
                Port = 25,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Timeout = 20000
            };

            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při odesílání e-mailu: " + ex.Message);
            }
        }
    }
}
