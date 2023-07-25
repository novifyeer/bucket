using Bucket.Domain.Basket.BasketItem;
using Bucket.Domain.Catalog.CatalogItem;

namespace Bucket.Domain.Basket.Basket;

public readonly record struct BasketItem
{
    public BasketItemId BasketItemId { get; init; }
    public CatalogItemId CatalogItemId { get; init; }
    
    public BasketItemQuantity BasketItemQuantity { get; init; }

    private BasketItem(BasketItemId basketItemId, CatalogItemId catalogItemId, BasketItemQuantity quantity)
    {
        BasketItemId = basketItemId;
        CatalogItemId = catalogItemId;
        BasketItemQuantity = quantity;
    }

    public static BasketItem Create(
        BasketItemId basketItemId,
        CatalogItemId catalogItemId,
        BasketItemQuantity quantity) => new(basketItemId, catalogItemId, quantity);
}