using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pricing.Application.Dtos.Authentications;
using Pricing.Application.Interfaces.Authentications;
using Pricing.Domain.Entities;
using Pricing.Infrastructure.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace Pricing.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext db;

        public AuthRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var user = await db.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (user is null)
                throw new Exception("Неверные данные");


            var tokenResult = GenerateToken(user.Id);

            return new LoginResponse(
                Token: tokenResult.Token,
                Id: user.Id,
                FullName: user.FullName);
        }

        public async Task Registration(RegisterRequest request)
        {
            if (await db.Users.AnyAsync(x => x.Email == request.Email.Trim()))
                throw new Exception("Данная почта уже используется!");

            var guidEmail = Guid.NewGuid();
            var (hashedPassword, salt) = GetHash.GetHashPassword(request.Password);

            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = hashedPassword,
                PasswordSalt = salt,
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
        }

        private TokenResponse GenerateToken(Guid Id)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == Id);

            if (user is null)
                throw new Exception("Пользователь не найден!");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = AuthOptions.GetSymmetricSecurityKey();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new(ClaimTypes.Name, user.FullName.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(AuthOptions.LIFETIME),
                Audience = AuthOptions.AUDIENCE,
                Issuer = AuthOptions.ISSUER,
                SigningCredentials = new(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenResponse(
                Id: user.Id,
                FullName: user.FullName,
                Token: $"Bearer {tokenHandler.WriteToken(token)}");
        }
    }
}
