namespace Pricing.Application.Dtos.Authentications
{
    public sealed record LoginRequest
      (
        string Email,
        string Password
      );
}
