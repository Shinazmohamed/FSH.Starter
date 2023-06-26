using FSH.Starter.Domain.Common.Events;

namespace FSH.Starter.Application.Catalog.Categories;
public class CreateCategoryRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
}

public class CreateCategoryRequestHandler : IRequestHandler<CreateCategoryRequest, Guid>
{
    private readonly IRepository<Category> _repository;

    public CreateCategoryRequestHandler(IRepository<Category> repository) =>
        _repository = repository;

    public async Task<Guid> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = new Category(request.Name);

        // Add Domain Events to be raised after the commit
        category.DomainEvents.Add(EntityCreatedEvent.WithEntity(category));

        await _repository.AddAsync(category, cancellationToken);

        return category.Id;
    }
}