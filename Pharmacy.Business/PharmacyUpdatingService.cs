using Microsoft.Extensions.Logging;

namespace Pharmacy.Business;

public class PharmacyUpdatingService : IPharmacyUpdatingService
{
    private readonly IPostgresPharmacySink _pharmacySink;
    private readonly IPostgresPharmacySource _source;
    private readonly ILogger<PharmacyUpdatingService> _logger;

    public PharmacyUpdatingService(IPostgresPharmacySink pharmacySink, IPostgresPharmacySource source, ILogger<PharmacyUpdatingService> logger)
    {
        _pharmacySink = pharmacySink;
        _source = source;
        _logger = logger;
    }

    public async Task<Pharmacy> UpdateAsync(Guid id, PharmacyUpdates updates, CancellationToken cancellationToken)
    {
        try
        {
            var pharmacy = await _source.GetByIdAsync(id, cancellationToken);
            if(pharmacy == null)
            {
                throw new Exception("Pharmacy not updated");
            }
            
            var pharmacyUpdates = new Pharmacy
            {
                Id = pharmacy.Id,
                Name = updates.Name ?? pharmacy.Name,
                Address = updates.Address ?? pharmacy.Address,
                City = updates.City ?? pharmacy.City,
                State = updates.State ?? pharmacy.State,
                Zip = updates.Zip ?? pharmacy.Zip,
                NumberOfFilledPrescriptions = updates.NumberOfFilledPrescriptions,
                UpdatedDate = DateTime.UtcNow
            };
            return await _pharmacySink.UpdateAsync(pharmacyUpdates, cancellationToken);
        }
        catch (Exception e)
        {
            // Log the exception message and stack trace for debugging
            _logger.LogError(e, "Error updating pharmacy with ID {Id}. Exception: {Message}. Stack Trace: {StackTrace}", id, e.Message, e.StackTrace);
            throw new Exception("Pharmacy not updated");
            throw new Exception("Pharmacy not updated");
        }
    }
}