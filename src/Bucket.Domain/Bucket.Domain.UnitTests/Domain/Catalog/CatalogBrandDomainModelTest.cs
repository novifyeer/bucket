using Bucket.Domain.Catalog.CatalogBrand;

namespace Bucket.Domain.UnitTests.Domain.Catalog;

public class CatalogBrandDomainModelTest
{
    public CatalogBrandDomainModelTest () { }

    [Fact(DisplayName = "Successful catalog brand creation with valid data")]
    public void CreateCatalogBrand_WithValidData_CatalogBrandCreated()
    {
        // Arrange
        var name = CatalogBrandName.Create(".NET");
        
        // Act
        var catalogBrandDomain = CatalogBrandDomainModel.Create(name);
        
        // Assert
        catalogBrandDomain.Should().NotBeNull();
        catalogBrandDomain.Name.Value.Should().Be(".NET");
    }
}