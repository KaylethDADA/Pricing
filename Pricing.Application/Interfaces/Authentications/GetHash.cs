using System.Security.Cryptography;
using System.Text;

namespace Pricing.Application.Interfaces.Authentications
{
    public class GetHash
    {
        /// <summary>
        /// Метод для генерации хеша пароля
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static (string hash, string salt) GetHashPassword(string password)
        {
            var passwordKey = Guid.NewGuid().ToString("N");
            return (BitConverter.ToString(
                SHA256.Create().ComputeHash(
                    Encoding.UTF8.GetBytes(password + passwordKey))), passwordKey);
        }
        /// <summary>
        /// Метод для хеширования пароля с использованием заданным ключем
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string GetHashPassword(string password, string salt)
        {
            return BitConverter.ToString(
                SHA256.Create().ComputeHash(
                    Encoding.UTF8.GetBytes(password + salt)));
        }
    }
}
