using Mapster;
using Pricing.Application.Dtos.Product;
using Pricing.Domain.Entities;

namespace Pricing.Application.Mappings
{
    public class ProductMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ProductCreateRequests, Product>()
                .Map(dest => dest.CategorId, src => src.CategoryId)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.DateCreated, src => DateTime.UtcNow);

            config.NewConfig<Product, ProductResponce>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Price, src => src.Prices != null && src.Prices.Count > 0 ? src.Prices.First().Price : 0);

            config.NewConfig<Product, ProductItemList>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Price, src => src.Prices != null && src.Prices.Any()
                ? src.Prices.OrderByDescending(p => p.DateCreated).FirstOrDefault().Price
                : 0);
        }
    }
}
