namespace FSH.Starter.Application.Catalog.Designations;
public class GetAllDesignationsSpec : Specification<Designation, DesignationDetailsDto>, ISingleResultSpecification
{
    public GetAllDesignationsSpec() =>
        Query.OrderBy(e => e.Name);
}
