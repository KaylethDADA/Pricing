namespace Pricing.Application.Paginations
{
    public class PageResponse
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int TotalItems { get; set; }
    }
}