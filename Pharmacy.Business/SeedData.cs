using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Pharmacy.Business;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new PharmacyContext(
                   serviceProvider.GetRequiredService<DbContextOptions<PharmacyContext>>()))
        {
            var utcDateTime = DateTime.UtcNow;
            if (context.Pharmacies.Any())
            {
                return;
            }

            context.Pharmacies.AddRange(
                new()
                {
                    Name = "Pharmacy 1",
                    Address = "123 Test St",
                    City = "Dallas",
                    State = "Tx",
                    Zip = "12345",
                    NumberOfFilledPrescriptions = 0,
                    CreatedDate = utcDateTime
                },
                new()
                {
                    Name = "Pharmacy 2",
                    Address = "456 Test St",
                    City = "Plano",
                    State = "Tx",
                    Zip = "12345",
                    NumberOfFilledPrescriptions = 1,
                    CreatedDate = utcDateTime
                },
                new()
                {
                    Name = "Pharmacy 3",
                    Address = "101 Test St",
                    City = "Frisco",
                    State = "Tx",
                    Zip = "12345",
                    NumberOfFilledPrescriptions = 0,
                    CreatedDate = utcDateTime
                },
                new()
                {
                    Name = "Pharmacy 4",
                    Address = "112 Test St",
                    City = "Frisco",
                    State = "Tx",
                    Zip = "12345",
                    NumberOfFilledPrescriptions = 2,
                    CreatedDate = utcDateTime
                },
                new()
                {
                    Name = "Pharmacy 5",
                    Address = "112 Test St",
                    City = "Irving",
                    State = "Tx",
                    Zip = "12345",
                    NumberOfFilledPrescriptions = 2,
                    CreatedDate = utcDateTime
                }
            );
            context.SaveChanges();
        }
    }
}