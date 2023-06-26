﻿using FSH.Starter.Domain.Common.Events;

namespace FSH.Starter.Application.Catalog.Employees;
public class DeleteEmployeeRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteEmployeeRequest(Guid id) => Id = id;
}

public class DeleteEmployeeRequestHandler : IRequestHandler<DeleteEmployeeRequest, Guid>
{
    private readonly IRepository<Employee> _repository;
    private readonly IStringLocalizer _t;

    public DeleteEmployeeRequestHandler(IRepository<Employee> repository, IStringLocalizer<DeleteEmployeeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<Guid> Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
    {
        var employee = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = employee ?? throw new NotFoundException(_t["Employee {0} Not Found.", request.Id]);

        // Add Domain Events to be raised after the commit
        employee.DomainEvents.Add(EntityDeletedEvent.WithEntity(employee));

        await _repository.DeleteAsync(employee, cancellationToken);

        return request.Id;
    }
}