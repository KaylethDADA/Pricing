using Mapster;
using Pricing.Application.Dtos.Category;
using Pricing.Domain.Entities;

namespace Pricing.Application.Mappings
{
    public class ProductCategoryMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CategoryCreateRequests, ProductCategory>()
                 .MapWith(dest =>
                 new ProductCategory 
                 {
                     Name = dest.Name,
                     ParentCategoryId = dest.ParentCategoryId,
                     DateCreated = DateTime.UtcNow
                 });

            config.NewConfig<ProductCategory, CategoryResponse>()
                 .MapWith(src => new CategoryResponse(src.Id, src.Name, src.ParentCategoryId));

            config.NewConfig<ProductCategory, CategoryItemList>()
                 .MapWith(src => new CategoryItemList(src.Id, src.Name));

            config.NewConfig<CategoryResponse, ProductCategory>()
                 .Map(dest => dest.Id, src => src.Id)
                 .Map(dest => dest.Name, src => src.Name);

        }
    }
}
    