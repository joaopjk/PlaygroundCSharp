using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Domain.Entities;
using BuberDinner.Util;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BuberDinner.Infrastructure.Authentication
{
#pragma warning disable CS8604 // Possível argumento de referência nula.
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public string GenerateToken(User User)
        {

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable(nameof(Constants.SECRET)))),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, User.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, User.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, User.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var securityToken = new JwtSecurityToken(
                issuer: Environment.GetEnvironmentVariable(nameof(Constants.ISSUER)),
                audience: Environment.GetEnvironmentVariable(nameof(Constants.AUDIENCE)),
                expires: _dateTimeProvider.UtcNow.AddMinutes(
                        Convert.ToInt32(Environment.GetEnvironmentVariable(nameof(Constants.EXPIRETIME)))
                    ),
                claims: claims,
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
#pragma warning restore CS8604 // Possível argumento de referência nula.
}
