namespace Bucket.Domain.Basket.BasketItem;

public readonly record struct BasketItemId
{
    public int Value { get; init; }

    private BasketItemId(int value) => Value = value;

    public static BasketItemId Create(int value) => new(value);      
}