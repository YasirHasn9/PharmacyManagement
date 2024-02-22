namespace Pharmacy.Business;

public class PharmacyFetchingService : IPharmacyFetchingService
{
    private readonly IPostgresPharmacySource _source;

    public PharmacyFetchingService(IPostgresPharmacySource source)
    {
        _source = source;
    }
    
    public async Task<IEnumerable<Pharmacy>> GetAllAsync(CancellationToken cancellationToken)
    {
        var pharmacies = await _source.GetAllAsync(cancellationToken);
        if(pharmacies == null)
        {
            throw new Exception("Pharmacies not found");
        }
        return pharmacies;
    }
    
    public async Task<Pharmacy> GetByIdAsync(Guid pharmacyId, CancellationToken cancellationToken)
    {
      
        var pharmacy = await _source.GetByIdAsync(pharmacyId, cancellationToken);
        if(pharmacy == null)
        {
            throw new Exception("Pharmacy not found");
        }

        return pharmacy;
    }
}