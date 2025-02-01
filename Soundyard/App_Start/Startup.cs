using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Soundyard.Models;
using Microsoft.AspNet.Identity.Owin;

[assembly: OwinStartup(typeof(Soundyard.App_Start.Startup))]

namespace Soundyard.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });

            app.CreatePerOwinContext<ApplicationDbContext>(ApplicationDbContext.Create);

            app.CreatePerOwinContext<ApplicationUserManager>((options, context) =>
                new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()))
            );

            app.CreatePerOwinContext<ApplicationRoleManager>((options, context) =>
                new ApplicationRoleManager(new RoleStore<ApplicationRole>(context.Get<ApplicationDbContext>()))
            );
        }
    }
}
