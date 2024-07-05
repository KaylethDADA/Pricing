using Pricing.Application.Paginations;

namespace Pricing.Application.Dtos.Product
{
    public class ProductListResponse : IPaginationResponse<ProductItemList>
    {
        public List<ProductItemList> Items { get; set; }
        public PageResponse? Page { get; set; }
    }
}
