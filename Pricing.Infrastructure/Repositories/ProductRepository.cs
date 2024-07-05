using Microsoft.EntityFrameworkCore;
using Pricing.Application.Dtos.Product;
using Pricing.Application.Interfaces;
using Pricing.Application.Paginations;
using Pricing.Domain.Entities;
using Pricing.Infrastructure.Context;

namespace Pricing.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product x)
        {
            await _context.Products.AddAsync(x);
            await _context.SaveChangesAsync();
            return x;
        }

        public Product Update(Product x)
        {
            _context.Products.Update(x);
            _context.SaveChanges();
            return x;
        }

        public ICollection<Product> GetAll()
        {
            var productList = _context.Products
                             .Include(p => p.Prices)
                             .ToList();
            return productList;
        }

        public Product GetById(Guid id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id)!;
        }

        public bool Delete(Guid id)
        {
            var product = GetById(id);

            if (product == null)
                throw new Exception();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public PriceProduct AddPriceProduct(PriceProduct price)
        {
            _context.PriceProducts.Add(price);
            _context.SaveChanges();
            return price;
        }
        public ProductListResponse GetPogiProduct(ProductListRequest request)
        {
            var quest = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(request.Search))
                quest = quest.Where(p => p.Name == request.Search);

            var productList = quest.GetPaginationResponse<Product, ProductListResponse, ProductItemList>(request, x =>
                new ProductItemList(
                    Id: x.Id, Name: x.Name, Price: x.Prices.Where(p => p.ProductId == x.Id).Select(p => p.Price).FirstOrDefault()));
            return productList;
            
        }
        public async Task DistributeProductToShopAsync(Guid productId, Guid shopId)
        {
            var product = await _context.Products.FindAsync(productId);
            var shop = await _context.Shops.FindAsync(shopId);

            if (product == null || shop == null)
            {
                throw new Exception("Product or Shop not found");
            }

            var shopofproduct = new ShopOfProduct
            {
                ProductId = productId,
                ShopId = shopId
            };

            _context.ShopOfProducts.Add(shopofproduct);
            await _context.SaveChangesAsync();
        }
    }
}
