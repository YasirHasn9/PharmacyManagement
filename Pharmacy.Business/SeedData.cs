using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Business.Drugs;
using Pharmacy.Business.Pharmacists;
using Pharmacy.Business.Warehouses;

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
                new()
                {
                    PharmacyId = pharmacies[0].Id,
                    Name = "Pharmacist 1",
                    Age = 30,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddYears(1)
                },
                new()
                {
                    PharmacyId = pharmacies[1].Id,
                    Name = "Pharmacist 2",
                    Age = 35,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddYears(1)
                },
                new()
                {
                    PharmacyId = pharmacies[2].Id,
                    Name = "Pharmacist 3",
                    Age = 40,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddYears(1)
                },
                new()
                {
                    PharmacyId = pharmacies[3].Id,
                    Name = "Pharmacist 4",
                    Age = 45,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddYears(1)
                },
                new()
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

            if (!context.Warehouses.Any())
            {
                var warehouses = new Warehouse[]
                {
                    new ()
                    {
                        Name = "Warehouse 1",
                        Address = "123 Test St"
                    },
                    new ()
                    {
                        Name = "Warehouse 2",
                        Address = "456 Test St"
                    },
                    new ()
                    {
                        Name = "Warehouse 3",
                        Address = "789 Test St"
                    },
                };

                context.Warehouses.AddRange(warehouses);
                context.SaveChanges();
            }
            
            if (!context.Drugs.Any())
            {
                var drugs = new Drug[]
                {
                    new ()
                    {
                        Name = "Drug 1",
                        Description = "Description 1"
                    },
                    new ()
                    {
                        Name = "Drug 2",
                        Description = "Description 2"
                    },
                    new ()
                    {
                        Name = "Drug 3",
                        Description = "Description 3"
                    },
                    new ()
                    {
                        Name = "Drug 4",
                        Description = "Description 4"
                    },
                    new ()
                    {
                        Name = "Drug 5",
                        Description = "Description 5"
                    },
                    new ()
                    {
                        Name = "Drug 6",
                        Description = "Description 6"
                    },
                    new ()
                    {
                        Name = "Drug 7",
                        Description = "Description 7"
                    },
                    new ()
                    {
                        Name = "Drug 8",
                        Description = "Description 8"
                    },
                    new ()
                    {
                        Name = "Drug 9",
                        Description = "Description 9"
                    },
                    new ()
                    {
                        Name = "Drug 10",
                        Description = "Description 10"
                    }
                };

                context.Drugs.AddRange(drugs);
                context.SaveChanges();
            }
        }
    }
}