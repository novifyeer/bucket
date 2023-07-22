namespace Bucket.Domain.Catalog.CatalogBrand;

public readonly record struct CatalogBrandName
{
   public string Value { get; init; }

   private CatalogBrandName(string value) => Value = value;

   public static CatalogBrandName Create(string value) => new(value);
}