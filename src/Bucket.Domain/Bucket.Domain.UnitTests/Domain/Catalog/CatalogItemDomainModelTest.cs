using Bucket.Domain.Catalog.CatalogBrand;
using Bucket.Domain.Catalog.CatalogItem;
using Bucket.Domain.Catalog.CatalogType;
using Bucket.Domain.UnitTests.Common.MoneyComplexType.Factories;

namespace Bucket.Domain.UnitTests.Domain.Catalog;

public class CatalogItemDomainModelTest
{
    public CatalogItemDomainModelTest () { }

    [Fact(DisplayName = "Successful catalog item creation with valid data")]
    public void CreateCatalogItem_WithValidData_CatalogItemCreated()
    {
        // Arrange
        var name = CatalogItemName.Create(".NET Bot Black Hoodie");
        var description = CatalogItemDescription.Create(".NET Bot Black Hoodie, and more");
        var availableStock = CatalogItemAvailableStock.Create(100);
        var price = CatalogItemPrice.Create(MoneyFactory.Create());
        
        var brandId = CatalogBrandId.Create(1);
        var typeId = CatalogTypeId.Create(1);
        
        // Act
        var catalogItemDomain = CatalogItemDomainModel.Create(name, description, availableStock, price, brandId, typeId);
        
        // Assert
        catalogItemDomain.Should().NotBeNull();
        catalogItemDomain.Name.Value.Should().Be(".NET Bot Black Hoodie");
        catalogItemDomain.Description.Value.Should().Be(".NET Bot Black Hoodie, and more");
        catalogItemDomain.AvailableStock.Value.Should().Be(100);
        catalogItemDomain.Price.Should().BeEquivalentTo(price);
        catalogItemDomain.CatalogBrandId.Value.Should().Be(1);
        catalogItemDomain.CatalogTypeId.Value.Should().Be(1);
    }
}