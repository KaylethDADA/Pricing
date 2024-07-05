namespace Pricing.Application.Dtos.Category
{
    public  sealed record CategoryCreateRequests
    (
        string Name,
        Guid? ParentCategoryId
    );
    
}
