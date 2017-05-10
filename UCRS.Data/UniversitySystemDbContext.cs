using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

using UCRS.Data.Contracts;
using UCRS.Data.Models;

namespace UCRS.Data
{
    public class UniversitySystemDbContext : DbContext , IUniversitySystemDbContext
    {
        public UniversitySystemDbContext()
            : base("UniversitySystemDBConnectionString")
        {
        }
        
        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }
    }
}
