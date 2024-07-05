namespace Pricing.Application.Dtos.Product
{
    public sealed record ProductUpdateRequests
    (
        Guid Id,
        string Name,
        decimal Price
    );
}
