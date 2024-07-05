using Pricing.Application.Interfaces;
using Pricing.Domain.Entities;
using Pricing.Infrastructure.Context;

namespace Pricing.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User x)
        {
            await _context.Users.AddAsync(x);
            await _context.SaveChangesAsync();

            return x;
        }
        public User Update(User x)
        {
            _context.Users.Update(x);
            _context.SaveChanges();

            return x;
        }

        public ICollection<User> GetAll()
        {
            var userList = _context.Users.ToList();
            return userList;
        }

        public User GetById(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id)!;
        }

        public bool Delete(Guid id)
        {
            var user = GetById(id);

            if (user != null)
                throw new Exception();

            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }
    }
}
