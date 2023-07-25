using Bucket.Domain.Basket.BasketItem;
using Bucket.Domain.Catalog.CatalogItem;

namespace Bucket.Domain.UnitTests.Domain.Basket.BasketItemTests;

public class BasketItemDomainModelTest
{
    public BasketItemDomainModelTest () { }

    [Fact(DisplayName = "successfully basket item creation with valid data")]
    public void CreateBasketItemWithValidDataShouldCreateBasketItem()
    {
        // Arrange
        var catalogItemId = CatalogItemId.Create(1);

        var amount = Amount.Create(1, AmountUnit.Unit);
        var quantity = BasketItemQuantity.Create(amount);
        
        // Act
        var basketItemDomain = BasketItemDomainModel.Create(catalogItemId, quantity);
        
        // Assert
        basketItemDomain.Should().NotBeNull();
        basketItemDomain.CatalogItemId.Value.Should().Be(1);
        basketItemDomain.Quantity.Should().BeEquivalentTo(quantity);
    }

    [Fact(DisplayName = "successfully change the quantity of the basket item")]
    public void ChangeBasketItemQuantityShouldChangeQuantity()
    {
        // Arrange
        var catalogItemId = CatalogItemId.Create(1);

        var quantity = BasketItemQuantity.Create(Amount.Create(1, AmountUnit.Unit));
        var expectedQuantity = BasketItemQuantity.Create(Amount.Create(2, AmountUnit.Unit));
        
        // Act
        var basketItemDomain = BasketItemDomainModel.Create(catalogItemId, quantity);
        basketItemDomain.ChangeQuantity(quantity);

        // Assert
        basketItemDomain.Quantity.Should().Be(expectedQuantity);
    }
}