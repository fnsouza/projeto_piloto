using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entity;
using Microsoft.IdentityModel.Tokens;

namespace Core.Services
{
    public class JwtAppService
    {
        private const string key = "Chave_de_seguranca_teste";

        public string GenerateToken(UserEntity user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim("UserId", user.Id.ToString()),
                new Claim("Username", user.Username)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(key));

            var expirationDate = DateTime.Now.AddDays(1);

            var signingCredentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha512);

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateJwtSecurityToken(
                "Issuer",
                "Audience",
                new ClaimsIdentity(claims),
                DateTime.Now,
                expirationDate,
                DateTime.Now,
                signingCredentials
            );

            return handler.WriteToken(token);
        }

        public TokenValidationParameters GetValidationParameters()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(key));

            return new TokenValidationParameters
            {
                ValidIssuer = "Issuer",
                ValidAudience = "Audience",
                IssuerSigningKey = securityKey,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true
            };
        }
    }
}
