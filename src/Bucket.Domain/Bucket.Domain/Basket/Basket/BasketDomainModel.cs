using Bucket.Domain.Basket.BasketItem;
using Bucket.Domain.User;

namespace Bucket.Domain.Basket.Basket;

public class BasketDomainModel
{
    private readonly HashSet<BasketItemDomainModel> _basketItems = new();

    private BasketDomainModel(
        UserId userId,
        BasketItem basketItemDomainModel)
    {
        SetUserId(userId);
        AddBasketItem(basketItemDomainModel);
    }
    
    public UserId UserId { get; private set; }

    private void SetUserId(UserId userId) => UserId = userId;

    public IEnumerable<BasketItemDomainModel> BasketItems => _basketItems;

    public void AddBasketItem(BasketItem basketItem)
    {
        var existingItem = _basketItems.FirstOrDefault(x => x.CatalogItemId == basketItem.CatalogItemId);
        if (existingItem is null)
        {
            _basketItems.Add(BasketItemDomainModel.Restore(basketItem.BasketItemId, basketItem.CatalogItemId, basketItem.BasketItemQuantity));
        }
        else
        {
            existingItem.ChangeQuantity(basketItem.BasketItemQuantity);
        }
    }

    public void ChangeBasketItemQuantity(BasketItemId basketItemId, BasketItemQuantity quantity)
    {
        var existingItem = _basketItems.FirstOrDefault(x => x.BasketItemId == basketItemId);
        
        if (existingItem is not null)
        {
            existingItem.ChangeQuantity(quantity);
        }
    }
    
    public static BasketDomainModel Create(
        UserId userId,
        BasketItem basketItem) => new(userId, basketItem);
}