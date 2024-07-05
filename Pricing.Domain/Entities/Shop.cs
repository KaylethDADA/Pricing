using Pricing.Domain.Primitives;

namespace Pricing.Domain.Entities
{
    public class Shop : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<ShopOfProduct> Products { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }

        public Shop Update(string? name, string address)
        {
            if (!string.IsNullOrEmpty(name))
                Name = name;
            if (!string.IsNullOrEmpty(address))
                Address = address;

            return this;
        }
    }
}
