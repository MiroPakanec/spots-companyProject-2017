using Microsoft.AspNet.Identity.EntityFramework;
using spots.Models.Identity;

namespace spots.DAL.SQLS
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base(Databases.DefaultConnection, throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}