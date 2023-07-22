namespace Bucket.Domain.Catalog.CatalogBrand;

public class CatalogBrandDomainModel
{
    private CatalogBrandDomainModel(CatalogBrandName name)
    {
        SetName(name);
    }

    public CatalogBrandId BrandId { get; private set; }

    private void SetBrandId(CatalogBrandId brandId)
    {
        BrandId = brandId;
    }

    public CatalogBrandName Name { get; private set; }

    private void SetName(CatalogBrandName name)
    {
        Name = name;
    }

    public static CatalogBrandDomainModel Create(CatalogBrandName name) => new(name);
}