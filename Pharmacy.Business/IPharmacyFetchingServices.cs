namespace Pharmacy.Business;

public interface IPharmacyFetchingService
{
    public Task<IEnumerable<Pharmacy>> GetAllAsync(CancellationToken cancellationToken);
    public Task<Pharmacy> GetByIdAsync(Guid pharmacyId, CancellationToken cancellationToken);
    
}