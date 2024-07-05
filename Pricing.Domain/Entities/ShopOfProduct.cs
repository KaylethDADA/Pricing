namespace Pricing.Domain.Entities
{
    public class ShopOfProduct
    {
        public Guid ShopId { get; set; }
        public Shop Shop { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
