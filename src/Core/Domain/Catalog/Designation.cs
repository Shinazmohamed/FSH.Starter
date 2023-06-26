namespace FSH.Starter.Domain.Catalog;
public class Designation : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; } = default!;

    public Designation()
    {

    }

    public Designation(string name) => Name = name;

    public Designation Update(string? name)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        return this;
    }
}
