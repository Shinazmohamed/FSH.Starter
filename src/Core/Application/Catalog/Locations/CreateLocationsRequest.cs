using FSH.Starter.Domain.Common.Events;

namespace FSH.Starter.Application.Catalog.Locations;
public class CreateLocationsRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
}

public class CreateLocationsRequestHandler : IRequestHandler<CreateLocationsRequest, Guid>
{
    private readonly IRepository<Location> _repository;

    public CreateLocationsRequestHandler(IRepository<Location> repository) =>
        _repository = repository;

    public async Task<Guid> Handle(CreateLocationsRequest request, CancellationToken cancellationToken)
    {
        var location = new Location(request.Name);

        // Add Domain Events to be raised after the commit
        location.DomainEvents.Add(EntityCreatedEvent.WithEntity(location));

        await _repository.AddAsync(location, cancellationToken);

        return location.Id;
    }
}
