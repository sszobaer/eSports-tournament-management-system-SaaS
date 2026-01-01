using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DAL.Entities.Context
{
    public class UMSContextFactory : IDesignTimeDbContextFactory<UMSContext>
    {
        public UMSContext CreateDbContext(string[] args)
        {
            // Build configuration to read appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // DAL project folder
                .AddJsonFile("appsettings.json")
                .Build();

            // Get connection string
            var connString = configuration.GetConnectionString("DbConn");

            var optionsBuilder = new DbContextOptionsBuilder<UMSContext>();
            optionsBuilder.UseNpgsql(connString);

            return new UMSContext(optionsBuilder.Options);
        }
    }
}
