namespace FSH.Starter.Application.Catalog.Employees;
public class EmployeeByIdWithDesignationLocationCategorySpec : Specification<Employee, EmployeeDetailsDto>, ISingleResultSpecification
{
    public EmployeeByIdWithDesignationLocationCategorySpec(Guid id) =>
    Query
        .Where(p => p.Id == id)
        .Include(p => p.Designation)
        .Include(p => p.Location)
        .Include(p => p.Category);
}
