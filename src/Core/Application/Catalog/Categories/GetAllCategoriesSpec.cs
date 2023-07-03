namespace FSH.Starter.Application.Catalog.Categories;
public class GetAllCategoriesSpec : Specification<Category, CategoryDetailsDto>, ISingleResultSpecification
{
    public GetAllCategoriesSpec() =>
        Query.OrderBy(e => e.Name);
}
