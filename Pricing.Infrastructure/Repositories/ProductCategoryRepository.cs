using Microsoft.EntityFrameworkCore;
using Pricing.Application.Interfaces;
using Pricing.Domain.Entities;
using Pricing.Infrastructure.Context;

namespace Pricing.Infrastructure.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductCategory> Create(ProductCategory category)
        {
            await _context.ProductCategories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public ProductCategory Update(ProductCategory category)
        {
            _context.ProductCategories.Update(category);
            _context.SaveChanges();
            return category;
        }

        public ICollection<ProductCategory> GetAll()
        {
            return _context.ProductCategories.ToList();
        }

        public ProductCategory GetById(Guid id)
        {
            return _context.ProductCategories.FirstOrDefault(x => x.Id == id)!;
        }

        public bool Delete(Guid id)
        {
            var result = new List<Guid>();
            GetSubcategoryIdsRecursive(_context, id, result);
            result.Add(id);

            if (result.Count > 0)
                _context.ProductCategories.Where(x => result.Contains(x.Id)).ExecuteDelete();

            return true;
        }

        private void GetSubcategoryIdsRecursive(ApplicationDbContext db, Guid id, List<Guid> result)
        {
            var subcategories = _context.ProductCategories
                .Where(c => c.ParentCategoryId == id)
                .Select(c => c.Id)
                .ToList();

            foreach (var subcategoryId in subcategories)
            {
                result.Add(subcategoryId);
                GetSubcategoryIdsRecursive(db, subcategoryId, result);
            }
        }
    }
}
