namespace Pharmacy.Business;

public interface ISqlPharmacySink
{
    Task<Pharmacy> InsertAsync(Pharmacy pharmacy, CancellationToken cancellationToken);

    Task<Pharmacy> UpdateAsync(Guid id, PharmacyUpdates pharmacy, CancellationToken cancellationToken);
}