using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DotNetEnv; 

namespace DAL.Entities.Context
{
    public class ETMSContextFactory : IDesignTimeDbContextFactory<ETMSContext>
    {
        public ETMSContext CreateDbContext(string[] args)
        {
            // Load .env (adjust the path if needed)
            Env.Load("../ApplicationLayer/.env");

            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var dbUser = Environment.GetEnvironmentVariable("DB_USERNAME");
            var dbPass = Environment.GetEnvironmentVariable("DB_PASSWORD");

            var connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPass}";

            var optionsBuilder = new DbContextOptionsBuilder<ETMSContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new ETMSContext(optionsBuilder.Options);
        }
    }
}
