namespace Pricing.Application.Dtos.Product
{
    public sealed record ProductItemList
    (
        Guid Id,
        string Name,
        decimal Price
    );
}
