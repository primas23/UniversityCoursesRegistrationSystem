using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

using UCRS.Data.Models;

namespace UCRS.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class UniversitySystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public UniversitySystemDbContext()
            : base("UniversitySystemDBConnectionString", throwIfV1Schema: false)
        {
        }

        public static UniversitySystemDbContext Create()
        {
            return new UniversitySystemDbContext();
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }
    }
}
