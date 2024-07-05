using Pricing.Domain.ValueObjects;

namespace Pricing.Application.Dtos.Authentications
{
    public sealed record RegisterRequest
    (
        FullName FullName,
        string Email,
        string Password
    );
}
