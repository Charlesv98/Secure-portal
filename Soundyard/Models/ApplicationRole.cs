using Microsoft.AspNet.Identity.EntityFramework;

namespace Soundyard.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string Agreement { get; set; }
    }
}