namespace FSH.Starter.Application.Catalog.Employees;
public class GetEmployeeRequest : IRequest<EmployeeDetailsDto>
{
    public Guid Id { get; set; }

    public GetEmployeeRequest(Guid id) => Id = id;
}

public class GetEmployeeRequestHandler : IRequestHandler<GetEmployeeRequest, EmployeeDetailsDto>
{
    private readonly IRepository<Employee> _repository;
    private readonly IStringLocalizer _t;

    public GetEmployeeRequestHandler(IRepository<Employee> repository, IStringLocalizer<GetEmployeeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<EmployeeDetailsDto> Handle(GetEmployeeRequest request, CancellationToken cancellationToken) =>
        await _repository.FirstOrDefaultAsync(
            (ISpecification<Employee, EmployeeDetailsDto>)new EmployeeByIdWithDesignationLocationCategorySpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Employee {0} Not Found.", request.Id]);
}
