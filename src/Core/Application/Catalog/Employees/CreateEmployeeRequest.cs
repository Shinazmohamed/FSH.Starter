using FSH.Starter.Domain.Common.Events;

namespace FSH.Starter.Application.Catalog.Employees;
public class CreateEmployeeRequest : IRequest<Guid>
{
    public string FullName { get; set; } = default!;
    public DateTime JoinedDate { get; set; } = default!;
    public Guid DesignationId { get; set; } = default!;
    public Guid CategoryId { get; set; } = default!;
    public Guid LocationId { get; set; } = default!;
}
public class CreateEmployeeRequestHandler : IRequestHandler<CreateEmployeeRequest, Guid>
{
    private readonly IRepository<Employee> _repository;

    public CreateEmployeeRequestHandler(IRepository<Employee> repository) =>
        _repository = repository;

    public async Task<Guid> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
    {
        var employee = new Employee(request.FullName, request.JoinedDate, request.DesignationId, request.CategoryId, request.LocationId);

        // Add Domain Events to be raised after the commit
        employee.DomainEvents.Add(EntityCreatedEvent.WithEntity(employee));

        await _repository.AddAsync(employee, cancellationToken);

        return employee.Id;
    }
}