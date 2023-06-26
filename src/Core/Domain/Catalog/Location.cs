namespace FSH.Starter.Domain.Catalog;
public class Location : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; } = default!;

    public Location()
    {

    }

    public Location(string name) => Name = name;

    public Location Update(string? name)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        return this;
    }
}
