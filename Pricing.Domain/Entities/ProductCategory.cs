using Pricing.Domain.Primitives;

namespace Pricing.Domain.Entities
{
    public class ProductCategory : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public List<Product> Products { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public ProductCategory? ParentCategory { get; set; }
        public List<ProductCategory>? ChildCategories { get; set; }

        public ProductCategory Update(string? name)
        {
            if (!string.IsNullOrEmpty(name))
                Name = name;

            return this;
        }
    }
}
