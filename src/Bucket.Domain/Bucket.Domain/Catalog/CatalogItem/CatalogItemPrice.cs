using Bucket.Domain.Common.Money;

namespace Bucket.Domain.Catalog.CatalogItem;

public readonly record struct CatalogItemPrice
{
    public Money Value { get; init; }

    private CatalogItemPrice(Money value) => Value = value;

    public static CatalogItemPrice Create(Money value) => new(value);
}