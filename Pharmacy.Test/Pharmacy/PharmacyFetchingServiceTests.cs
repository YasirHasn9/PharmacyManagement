using Moq;
using Pharmacy.Business;
using Xunit;

namespace Pharmacy.Test.Pharmacy;

public class PharmacyFetchingServiceTests
{
    private readonly Mock<ISqlPharmacySource> _mockPharmacySource = new();
    private readonly PharmacyFetchingService _fetchingService;

    public PharmacyFetchingServiceTests()
    {
        _fetchingService = new PharmacyFetchingService(_mockPharmacySource.Object);

        _mockPharmacySource
            .Setup(s => s.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Business.Pharmacy>
            {
                new Business.Pharmacy
                {
                    Id = Guid.NewGuid(),
                    Name = "Pharmacy 1",
                    Address = "Address 1",
                },
                new Business.Pharmacy
                {
                    Id = Guid.NewGuid(),
                    Name = "Pharmacy 2",
                    Address = "Address 2",
                }
            });

        _mockPharmacySource.Setup(s => s.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Business.Pharmacy
            {
                Id = Guid.NewGuid(),
                Name = "Pharmacy 1",
                Address = "Address 1",
            });
    }

    [Fact]
    public async Task GetAllAsync_ReturnsPharmacies()
    {
        var result = await _fetchingService.GetAllAsync(CancellationToken.None);
        AssertPharmacies(result);
    }

    [Fact]
    public async Task ThrowsException_WhenPharmaciesNotFound()
    {
        GivenPharmaciesNotReturned();
        await Assert.ThrowsAsync<Exception>(() => _fetchingService.GetAllAsync(CancellationToken.None));
    }

    [Fact]
    public async Task ThrowsException_WhenPharmacyNotFound()
    {
        GivenPharmacyNotFound();
        await Assert.ThrowsAsync<Exception>(() =>
            _fetchingService.GetByIdAsync(Guid.NewGuid(), CancellationToken.None));
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsPharmacy()
    {
        var result = await _fetchingService.GetByIdAsync(Guid.NewGuid(), CancellationToken.None);
        Assert.NotNull(result);
        AssertPharmacy(result);
    }

    private void GivenPharmacyNotFound()
    {
        _mockPharmacySource.Setup(s => s.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Business.Pharmacy)null);
    }

    private void GivenPharmaciesNotReturned()
    {
        _mockPharmacySource.Setup(s => s.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync((IEnumerable<Business.Pharmacy>)null);
    }

    private void AssertPharmacies(IEnumerable<Business.Pharmacy> pharmacies)
    {
        Assert.NotEmpty(pharmacies);
        foreach (var pharmacy in pharmacies)
        {
            AssertPharmacy(pharmacy);
        }
    }

    private void AssertPharmacy(Business.Pharmacy pharmacy)
    {
        Assert.NotNull(pharmacy);
        Assert.NotEqual(Guid.Empty, pharmacy.Id);
        Assert.False(string.IsNullOrWhiteSpace(pharmacy.Name));
        Assert.False(string.IsNullOrWhiteSpace(pharmacy.Address));
    }
}