namespace Bucket.Domain.Catalog.CatalogType;

public class CatalogTypeDomainModel
{
    private CatalogTypeDomainModel(CatalogTypeName name)
    {
        SetName(name);
    }

    public CatalogTypeId TypeId { get; private set; }

    private void SetTypeId(CatalogTypeId brandId) => TypeId = brandId;

    public CatalogTypeName Name { get; private set; }

    private void SetName(CatalogTypeName name) => Name = name;

    public static CatalogTypeDomainModel Create(CatalogTypeName name) => new(name);
}