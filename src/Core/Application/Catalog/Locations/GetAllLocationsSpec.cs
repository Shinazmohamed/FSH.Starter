namespace FSH.Starter.Application.Catalog.Locations;
internal class GetAllLocationsSpec : Specification<Location, LocationDetailsDto>, ISingleResultSpecification
{
    public GetAllLocationsSpec() =>
        Query.OrderBy(e => e.Name);
}
