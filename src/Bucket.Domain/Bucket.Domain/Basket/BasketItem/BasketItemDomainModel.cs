using Bucket.Domain.Catalog.CatalogItem;

namespace Bucket.Domain.Basket.BasketItem;

public class BasketItemDomainModel
{
    private BasketItemDomainModel(
        BasketItemId basketItemId,
        CatalogItemId catalogItemId,
        BasketItemQuantity quantity) : this(catalogItemId, quantity)
    {
        SetBasketItemId(basketItemId);
    }

    private BasketItemDomainModel(
        CatalogItemId catalogItemId,
        BasketItemQuantity quantity)
    {
        SetCatalogItemId(catalogItemId);
        SetQuantity(quantity);
    }

    public BasketItemId BasketItemId { get; private set; }

    private void SetBasketItemId(BasketItemId basketItemId) => BasketItemId = basketItemId;

    public BasketItemQuantity Quantity { get; private set; }

    private void SetQuantity(BasketItemQuantity quantity) => Quantity = quantity;

    public CatalogItemId CatalogItemId { get; private set; }

    private void SetCatalogItemId(CatalogItemId catalogItemId) => CatalogItemId = catalogItemId;

    public void ChangeQuantity(BasketItemQuantity quantity)
    {
        Quantity += quantity;
    }

    public static BasketItemDomainModel Create(
        CatalogItemId catalogItemId,
        BasketItemQuantity quantity) => new(catalogItemId, quantity);

    public static BasketItemDomainModel Restore(
        BasketItemId basketItemId,
        CatalogItemId catalogItemId,
        BasketItemQuantity quantity) => new(basketItemId, catalogItemId, quantity);
}