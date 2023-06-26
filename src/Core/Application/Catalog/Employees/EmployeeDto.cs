namespace FSH.Starter.Application.Catalog.Employees;
public class EmployeeDto : IDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = default!;
    public DateTime JoinedDate { get; set; } = default!;
    public Guid DesignationId { get; set; } = default!;
    public string DesignationName { get; set; } = default!;
    public Guid CategoryId { get; set; } = default!;
    public string Category { get; set; } = default!;
    public Guid LocationId { get; set; } = default!;
    public string Location { get; set; } = default!;
}
