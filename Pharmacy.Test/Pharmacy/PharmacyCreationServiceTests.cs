using Pharmacy.Business;
using Moq;
using Xunit;

namespace Pharmacy.Test.Pharmacy;

public class PharmacyCreationServiceTests
{
    private readonly Mock<IPostgresPharmacySink> _mockPharmacySink = new();
    private readonly PharmacyCreationService _creationService;
    private readonly CancellationToken _cancellationToken = CancellationToken.None;
    
    private readonly NewPharmacy _newPharmacy = new()
    {
        Name = "Test Pharmacy",
        Address = "123 Test St",
        City = "Test City",
        State = "TS",
        Zip = "12345",
        NumberOfFilledPrescriptions = 0
    };
    private readonly Business.Pharmacy _pharmacy = new();

    private Business.Pharmacy? _result;

    public PharmacyCreationServiceTests()
    {
        _creationService = new PharmacyCreationService(_mockPharmacySink.Object);

        _mockPharmacySink
            .Setup(p => p.InsertAsync(It.IsAny<Business.Pharmacy>(), _cancellationToken))
            .Returns<Business.Pharmacy, CancellationToken>((a, _) => Task.FromResult(_pharmacy));
    }

    [Fact]
    public async Task CreateAsync_ShouldCallInsertAsyncOnce()
    {
        await WhenCreating();
        AsserInserted();
        Assert.Equal(_pharmacy, _result);
    }

    private async Task WhenCreating()
    {
        _result = await _creationService.CreateAsync(_newPharmacy, CancellationToken.None);
    }

    private void AsserInserted()
    {
        _mockPharmacySink.Verify(p => p.InsertAsync(It.IsAny<Business.Pharmacy>(), _cancellationToken), Times.Once);
    }
}