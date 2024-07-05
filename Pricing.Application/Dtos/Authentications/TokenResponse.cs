using Pricing.Domain.ValueObjects;

namespace Pricing.Application.Dtos.Authentications
{
    public sealed record TokenResponse
    (
        Guid Id,
        FullName FullName,
        string Token
    );
}
