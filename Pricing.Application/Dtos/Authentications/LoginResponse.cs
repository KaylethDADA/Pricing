using Pricing.Domain.ValueObjects;

namespace Pricing.Application.Dtos.Authentications
{
    public sealed record LoginResponse
    (
       Guid Id,
       string Token,
       FullName FullName
    );
}
