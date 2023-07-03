namespace FSH.Starter.Application.Catalog.Designations;
public class GetAllDesignationsRequest : IRequest<List<DesignationDetailsDto>>
{
}

public class GetAllDesignationsRequestHandler : IRequestHandler<GetAllDesignationsRequest, List<DesignationDetailsDto>>
{
    private readonly IRepository<Designation> _repository;

    public GetAllDesignationsRequestHandler(IRepository<Designation> repository) => _repository = repository;

    public async Task<List<DesignationDetailsDto>> Handle(GetAllDesignationsRequest request, CancellationToken cancellationToken) =>
        await _repository.ListAsync(new GetAllDesignationsSpec(), cancellationToken);
}
