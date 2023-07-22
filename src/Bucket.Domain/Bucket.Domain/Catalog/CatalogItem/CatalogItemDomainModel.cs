using Bucket.Domain.Catalog.CatalogBrand;
using Bucket.Domain.Catalog.CatalogType;

namespace Bucket.Domain.Catalog.CatalogItem;

public class CatalogItemDomainModel
{
    private CatalogItemDomainModel(
        CatalogItemName name,
        CatalogItemDescription description,
        CatalogItemAvailableStock availableStock,
        CatalogItemPrice price,
        CatalogBrandId catalogBrandId,
        CatalogTypeId catalogTypeId)
    {
        SetName(name);
        SetDescription(description);
        SetAvailableStock(availableStock);
        SetPrice(price);
        SetCatalogBrandId(catalogBrandId);
        SetCatalogTypeId(catalogTypeId);
    }

    public CatalogItemId CatalogItemId { get; private set; }

    private void SetCatalogItemId(CatalogItemId catalogItemId) => CatalogItemId = catalogItemId;
    
    public CatalogItemName Name { get; private set; }

    private void SetName(CatalogItemName name) => Name = name;

    public CatalogItemDescription Description { get; private set; }

    private void SetDescription(CatalogItemDescription description) => Description = description;

    public CatalogItemAvailableStock AvailableStock { get; private set; }

    private void SetAvailableStock(CatalogItemAvailableStock availableStock) => AvailableStock = availableStock;

    public CatalogItemPrice Price { get; private set; }

    private void SetPrice(CatalogItemPrice price) => Price = price;

    public CatalogBrandId CatalogBrandId { get; private set; }

    private void SetCatalogBrandId(CatalogBrandId catalogBrand) => CatalogBrandId = catalogBrand;

    public CatalogTypeId CatalogTypeId { get; private set; }

    private void SetCatalogTypeId(CatalogTypeId catalogType) => CatalogTypeId = catalogType;

    public static CatalogItemDomainModel Create(
        CatalogItemName name,
        CatalogItemDescription description,
        CatalogItemAvailableStock availableStock,
        CatalogItemPrice price,
        CatalogBrandId catalogBrandId,
        CatalogTypeId catalogTypeId) => new(name, description, availableStock, price, catalogBrandId, catalogTypeId);
}