using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Pharmacy.Business;
public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        DateTime localDateTime = DateTime.Now;
        DateTime utcDateTime = localDateTime.ToUniversalTime();
        using (var context = new PharmacyContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<PharmacyContext>>()))
        {
            if (context.Pharmacies.Any())
            {
                return;   
            }

            context.Pharmacies.AddRange(
                new Pharmacy
                {
                    Name = "Pharmacy 1",
                    Address = "123 Test St",
                    City = "Test City",
                    State = "TS",
                    Zip = "12345",
                    NumberOfFilledPrescriptions = 0,
                    CreatedDate = DateTime.UtcNow
                },

                new Pharmacy
                {
                    Name = "Pharmacy 2",
                    Address = "456 Test St",
                    City = "Test City",
                    State = "TS",
                    Zip = "12345",
                    NumberOfFilledPrescriptions = 1,
                    CreatedDate = DateTime.UtcNow
                },

                new Pharmacy
                {
                    Name = "Pharmacy 3",
                    Address = "789 Test St",
                    City = "Test City",
                    State = "TS",
                    Zip = "12345",
                    NumberOfFilledPrescriptions = 2,
                    CreatedDate = DateTime.UtcNow
                },

                new Pharmacy
                {
                    Name = "Pharmacy 4",
                    Address = "101 Test St",
                    City = "Test City",
                    State = "TS",
                    Zip = "12345",
                    NumberOfFilledPrescriptions = 0,
                    CreatedDate = DateTime.UtcNow
                },

                new Pharmacy
                {
                    Name = "Pharmacy 5",
                    Address = "112 Test St",
                    City = "Test City",
                    State = "TS",
                    Zip = "12345",
                    NumberOfFilledPrescriptions = 2,
                    CreatedDate = DateTime.UtcNow
                }
            );
            context.SaveChanges();
        }
    }
}

// protected override void OnModelCreating(ModelBuilder modelBuilder)
// {
//     modelBuilder.Entity<Pharmacy>().HasData(
//         new Pharmacy { Id = 1, Name = "Pharmacy A", Address = "123 Main St", City = "Anytown", State = "TX", Zip = "12345", NumberOfFilledPrescriptions = 100, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
//         new Pharmacy { Id = 2, Name = "Pharmacy B", Address = "456 Elm St", City = "Anytown", State = "TX", Zip = "67890", NumberOfFilledPrescriptions = 200, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
//         new Pharmacy { Id = 3, Name = "Pharmacy C", Address = "789 Maple St", City = "Anytown", State = "TX", Zip = "54321", NumberOfFilledPrescriptions = 300, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
//         new Pharmacy { Id = 4, Name = "Pharmacy D", Address = "101 Oak St", City = "Anytown", State = "TX", Zip = "98765", NumberOfFilledPrescriptions = 400, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
//         new Pharmacy { Id = 5, Name = "Pharmacy E", Address = "202 Pine St", City = "Anytown", State = "TX", Zip = "24680", NumberOfFilledPrescriptions = 500, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now }
//     );
// }