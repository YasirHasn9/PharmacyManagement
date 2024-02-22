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