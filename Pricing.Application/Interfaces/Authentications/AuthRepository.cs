using Pricing.Application.Dtos.Authentications;

namespace Pricing.Application.Interfaces.Authentications
{
    public interface IAuthRepository
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task Registration(RegisterRequest request);
    }
}
