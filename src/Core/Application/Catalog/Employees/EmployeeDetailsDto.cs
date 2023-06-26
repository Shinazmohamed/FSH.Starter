namespace FSH.Starter.Application.Catalog.Employees;
public class EmployeeDetailsDto
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; } = default!;
    public DateTime JoinedDate { get; private set; } = default!;
    public virtual Designation Designation { get; private set; } = default!;
    public virtual Category Category { get; private set; } = default!;
    public virtual Location Location { get; private set; } = default!;
}
