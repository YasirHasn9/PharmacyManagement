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

    public async Task<Pharmacy> UpdateAsync(Guid id, PharmacyUpdates updates, CancellationToken cancellationToken)
    {
        try
        {
            var existingPharmacy = await _context.Pharmacies.FindAsync(id);
            if (existingPharmacy == null)
            {
                throw new Exception("Pharmacy not found");
            }

            existingPharmacy.Name = updates.Name ?? existingPharmacy.Name;
            existingPharmacy.Address = updates.Address ?? existingPharmacy.Address;
            existingPharmacy.City = updates.City ?? existingPharmacy.City;
            existingPharmacy.State = updates.State ?? existingPharmacy.State;
            existingPharmacy.Zip = updates.Zip ?? existingPharmacy.Zip;
            existingPharmacy.NumberOfFilledPrescriptions = updates?.NumberOfFilledPrescriptions ?? existingPharmacy.NumberOfFilledPrescriptions;
            existingPharmacy.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);
            return existingPharmacy;
        }
        catch (Exception e)
        {
            throw new Exception("Error updating pharmacy.");
        }
    }
}