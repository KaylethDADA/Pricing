using Mapster;
using Pricing.Application.Dtos.User;
using Pricing.Domain.Entities;
using Pricing.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Application.Mappings
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserCreateRequests, User>()
                .Map(dest => dest.FullName.FirstName, opt => opt.FullName.FirstName)
                .Map(dest => dest.FullName.LastName, opt => opt.FullName.LastName)
                .Map(dest => dest.FullName.MiddleName, opt => opt.FullName.MiddleName)
                .Map(dest => dest.Email, src => src.Email);

            config.NewConfig<User, UserResponse>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.FullName.FirstName, src => src.FullName.FirstName)
                .Map(dest => dest.FullName.LastName, src => src.FullName.LastName)
                .Map(dest => dest.FullName.MiddleName, src => src.FullName.MiddleName)
                .Map(dest => dest.Email, src => src.Email);

            config.NewConfig<User, UserCreateRequests>()
                .Map(dest => dest.FullName.FirstName, src => src.FullName.FirstName)
                .Map(dest => dest.FullName.LastName, src => src.FullName.LastName)
                .Map(dest => dest.FullName.MiddleName, src => src.FullName.MiddleName)
                .Map(dest => dest.Email, src => src.Email);

            config.NewConfig<User, UserItemList>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.FullName, src => src.FullName);
        }
    }
}
