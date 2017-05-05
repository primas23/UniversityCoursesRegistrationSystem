using System.Data.Entity.Migrations;

using UCRS.Data.Models;

namespace UCRS.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<UniversitySystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(UniversitySystemDbContext context)
        {
            Course math = new Course()
            {
                Name = "Math"
            };

            Course physics = new Course()
            {
                Name = "Physics"
            };

            context.Courses.AddOrUpdate(
                c => c.Name,
                math,
                physics
            );

            Student peter = new Student()
            {
                Name = "Peter"
            };
            peter.Courses.Add(math);

            Student ivan = new Student()
            {
                Name = "Ivan"
            };
            ivan.Courses.Add(math);
            ivan.Courses.Add(physics);

            context.Students.AddOrUpdate(
                s => s.Name,
                peter,
                ivan
            );

            context.SaveChanges();
        }
    }
}