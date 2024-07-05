using Mapster;
using Pricing.Application.Dtos.City;
using Pricing.Domain.Entities;

namespace Pricing.Application.Mappings
{
    public class CityMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config) 
        {
            config.NewConfig<CityCreateRequests, City>()
                .MapWith(dest => new City { Name = dest.Name, ParentCityId = dest.ParentCity });

            config.NewConfig<City, CityResponse>()
                 .Map(dest => dest.Id, src => src.Id)
                 .Map(dest => dest.Name, src => src.Name);

            config.NewConfig<City, CityItemList>()
                 .Map(dest => dest.Id, src => src.Id)
                 .Map(dest => dest.Name, src => src.Name);

        }
    }
}
