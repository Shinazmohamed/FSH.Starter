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

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Categories)]
    [OpenApiOperation("Get category details.", "")]
    public Task<CategoryDetailsDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetCategoryRequest(id));
    }

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Categories)]
    [OpenApiOperation("Get a list of all categories.", "")]
    public Task<List<CategoryDetailsDto>> GetListAsync()
    {
        return Mediator.Send(new GetAllCategoriesRequest());
    }
}