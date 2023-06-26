using FSH.Starter.Application.Catalog.Locations;

namespace FSH.Starter.Host.Controllers.Catalog;
public class LocationsController : VersionedApiController
{
    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Locations)]
    [OpenApiOperation("Create a new location.", "")]
    public Task<Guid> CreateAsync(CreateLocationsRequest request)
    {
        return Mediator.Send(request);
    }
}
