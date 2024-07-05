using MapsterMapper;
using Pricing.Application.Dtos.Category;
using Pricing.Application.Interfaces;
using Pricing.Domain.Entities;

namespace Pricing.Application.Services
{
    public class ProductCategoryService
    {
        private readonly IProductCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductCategoryService(IProductCategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryResponse> Create(CategoryCreateRequests request) 
        {
            var category = _mapper.Map<ProductCategory>(request);
            await _categoryRepository.Create(category);
            return _mapper.Map<CategoryResponse>(category);
        }
        public CategoryResponse Update(CategoryUpdateRequests request)
        {
            var category= _categoryRepository.GetById(request.Id);

            if (category == null)
                throw new Exception();

            category.Update(
                request.Name);

            _categoryRepository.Update(category);
            return _mapper.Map<CategoryResponse>(category);
        }
        public CategoryResponse GetById(Guid id)
        {
            var category = _categoryRepository.GetById(id);
            return _mapper.Map<CategoryResponse>(category);
        }
        public List<CategoryItemList> GetAll() 
        {
            var category = _categoryRepository.GetAll();
            return _mapper.Map<List<CategoryItemList>>(category);
        }
        public void Delete(Guid id)
        {
            _categoryRepository.Delete(id);
        }
    }
}
