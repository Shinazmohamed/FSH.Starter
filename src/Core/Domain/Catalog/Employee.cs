namespace FSH.Starter.Domain.Catalog;
public class Employee : AuditableEntity, IAggregateRoot
{
    public string FullName { get; private set; } = default!;
    public DateTime JoinedDate { get; private set; } = default!;
    public Guid DesignationId { get; private set; } = default!;
    public virtual Designation Designation { get; private set; } = default!;
    public Guid CategoryId { get; private set; } = default!;
    public virtual Category Category { get; private set; } = default!;
    public Guid LocationId { get; private set; } = default!;
    public virtual Location Location { get; private set; } = default!;

    public Employee()
    {
        // Only needed for working with dapper (See GetProductViaDapperRequest)
        // If you're not using dapper it's better to remove this constructor.
    }

    public Employee(string fullName, DateTime joinedDate, Guid designationId, Guid categoryId, Guid locationId)
    {
        FullName = fullName;
        JoinedDate = joinedDate;
        DesignationId = designationId;
        CategoryId = categoryId;
        LocationId = locationId;
    }

    public Employee Update(string? fullName, DateTime? joinedDate, Guid? designationId, Guid? categoryId, Guid? locationId)
    {
        if (fullName is not null && FullName?.Equals(fullName) is not true) FullName = fullName;
        if (joinedDate is not null && joinedDate?.Equals(joinedDate) is not true) JoinedDate = (DateTime)joinedDate;
        if (designationId.HasValue && designationId.Value != Guid.Empty && !DesignationId.Equals(designationId.Value)) DesignationId = designationId.Value;
        if (categoryId.HasValue && categoryId.Value != Guid.Empty && !CategoryId.Equals(categoryId.Value)) CategoryId = categoryId.Value;
        if (locationId.HasValue && locationId.Value != Guid.Empty && !LocationId.Equals(locationId.Value)) LocationId = locationId.Value;
        return this;
    }
}
