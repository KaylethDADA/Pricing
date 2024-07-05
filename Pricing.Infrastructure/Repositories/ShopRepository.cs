using Pricing.Application.Interfaces;
using Pricing.Domain.Entities;
using Pricing.Infrastructure.Context;

namespace Pricing.Infrastructure.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly ApplicationDbContext _context;

        public ShopRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Shop> Create(Shop x)
        {
            await _context.Shops.AddAsync(x);
            await _context.SaveChangesAsync();
            return x;
        }
        public Shop Update(Shop x)
        {
            _context.Shops.Update(x);
            _context.SaveChanges();
            return x;
        }

        public ICollection<Shop> GetAll()
        {
            var shopList = _context.Shops.ToList();
            return shopList;
        }

        public Shop GetById(Guid id)
        {
            return _context.Shops.FirstOrDefault(x => x.Id == id)!;
        }

        public bool Delete(Guid id)
        {
            var shop = GetById(id);

            if (shop == null)
                throw new Exception();

            _context.Shops.Remove(shop);
            _context.SaveChanges();
            return true;
        }
    }
}
