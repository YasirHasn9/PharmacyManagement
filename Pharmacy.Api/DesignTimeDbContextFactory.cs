
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pharmacy.Business;


namespace Pharmacy.Api;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PharmacyContext>
{
    public PharmacyContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<PharmacyContext>();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        builder.UseNpgsql(connectionString, b => b.MigrationsAssembly("Pharmacy.Api"));

        builder.UseNpgsql(connectionString);

        return new PharmacyContext(builder.Options);
    }
}