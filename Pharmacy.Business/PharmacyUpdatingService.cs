using Microsoft.Extensions.Logging;

namespace Pharmacy.Business;

public class PharmacyUpdatingService : IPharmacyUpdatingService
{
    private readonly ISqlPharmacySink _pharmacySink;
    private readonly ISqlPharmacySource _source;
    private readonly ILogger<PharmacyUpdatingService> _logger;

    public PharmacyUpdatingService(ISqlPharmacySink pharmacySink, ISqlPharmacySource source,
        ILogger<PharmacyUpdatingService> logger)
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
            if (pharmacy == null)
            {
                throw new Exception("Pharmacy not found");
            }

            return await _pharmacySink.UpdateAsync(pharmacy.Id, updates, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error updating pharmacy with ID {Id}. Exception: {Message}. Stack Trace: {StackTrace}",
                id,
                e.Message, e.StackTrace);
            throw new Exception("Pharmacy not updated");
        }
    }
}