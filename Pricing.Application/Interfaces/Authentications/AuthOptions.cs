using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Pricing.Application.Interfaces.Authentications
{
    public class AuthOptions
    {
        public const string ISSUER = "XLEB"; // издатель токена

        public const string AUDIENCE = "MPID"; 

        private const string KEY = "mysupersecret_secretkey!Doteka228"; // ключ для шифрации

        public const int LIFETIME = 10000; // время жизни токена - 1 минута

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
