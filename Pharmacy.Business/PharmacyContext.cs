using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Business;
public class PharmacyContext : DbContext
{
    public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options) { }
    
    public DbSet<Pharmacy> Pharmacies { get; set; } = null!;
}