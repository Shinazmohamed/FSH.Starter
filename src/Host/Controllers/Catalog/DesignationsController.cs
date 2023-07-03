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

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Designations)]
    [OpenApiOperation("Get a list of all designations.", "")]
    public Task<List<DesignationDetailsDto>> GetListAsync()
    {
        return Mediator.Send(new GetAllDesignationsRequest());
    }
}
