using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Business;

public class PostgresPharmacySource : IPostgresPharmacySource
{
    private readonly PharmacyContext _dbContext;

    public PostgresPharmacySource(PharmacyContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Pharmacy>> GetAllAsync(CancellationToken cancellationToken)
    {
        try 
        {
            var pharmacies = await _dbContext.Pharmacies.ToListAsync(cancellationToken);
            return pharmacies;
        }
        catch (Exception e)
        {
            throw new Exception("Pharmacies not found");
        }
    }

    public async Task<Pharmacy> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var pharmacy = await _dbContext.Pharmacies.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            return pharmacy;
        }
        catch (Exception e)
        {
            throw new Exception("Pharmacy not found");
        }
    }
}