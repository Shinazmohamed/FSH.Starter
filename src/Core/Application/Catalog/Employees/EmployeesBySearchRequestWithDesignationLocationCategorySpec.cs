namespace FSH.Starter.Application.Catalog.Employees;
public class EmployeesBySearchRequestWithDesignationLocationCategorySpec : EntitiesByPaginationFilterSpec<Employee, EmployeeDto>
{
    public EmployeesBySearchRequestWithDesignationLocationCategorySpec(SearchEmployeesRequest request)
        : base(request) =>
        Query
            .Include(p => p.Designation)
            .Include(p => p.Category)
            .Include(p => p.Location)
            .OrderBy(c => c.FullName, !request.HasOrderBy())
            .Where(p => p.DesignationId.Equals(request.DesignationId!.HasValue), request.DesignationId.HasValue)
            .Where(p => p.CategoryId.Equals(request.CategoryId!.HasValue), request.CategoryId.HasValue)
            .Where(p => p.LocationId.Equals(request.LocationId!.HasValue), request.LocationId.HasValue);
}
