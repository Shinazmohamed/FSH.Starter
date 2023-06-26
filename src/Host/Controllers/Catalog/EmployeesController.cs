using FSH.Starter.Application.Catalog.Employees;

namespace FSH.Starter.Host.Controllers.Catalog;
public class EmployeesController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Employees)]
    [OpenApiOperation("Search employees using available filters.", "")]
    public Task<PaginationResponse<EmployeeDto>> SearchAsync(SearchEmployeesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Employees)]
    [OpenApiOperation("Get employee details.", "")]
    public Task<EmployeeDetailsDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetEmployeeRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Employees)]
    [OpenApiOperation("Create a new employee.", "")]
    public Task<Guid> CreateAsync(CreateEmployeeRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Employees)]
    [OpenApiOperation("Update a employee.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateEmployeeRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Employees)]
    [OpenApiOperation("Delete a employee.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteEmployeeRequest(id));
    }
}
