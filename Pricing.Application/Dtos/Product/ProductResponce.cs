namespace Pricing.Application.Dtos.Product
{
    public sealed record ProductResponce
    (
        Guid Id,
        string Name,
        decimal Price
    );
}
