using Moq;
using Pharmacy.Business;
using Xunit;

namespace Pharmacy.Test.Pharmacy;

public class PharmacyUpdatingServiceTests
{
    private readonly Mock<ISqlPharmacySink> _mockPharmacySink;
    private readonly Mock<ISqlPharmacySource> _mockPharmacySource;
    private readonly PharmacyUpdatingService _updatingService;
    private readonly Business.Pharmacy _testPharmacy;
    private readonly PharmacyUpdates _testUpdates;

    public PharmacyUpdatingServiceTests()
    {
        _mockPharmacySink = new Mock<ISqlPharmacySink>();
        _mockPharmacySource = new Mock<ISqlPharmacySource>();
        _updatingService = new PharmacyUpdatingService(_mockPharmacySink.Object, _mockPharmacySource.Object,
            Mock.Of<Microsoft.Extensions.Logging.ILogger<PharmacyUpdatingService>>());

        _testPharmacy = new Business.Pharmacy
        {
            Id = Guid.NewGuid(),
            Name = "Test Pharmacy",
            Address = "Test Address"
        };

        _testUpdates = new PharmacyUpdates
        {
            Name = "Updated Pharmacy",
            Address = "Updated Address"
        };
    }

    [Fact]
    public async void UpdateAsync_ReturnsUpdatedPharmacy_WhenIdExists()
    {
        _mockPharmacySource.Setup(s => s.GetByIdAsync(_testPharmacy.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(_testPharmacy);
        _mockPharmacySink.Setup(s => s.UpdateAsync(_testPharmacy.Id, _testUpdates, It.IsAny<CancellationToken>()))
            .ReturnsAsync(_testPharmacy);

        var result = await _updatingService.UpdateAsync(_testPharmacy.Id, _testUpdates, CancellationToken.None);

        Assert.Equal(_testPharmacy, result);
    }

    [Fact]
    public async void UpdateAsync_ThrowsException_WhenIdDoesNotExist()
    {
        _mockPharmacySource.Setup(s => s.GetByIdAsync(_testPharmacy.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Business.Pharmacy)null);

        await Assert.ThrowsAsync<Exception>(() =>
            _updatingService.UpdateAsync(_testPharmacy.Id, _testUpdates, CancellationToken.None));
    }

    [Fact]
    public async void UpdateAsync_ThrowsException_WhenUpdateFails()
    {
        _mockPharmacySource.Setup(s => s.GetByIdAsync(_testPharmacy.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(_testPharmacy);
        _mockPharmacySink.Setup(s => s.UpdateAsync(_testPharmacy.Id, _testUpdates, It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());

        await Assert.ThrowsAsync<Exception>(() =>
            _updatingService.UpdateAsync(_testPharmacy.Id, _testUpdates, CancellationToken.None));
    }
}