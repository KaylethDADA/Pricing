using MapsterMapper;
using Pricing.Application.Dtos.Product;
using Pricing.Application.Interfaces;
using Pricing.Domain.Entities;

namespace Pricing.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productService, IMapper mapper)
        {
            _productRepository = productService;
            _mapper = mapper;
        }
        public async Task<ProductResponce> Create(ProductCreateRequests request)
        {
            var product = _mapper.Map<Product>(request);
            await _productRepository.Create(product);

            _productRepository.AddPriceProduct(new PriceProduct
            {
                ProductId = product.Id,
                DateCreated = DateTime.UtcNow,
                Price = request.Price,
            });

            return _mapper.Map<ProductResponce>(product);
        }
        public ProductResponce Update(ProductUpdateRequests request)
        {
            var product = _productRepository.GetById(request.Id);

            if (product == null)
                throw new Exception("Продукт не найден");

            product.Update(request.Price, request.Name);

            _productRepository.Update(product);
            return _mapper.Map<ProductResponce>(product);
        }
        public ProductResponce GetById(Guid id)
        {
            var product = _productRepository.GetById(id);
            return _mapper.Map<ProductResponce>(product);
        }
        public List<ProductItemList> GetAll()
        {
            var product = _productRepository.GetAll();
            return _mapper.Map<List<ProductItemList>>(product);
        }
        public void Delete(Guid id)
        {
            _productRepository.Delete(id);
        }
    }
}
