namespace Pharmacy.Business;

public interface IPostgresPharmacySink
{
    Task<Pharmacy> InsertAsync(Pharmacy pharmacy, CancellationToken cancellationToken);
    
    Task<Pharmacy> UpdateAsync(Pharmacy pharmacy, CancellationToken cancellationToken);
    
}