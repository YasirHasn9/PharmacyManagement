namespace Pharmacy.Business;

public interface IPharmacyUpdatingService
{
    Task<Pharmacy> UpdateAsync(Guid id, PharmacyUpdates pharmacy, CancellationToken cancellationToken);
}