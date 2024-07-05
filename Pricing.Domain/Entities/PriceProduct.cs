namespace Pricing.Domain.Entities
{
    public class PriceProduct
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Price { get; set; }
    }
}
