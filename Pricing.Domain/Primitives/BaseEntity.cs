namespace Pricing.Domain.Primitives
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated {  get; set; } = DateTime.UtcNow;
    }
}
