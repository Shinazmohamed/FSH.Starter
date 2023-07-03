namespace FSH.Starter.Application.Catalog.Locations;
public class GetAllLocationsRequest : IRequest<List<LocationDetailsDto>>
{
}

public class GetAllLocationsRequestHandler : IRequestHandler<GetAllLocationsRequest, List<LocationDetailsDto>>
{
    private readonly IRepository<Location> _repository;

    public GetAllLocationsRequestHandler(IRepository<Location> repository) => _repository = repository;

    public async Task<List<LocationDetailsDto>> Handle(GetAllLocationsRequest request, CancellationToken cancellationToken) =>
        await _repository.ListAsync(new GetAllLocationsSpec(), cancellationToken);
}
