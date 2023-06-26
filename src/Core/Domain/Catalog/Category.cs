namespace FSH.Starter.Domain.Catalog;
public class Category : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; } = default!;

    public Category()
    {

    }

    public Category(string name) => Name = name;

    public Category Update(string? name)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        return this;
    }
}