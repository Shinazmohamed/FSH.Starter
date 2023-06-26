using FSH.Starter.Application.Catalog.Categories;

namespace FSH.Starter.Host.Controllers.Catalog;
public class CategoriesController : VersionedApiController
{
    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Categories)]
    [OpenApiOperation("Create a new category.", "")]
    public Task<Guid> CreateAsync(CreateCategoryRequest request)
    {
        return Mediator.Send(request);
    }
}
