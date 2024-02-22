namespace Pharmacy.Business;

public interface IPharmacyCreationService
{
    Task<Pharmacy> CreateAsync(NewPharmacy pharmacy, CancellationToken cancellationToken);
}