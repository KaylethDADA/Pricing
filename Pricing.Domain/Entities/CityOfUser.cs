namespace Pricing.Domain.Entities
{
    public class CityOfUser
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
    }
}
