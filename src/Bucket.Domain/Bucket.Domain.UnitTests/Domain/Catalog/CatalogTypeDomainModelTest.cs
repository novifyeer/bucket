using Bucket.Domain.Catalog.CatalogType;

namespace Bucket.Domain.UnitTests.Domain.Catalog;

public class CatalogTypeDomainModelTest
{
    public CatalogTypeDomainModelTest () { }
    
    [Fact(DisplayName = "Successful catalog type creation with valid data")]
    public void CreateCatalogType_WithValidData_CatalogTypeCreated()
    {
        // Arrange
        var name = CatalogTypeName.Create("T-Shirt");
        
        // Act
        var catalogTypeDomain = CatalogTypeDomainModel.Create(name);
        
        // Assert
        catalogTypeDomain.Should().NotBeNull();
        catalogTypeDomain.Name.Value.Should().Be("T-Shirt");
    }
}