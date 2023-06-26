using FSH.Starter.Domain.Common.Events;

namespace FSH.Starter.Application.Catalog.Employees;
public class UpdateEmployeeRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = default!;
    public DateTime JoinedDate { get; set; } = default!;
    public Guid DesignationId { get; set; } = default!;
    public Guid CategoryId { get; set; } = default!;
    public Guid LocationId { get; set; } = default!;
}

public class UpdateEmployeeRequestHandler : IRequestHandler<UpdateEmployeeRequest, Guid>
{
    private readonly IRepository<Employee> _repository;
    private readonly IStringLocalizer _t;

    public UpdateEmployeeRequestHandler(IRepository<Employee> repository, IStringLocalizer<UpdateEmployeeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<Guid> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
    {
        var employee = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = employee ?? throw new NotFoundException(_t["Product {0} Not Found.", request.Id]);

        var updatedEmployee = employee.Update(request.FullName, request.JoinedDate, request.DesignationId, request.CategoryId, request.LocationId);

        // Add Domain Events to be raised after the commit
        employee.DomainEvents.Add(EntityUpdatedEvent.WithEntity(employee));

        await _repository.UpdateAsync(updatedEmployee, cancellationToken);

        return request.Id;
    }
}