namespace Pricing.Domain.Entities
{
    public class AveragePrice
    {
        public Guid CityId { get; set; }
        public City City { get; set; }
        public decimal Price { get; set; }
        public DateTime DataCreate { get; set; }
    }
}
