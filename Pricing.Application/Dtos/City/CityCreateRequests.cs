namespace Pricing.Application.Dtos.City
{
    public sealed record CityCreateRequests
    (
        string Name,
        Guid? ParentCity
    );
    
}
