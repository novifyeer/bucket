namespace Bucket.Domain.Basket.BasketItem;

public readonly record struct BasketItemQuantity
{
   public Amount Value { get; init; }

   private BasketItemQuantity(Amount value) => Value = value;
   
   public static BasketItemQuantity operator +(BasketItemQuantity left, BasketItemQuantity right) => new(left.Value + right.Value);
   
   public static BasketItemQuantity Create(Amount value) => new(value);
}