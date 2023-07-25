using Bucket.Domain.Basket.Basket;
using Bucket.Domain.Basket.BasketItem;
using Bucket.Domain.Catalog.CatalogItem;
using Bucket.Domain.User;

namespace Bucket.Domain.UnitTests.Domain.Basket.BasketTests;

public class BasketDomainModelTest
{
    public BasketDomainModelTest() { }

    [Fact(DisplayName = "successfully basket creation with minimal basket items")]
    public void CreateBasketWithMinimalProductItemsShouldCreateBasket()
    {
        // Arrange
        var userId = UserId.Create(1);
        var catalogItemId = CatalogItemId.Create(1);
        var basketItemId = BasketItemId.Create(1);
        
        var quantity = BasketItemQuantity.Create(Amount.Create(1, AmountUnit.Unit));
        var basketItem = BasketItem.Create(basketItemId, catalogItemId, quantity);

        // Act
        var basketDomain = BasketDomainModel.Create(userId, basketItem);

        // Assert
        basketDomain.Should().NotBeNull();
        basketDomain.UserId.Value.Should().Be(1);
        basketDomain.BasketItems.Should().HaveCount(1);
        basketDomain.BasketItems.Should().Satisfy(i => i.Quantity == quantity);
    }

    [Fact(DisplayName = "successfully adding an basket item to the basket")]
    public void AddBasketItemInBasketShouldAddItemInBasket()
    {
        // Arrange
        var userId = UserId.Create(1);
        
        var quantity = BasketItemQuantity.Create(Amount.Create(1, AmountUnit.Unit));
        var basketItem = BasketItem.Create(BasketItemId.Create(1), CatalogItemId.Create(1), quantity);
        var basketItem2 = BasketItem.Create(BasketItemId.Create(2), CatalogItemId.Create(2), quantity);

        // Act
        var basketDomain = BasketDomainModel.Create(userId, basketItem);
        basketDomain.AddBasketItem(basketItem2);
        
        // Assert
        basketDomain.Should().NotBeNull();
        basketDomain.BasketItems.Should().HaveCount(2);
    }
    
    [Fact(DisplayName = "successfully changing the quantity of items in the basket if add a duplicate basket item")]
    public void AddBasketItemInBasketShouldChangeQuantityIfDuplicateBasketItem()
    {
        // Arrange
        var userId = UserId.Create(1);
        var basketItemId = BasketItemId.Create(1);
        var catalogItemId = CatalogItemId.Create(1);

        var quantity = BasketItemQuantity.Create(Amount.Create(1, AmountUnit.Unit));
        var expectedQuantity = BasketItemQuantity.Create(Amount.Create(2, AmountUnit.Unit));
        
        var basketItem = BasketItem.Create(basketItemId, catalogItemId, quantity);

        // Act
        var basketDomain = BasketDomainModel.Create(userId, basketItem);
        basketDomain.AddBasketItem(basketItem);
        
        // Assert
        basketDomain.Should().NotBeNull();
        basketDomain.BasketItems.Should().HaveCount(1);
        basketDomain.BasketItems.Should().Satisfy(i => i.Quantity == expectedQuantity);
    }

    [Fact(DisplayName = "successfully changing the quantity of an existing basket item in basket")]
    public void ChangeBasketItemQuantityShouldChangeQuantityExistingItem()
    {
        // Arrange
        var userId = UserId.Create(1);
        var catalogItemId = CatalogItemId.Create(1);
        var basketItemId = BasketItemId.Create(1);
        
        var quantity = BasketItemQuantity.Create(Amount.Create(1, AmountUnit.Unit));
        var expectedQuantity = BasketItemQuantity.Create(Amount.Create(2, AmountUnit.Unit));
        
        var basketItem = BasketItem.Create(basketItemId, catalogItemId, quantity);

        // Act
        var basketDomain = BasketDomainModel.Create(userId, basketItem);
        basketDomain.ChangeBasketItemQuantity(basketItemId, quantity);
        
        // Assert
        basketDomain.Should().NotBeNull();
        basketDomain.UserId.Value.Should().Be(1);
        basketDomain.BasketItems.Should().HaveCount(1);
        basketDomain.BasketItems.Should().Satisfy(i => i.Quantity == expectedQuantity);
    }
}