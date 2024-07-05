using Mapster;
using Pricing.Application.Dtos.Shop;
using Pricing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Application.Mappings
{
    public class ShopMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ShopCreateRequests, Shop>()
                  .Map(dest => dest.CityId, src => src.CityId)
                  .Map(dest => dest.Name, src => src.Name)
                  .Map(dest => dest.DateCreated, src => DateTime.UtcNow);

            config.NewConfig<Shop, ShopResponce>()
                 .Map(dest => dest.Id, src => src.Id)
                 .Map(dest => dest.Name, src => src.Name)
                 .Map(dest => dest.Address, src => src.Address);

            config.NewConfig<Shop, ShopItemList>()
                 .Map(dest => dest.Id, src => src.Id)
                 .Map(dest => dest.Name, src => src.Name);

        }
    }
}
