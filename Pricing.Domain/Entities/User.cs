using Pricing.Domain.Primitives;
using Pricing.Domain.ValueObjects;

namespace Pricing.Domain.Entities
{
    public class User : BaseEntity
    {
        public FullName FullName { get; set; }
        public string Email { get; set; }
        public List<CityOfUser> Citys { get; set; }
        public string? PasswordHash { get; set; }
        public string? PasswordSalt { get; set; }

        public User Update(string? firstName, string? lastName, string? middleName, string? userName)
        {
            FullName.Update(firstName, lastName, middleName);

            return this;
        }
    }
}
