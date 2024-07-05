using Pricing.Domain.Primitives;

namespace Pricing.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public List<PriceProduct> Prices { get; set; }
        public List<ShopOfProduct> Shops {  get; set; } 
        public Guid CategorId { get; set; }
        public ProductCategory Category { get; set; }

        public Product Update(decimal price, string name) 
        {
            Name = name;

            Prices = new List<PriceProduct> {
                new PriceProduct {
                    Price = price,
                    DateCreated = DateTime.UtcNow,
                    ProductId = Id
                }
            };

            return this;
        }
    }
}
