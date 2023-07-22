namespace Bucket.Domain.Catalog.CatalogType;

public readonly record struct CatalogTypeName
{
    public string Value { get; init; }

    private CatalogTypeName(string value) => Value = value;
    
    public static CatalogTypeName Create(string value) => new(value);
}