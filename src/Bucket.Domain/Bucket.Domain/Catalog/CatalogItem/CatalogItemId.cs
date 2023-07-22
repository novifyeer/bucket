namespace Bucket.Domain.Catalog.CatalogItem;

public readonly record struct CatalogItemId
{
    public int Value { get; init; }

    private CatalogItemId(int value) => Value = value;

    public static CatalogItemId Create(int value) => new(value);
}