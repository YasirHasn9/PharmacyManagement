using Microsoft.AspNetCore.Mvc;
using Pharmacy.Business;

namespace Pharmacy.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PharmaciesController : ControllerBase
{
    private readonly IPharmacyFetchingService _fetchingPharmacyService;
    private readonly IPharmacyCreationService _creationPharmacyService;
    private readonly IPharmacyUpdatingService _updatingPharmacyService;
    private readonly ILogger<PharmaciesController> _logger;

    public PharmaciesController(
        IPharmacyFetchingService fetchingPharmacyService,
        IPharmacyUpdatingService updatingPharmacyService,
        IPharmacyCreationService creationPharmacyService,
        ILogger<PharmaciesController> logger)
    {
        _fetchingPharmacyService = fetchingPharmacyService;
        _creationPharmacyService = creationPharmacyService;
        _updatingPharmacyService = updatingPharmacyService;
        _logger = logger;
    }

    [HttpGet(Name = nameof(FindPharmacies))]
    public async Task<ActionResult<IEnumerable<Business.Pharmacy>>> FindPharmacies(CancellationToken cancellationToken)
    {
        try
        {
            var pharmacies = await _fetchingPharmacyService.GetAllAsync(cancellationToken);
            return Ok(pharmacies);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting pharmacies");
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}", Name = nameof(FindPharmacyById))]
    public async Task<ActionResult> FindPharmacyById(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var pharmacy = await _fetchingPharmacyService.GetByIdAsync(id, cancellationToken);
            return Ok(pharmacy);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting pharmacy");
            return BadRequest(e.Message);
        }
    }

    [HttpPost(Name = nameof(CreatePharmacy))]
    public async Task<ActionResult> CreatePharmacy([FromBody] NewPharmacy pharmacy,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await _creationPharmacyService.CreateAsync(pharmacy, cancellationToken);
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error creating pharmacy");
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{pharmacyId}", Name = nameof(UpdatePharmacy))]
    public async Task<ActionResult> UpdatePharmacy([FromRoute] Guid pharmacyId, [FromBody] PharmacyUpdates updates,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await _updatingPharmacyService.UpdateAsync(pharmacyId, updates, cancellationToken);
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error updating pharmacy");
            return BadRequest(e.Message);
        }
    }
}