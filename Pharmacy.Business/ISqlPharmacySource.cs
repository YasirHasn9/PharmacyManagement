namespace Pharmacy.Business;

public interface ISqlPharmacySource
{
    Task<IEnumerable<Pharmacy>> GetAllAsync(CancellationToken cancellationToken);
    Task<Pharmacy> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}