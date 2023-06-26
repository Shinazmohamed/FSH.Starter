using FSH.Starter.Domain.Common.Events;

namespace FSH.Starter.Application.Catalog.Designations;
public class CreateDesignationsRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
}

public class CreateDesignationsRequestHandler : IRequestHandler<CreateDesignationsRequest, Guid>
{
    private readonly IRepository<Designation> _repository;

    public CreateDesignationsRequestHandler(IRepository<Designation> repository) =>
        _repository = repository;

    public async Task<Guid> Handle(CreateDesignationsRequest request, CancellationToken cancellationToken)
    {
        var designation = new Designation(request.Name);

        // Add Domain Events to be raised after the commit
        designation.DomainEvents.Add(EntityCreatedEvent.WithEntity(designation));

        await _repository.AddAsync(designation, cancellationToken);

        return designation.Id;
    }
}