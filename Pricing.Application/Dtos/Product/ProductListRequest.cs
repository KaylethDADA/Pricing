using Pricing.Application.Paginations;

namespace Pricing.Application.Dtos.Product
{
    public class ProductListRequest : IPaginationRequest
    {
        public string? Search {  get; set; }
        public PageRequest? Page { get; set; }
    }
}
