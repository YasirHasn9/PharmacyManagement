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

            var pharmacies = new Pharmacy[]
            {
                new Pharmacy
                {
                    Name = "Pharmacy 1",
                    Address = "123 Test St",
                    City = "Test City",
                    State = "TS",
                    Zip = "12345",
                    NumberOfFilledPrescriptions = 0,
                    CreatedDate = utcDateTime
                },
                new Pharmacy
                {
                    Name = "Pharmacy 2",
                    Address = "456 Test St",
                    City = "Test City",
                    State = "TS",
                    Zip = "12345",
                    NumberOfFilledPrescriptions = 1,
                    CreatedDate = utcDateTime
                },
                new Pharmacy
                {
                    Name = "Pharmacy 3",
                    Address = "789 Test St",
                    City = "Test City",
                    State = "TS",
                    Zip = "12345",
                    NumberOfFilledPrescriptions = 2,
                    CreatedDate = utcDateTime
                },
                new Pharmacy
                {
                    Name = "Pharmacy 4",
                    Address = "101 Test St",
                    City = "Test City",
                    State = "TS",
                    Zip = "12345",
                    NumberOfFilledPrescriptions = 0,
                    CreatedDate = utcDateTime
                },
                new Pharmacy
                {
                    Name = "Pharmacy 5",
                    Address = "112 Test St",
                    City = "Test City",
                    State = "TS",
                    Zip = "12345",
                    NumberOfFilledPrescriptions = 2,
                    CreatedDate = utcDateTime
                }
            };
            context.Pharmacies.AddRange(pharmacies);
            context.SaveChanges();

            var pharmacists = new Pharmacist[]
            {
                new ()
                {
                    PharmacyId = pharmacies[0].Id,
                    Name = "Pharmacist 1",
                    Age = 30,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddYears(1)
                },
                new ()
                {
                    PharmacyId = pharmacies[1].Id,
                    Name = "Pharmacist 2",
                    Age = 35,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddYears(1)
                },
                new ()
                {
                    PharmacyId = pharmacies[2].Id,
                    Name = "Pharmacist 3",
                    Age = 40,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddYears(1)
                },
                new ()
                {
                    PharmacyId = pharmacies[3].Id,
                    Name = "Pharmacist 4",
                    Age = 45,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddYears(1)
                },
                new ()
                {
                    PharmacyId = pharmacies[4].Id,
                    Name = "Pharmacist 5",
                    Age = 50,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddYears(1)
                }
            };

            context.Pharmacists.AddRange(pharmacists);
            
            context.SaveChanges();
        }
    }
}