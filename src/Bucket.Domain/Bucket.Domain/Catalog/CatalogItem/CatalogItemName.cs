namespace Bucket.Domain.Catalog.CatalogItem;

public readonly record struct CatalogItemName
{
   public string Value { get; init; }

   private CatalogItemName(string value) => Value = value;

   public static CatalogItemName Create(string value) => new(value);
}