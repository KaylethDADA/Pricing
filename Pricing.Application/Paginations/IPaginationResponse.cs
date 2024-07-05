namespace Pricing.Application.Paginations
{
    public interface IPaginationResponse<TType>
    {
        public List<TType> Items { get; set; }
        public PageResponse? Page { get; set; }
    }
}
