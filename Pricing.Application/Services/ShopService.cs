using MapsterMapper;
using Pricing.Application.Dtos.Shop;
using Pricing.Application.Interfaces;
using Pricing.Domain.Entities;

namespace Pricing.Application.Services
{
    public class ShopService
    {
        private readonly IShopRepository _shopRepository;
        private readonly IMapper _mapper;

        public ShopService(IShopRepository shopRepository, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
        }

        public async Task<ShopResponce> Create(ShopCreateRequests request)
        {
            var shop = _mapper.Map<Shop>(request);
            await _shopRepository.Create(shop);
            return _mapper.Map<ShopResponce>(shop);
        }
        public ShopResponce Update(ShopUpdateRequests request)
        {
            var shop = _shopRepository.GetById(request.Id);

            if (shop == null)
                throw new Exception();

            shop.Update(
                request.Name,
                request.Address);

            _shopRepository.Update(shop);
            return _mapper.Map<ShopResponce>(shop);
        }
        public ShopResponce GetById(Guid id)
        {
            var shop = _shopRepository.GetById(id);
            return _mapper.Map<ShopResponce>(shop);
        }
        public List<ShopItemList> GetAll()
        {
            var shop = _shopRepository.GetAll();
            return _mapper.Map<List<ShopItemList>>(shop);
        }
        public void Delete(Guid id)
        {
            _shopRepository.Delete(id);
        }
    }
}
