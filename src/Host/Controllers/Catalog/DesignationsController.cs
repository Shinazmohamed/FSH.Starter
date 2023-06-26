using FSH.Starter.Application.Catalog.Designations;

namespace FSH.Starter.Host.Controllers.Catalog;
public class DesignationsController : VersionedApiController
{
    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Designations)]
    [OpenApiOperation("Create a new designation.", "")]
    public Task<Guid> CreateAsync(CreateDesignationsRequest request)
    {
        return Mediator.Send(request);
    }
}
