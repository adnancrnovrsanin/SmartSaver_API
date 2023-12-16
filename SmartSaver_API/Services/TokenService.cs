using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Domain;
using Microsoft.IdentityModel.Tokens;

namespace SmartSaver_API.Services
{
    public class TokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MIIBOgIBAAJBAK18mpAuuCjW9xKrzb8lpGAEqGxbhgqG/ruXHA62xpEtY0uQG+ep\r\npPubU1BJ0xyuJcSuybL2nz3RAgIV8/Faux8CAwEAAQJBAJLQYOjlcJm3GU3msG4z\r\nh8BuEK3qYivkhAvyXB8jlDTkQeHRGpoPnf56NAQ6MrJa5Rn+uf4cP6LWzOYgeJW+\r\nT9kCIQDtm6TucMXPHbr2/3hKxbTsePvZGgcIsIUEMpSoqDl7LQIhALrqWv/YW33z\r\n4kdNZatq7gTei0RAVolldvBG92DU3I77AiBGhjgB/b74pp5jyZfuuZflyFMYMT19\r\nOseAY3L0TFojUQIgCEPotjuJAC7SqLiBcG0QDWMR4Xi+2uCDu+hHdB61ihUCIFol\r\np5XgaVCoMaj9cME9e8fEaz3BraoXdNrBVauaffsD"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}