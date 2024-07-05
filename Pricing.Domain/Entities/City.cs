using Pricing.Domain.Primitives;

namespace Pricing.Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public List<AveragePrice> AveragePrices { get; set; }
        public List<Shop> Shop { get; set; }
        public List<CityOfUser> Users { get; set; }
        public List<City> Region { get; set; }
        public Guid? ParentCityId {  get; set; }
        public City ParentCity { get; set; }

        public City Update(string? name)
        {
            if (!string.IsNullOrEmpty(name))
                Name = name;

            return this;
        }
    }
}
