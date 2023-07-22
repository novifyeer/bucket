﻿namespace Bucket.Domain.Catalog.CatalogBrand;

public readonly record struct CatalogBrandId : IDomainObjectValue
{
    public int Value { get; init; }

    private CatalogBrandId(int value) => Value = value;

    public static CatalogBrandId Create(int value) => new(value);   
}