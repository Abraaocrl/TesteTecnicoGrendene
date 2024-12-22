using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TesteTecnicoGrendene.Domain.Usuarios;

namespace TesteTecnicoGrendene.Helpers
{
    public static class AuthHelper
    {
        public static string GenerateJWTToken(Usuario user)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Nome)
            };

            var jwtToken = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(double.Parse(configuration["Authentication:JWT_Duration"])),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes(configuration["Authentication:JWT_Secret"])
                        ),
                    SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
