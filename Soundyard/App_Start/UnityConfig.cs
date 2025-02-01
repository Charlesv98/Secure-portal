  using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Soundyard.Models;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
using Unity.Mvc5;
using Unity.Injection;

namespace Soundyard
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();


            container.RegisterType<ApplicationDbContext>(
                new HierarchicalLifetimeManager(),
                new InjectionConstructor("DefaultConnection")
            );


            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());

            container.RegisterType<ApplicationUserManager>(new HierarchicalLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
