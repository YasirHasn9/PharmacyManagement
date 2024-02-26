namespace Pharmacy.Business;

public class PharmacyCreationService : IPharmacyCreationService

{
    private readonly ISqlPharmacySink _pharmacySink;

    public PharmacyCreationService(ISqlPharmacySink pharmacySink)
    {
        _pharmacySink = pharmacySink;
    }

    public async Task<Pharmacy> CreateAsync(NewPharmacy newPharmacy, CancellationToken cancellationToken)
    {
        try
        {
            var pharmacy = new Pharmacy()
            {
                Id = Guid.NewGuid(),
                Name = newPharmacy.Name,
                Address = newPharmacy.Address,
                City = newPharmacy.City,
                State = newPharmacy.State,
                Zip = newPharmacy.Zip,
                NumberOfFilledPrescriptions = newPharmacy.NumberOfFilledPrescriptions,
                CreatedDate = DateTime.Now
            };
            return await _pharmacySink.InsertAsync(pharmacy, cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception("Error creating pharmacy.");
        }
    }
}