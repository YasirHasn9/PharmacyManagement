namespace Pharmacy.Business;

public interface ISqlPharmacySink
{
    Task<Pharmacy> InsertAsync(Pharmacy pharmacy, CancellationToken cancellationToken);
    
    Task<Pharmacy> UpdateAsync(Pharmacy pharmacy, CancellationToken cancellationToken);
    
}