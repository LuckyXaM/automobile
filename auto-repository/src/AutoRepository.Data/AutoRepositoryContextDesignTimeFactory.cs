using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace AutoRepository.Data
{
    /// <summary>
    /// Необходима для формирования файлов миграций (не используется в рантайме)
    /// </summary>
    public class AutoRepositoryContextDesignTimeFactory : IDesignTimeDbContextFactory<AutoRepositoryContext>
    {
        public AutoRepositoryContext CreateDbContext(string[] args)
        {
            var environmentName =
            Environment.GetEnvironmentVariable(
            "Hosting:Environment");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<AutoRepositoryContext>();
            builder.UseNpgsql(connectionString, b => b.MigrationsAssembly("RoApi"));
            return new AutoRepositoryContext(builder.Options);
        }
    }
}
