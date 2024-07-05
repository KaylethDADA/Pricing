using Microsoft.EntityFrameworkCore;
using Pricing.Application.Interfaces;
using Pricing.Domain.Entities;
using Pricing.Infrastructure.Context;

namespace Pricing.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _context;

        public CityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<City> Create(City x)
        {
            await _context.Cities.AddAsync(x);
            await _context.SaveChangesAsync();
            return x;
        }
        public City Update(City x)
        {
            _context.Cities.Update(x);
            _context.SaveChanges();
            return x;
        }

        public ICollection<City> GetAll()
        {
            var cityList = _context.Cities.ToList();
            return cityList;
        }

        public City GetById(Guid id)
        {
            return _context.Cities.FirstOrDefault(x => x.Id == id)!;
        }

        public bool Delete(Guid id)
        {
            var result = new List<Guid>();
            GetSubcategoryIdsRecursive(_context, id, result);
            result.Add(id);

            if (result.Count > 0)
                _context.Cities.Where(x => result.Contains(x.Id)).ExecuteDelete();

            return true;
        }

        private void GetSubcategoryIdsRecursive(ApplicationDbContext db, Guid id, List<Guid> result)
        {
            var subcategories = _context.Cities
                .Where(c => c.ParentCityId == id)
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
