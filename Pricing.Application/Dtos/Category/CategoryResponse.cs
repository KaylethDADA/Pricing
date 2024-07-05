namespace Pricing.Application.Dtos.Category
{
    public sealed record CategoryResponse
    (
         Guid Id,
         string Name,
         Guid? ParentCategory
    );
}
