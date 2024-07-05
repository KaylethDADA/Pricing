namespace Pricing.Application.Dtos.Product
{
    public sealed record ProductCreateRequests
    (
        string Name,
        decimal Price,
        Guid CategoryId
    );
}
