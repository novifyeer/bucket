namespace Bucket.Domain.Catalog.CatalogItem;

public readonly record struct CatalogItemDescription
{
    public string Value { get; init; }

    private CatalogItemDescription(string value) => Value = value;

    public static CatalogItemDescription Create(string value) => new(value);
}