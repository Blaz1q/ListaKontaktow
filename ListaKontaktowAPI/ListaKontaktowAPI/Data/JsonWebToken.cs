using ListaKontaktowAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ListaKontaktowAPI.Data
{
    public class JsonWebToken
    {
        private readonly IConfiguration _config;

        public JsonWebToken(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateJwtToken(Kontakt user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("Imie", user.Imie ?? ""),
                new Claim("Nazwisko", user.Nazwisko ?? ""),
                new Claim("KategoriaId", user.KategoriaId.ToString()),
                new Claim("Telefon",user.Telefon)
                // Możesz dodać role lub inne dane
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
