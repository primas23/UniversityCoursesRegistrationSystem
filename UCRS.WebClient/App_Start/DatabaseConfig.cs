using System.Data.Entity;

using UCRS.Data;

namespace UCRS.WebClient
{
    public static class DatabaseConfig
    {
        public static void Config()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UniversitySystemDbContext, Data.Migrations.Configuration>());
        }
    }
}