namespace Pharmacy.Business;

public class SqlPharmacySink : ISqlPharmacySink
{
    private readonly PharmacyContext _context;

    public SqlPharmacySink(PharmacyContext context)
    {
        _context = context;
    }

    public async Task<Pharmacy> InsertAsync(Pharmacy pharmacy, CancellationToken cancellationToken)
    {
        try
        {
            _context.Pharmacies.Add(pharmacy);
            await _context.SaveChangesAsync(cancellationToken);
            return pharmacy;
        }
        catch (Exception e)
        {
            throw new Exception("Error inserting new pharmacy.");
        }
    }
    
    public async Task<Pharmacy> UpdateAsync(Pharmacy pharmacy, CancellationToken cancellationToken)
    {
        try
        {
            var existingPharmacy = await _context.Pharmacies.FindAsync(pharmacy.Id);
            if (existingPharmacy == null)
            {
                throw new Exception("Pharmacy not found");
            }

            existingPharmacy.Name = pharmacy.Name;
            existingPharmacy.Address = pharmacy.Address;
            existingPharmacy.City = pharmacy.City;
            existingPharmacy.State = pharmacy.State;
            existingPharmacy.Zip = pharmacy.Zip;
            existingPharmacy.NumberOfFilledPrescriptions = pharmacy.NumberOfFilledPrescriptions;
            existingPharmacy.UpdatedDate = pharmacy.UpdatedDate;

            await _context.SaveChangesAsync(cancellationToken);
            return existingPharmacy;
        }
        catch (Exception e)
        {
            throw new Exception("Error updating pharmacy.");
        }
    }
}