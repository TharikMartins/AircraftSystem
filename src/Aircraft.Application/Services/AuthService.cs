using Aircraft.Application.Interfaces;
using Aircraft.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aircraft.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly string JWT_TOKEN;
        public AuthService(IConfiguration configuration)
        {
            JWT_TOKEN = configuration["Jwt:Key"];
        }

        public string GenerateToken(UserProfile user)
        {
            var claims = new[]
          {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Login),
                new Claim("Password", user.Password)
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWT_TOKEN));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            var securityToken = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims,
                expires: expiration,
                signingCredentials: signIn);

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }
    }
}
