namespace Bucket.Domain.Catalog.CatalogType;

public readonly record struct CatalogTypeId
{
    public int Value { get; init; }

    private CatalogTypeId(int value) => Value = value;

    public static CatalogTypeId Create(int value) => new(value);   
}