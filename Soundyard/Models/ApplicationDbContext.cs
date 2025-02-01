using Microsoft.AspNet.Identity.EntityFramework;

namespace Soundyard.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext() : base("sy_club") { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
