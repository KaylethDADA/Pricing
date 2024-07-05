using MapsterMapper;
using Pricing.Application.Dtos.City;
using Pricing.Application.Interfaces;
using Pricing.Domain.Entities;

namespace Pricing.Application.Services
{
    public class CityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public async Task<CityResponse> Create(CityCreateRequests request) 
        {
            var city = _mapper.Map<City>(request);
            await _cityRepository.Create(city);
            return _mapper.Map<CityResponse>(city);
        }
        public CityResponse Update(CityUpdateRequests request)
        {
            var city= _cityRepository.GetById(request.Id);

            if (city == null)
                throw new Exception();

            city.Update(
                request.Name);

            _cityRepository.Update(city);
            return _mapper.Map<CityResponse>(city);
        }
        public CityResponse GetById(Guid id)
        {
            var city = _cityRepository.GetById(id);
            return _mapper.Map<CityResponse>(city);
        }
        public List<CityItemList> GetAll() 
        {
            var city= _cityRepository.GetAll();
            return _mapper.Map<List<CityItemList>>(city);
        }
        public void Delete(Guid id)
        {
            _cityRepository.Delete(id);
        }
    }
}
