using Pricing.Application.Dtos.Product;
using Pricing.Domain.Entities;

namespace Pricing.Application.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task SaveChangesAsync();
        PriceProduct AddPriceProduct(PriceProduct price);
        ProductListResponse GetPogiProduct(ProductListRequest request);
        Task DistributeProductToShopAsync(Guid productId, Guid shopId);
    }
}
