namespace FSH.Starter.Application.Catalog.Categories;
internal class CategoryByIdSpec : Specification<Category, CategoryDetailsDto>, ISingleResultSpecification
{
    public CategoryByIdSpec(Guid id) =>
    Query
        .Where(p => p.Id == id);
}
