using Microsoft.IdentityModel.Tokens;
using ProductManagement.Model;
using ProductManagement.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductManagement.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration configuration;

        public JwtService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            var key = configuration["Jwt:Key"];

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(key));

            var credentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),

                new Claim(ClaimTypes.Email, user.Email),

                new Claim(ClaimTypes.Role, user.Role),

                new Claim(ClaimTypes.NameIdentifier,
                    user.UserId.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(
                    Convert.ToDouble(configuration["Jwt:DurationInMinutes"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}
