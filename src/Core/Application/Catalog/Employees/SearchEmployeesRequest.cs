namespace FSH.Starter.Application.Catalog.Employees;
public class SearchEmployeesRequest : PaginationFilter, IRequest<PaginationResponse<EmployeeDto>>
{
    public Guid? DesignationId { get; set; } = default!;
    public Guid? CategoryId { get; set; } = default!;
    public Guid? LocationId { get; set; } = default!;
}

public class SearchEmployeesRequestHandler : IRequestHandler<SearchEmployeesRequest, PaginationResponse<EmployeeDto>>
{
    private readonly IReadRepository<Employee> _repository;

    public SearchEmployeesRequestHandler(IReadRepository<Employee> repository) => _repository = repository;

    public async Task<PaginationResponse<EmployeeDto>> Handle(SearchEmployeesRequest request, CancellationToken cancellationToken)
    {
        var spec = new EmployeesBySearchRequestWithDesignationLocationCategorySpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}
