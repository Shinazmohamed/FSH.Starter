namespace FSH.Starter.Application.Catalog.Categories;
public class GetAllCategoriesRequest : IRequest<List<CategoryDetailsDto>>
{
}

public class GetAllTenantsRequestHandler : IRequestHandler<GetAllCategoriesRequest, List<CategoryDetailsDto>>
{
    private readonly IRepository<Category> _repository;

    public GetAllTenantsRequestHandler(IRepository<Category> repository) => _repository = repository;

    public async Task<List<CategoryDetailsDto>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken) =>
        await _repository.ListAsync(new GetAllCategoriesSpec(), cancellationToken);
}