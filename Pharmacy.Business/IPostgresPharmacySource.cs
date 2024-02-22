namespace Pharmacy.Business;

public interface IPostgresPharmacySource
{
    Task<IEnumerable<Pharmacy>> GetAllAsync(CancellationToken cancellationToken);
    Task<Pharmacy> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}