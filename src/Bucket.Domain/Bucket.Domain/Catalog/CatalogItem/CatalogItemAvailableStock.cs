namespace Bucket.Domain.Catalog.CatalogItem;

public readonly record struct CatalogItemAvailableStock
{
   public int Value { get; init; }

   private CatalogItemAvailableStock(int value) => Value = value;

   public static CatalogItemAvailableStock Create(int value) => new(value);
}