using System.Text;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Persistance;
using SmartSaver_API.Services;

namespace SmartSaver_API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.SignIn.RequireConfirmedEmail = false;
            })
            .AddEntityFrameworkStores<DataContext>()
            .AddSignInManager<SignInManager<AppUser>>()
            .AddDefaultTokenProviders();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MIIBOgIBAAJBAK18mpAuuCjW9xKrzb8lpGAEqGxbhgqG/ruXHA62xpEtY0uQG+ep\r\npPubU1BJ0xyuJcSuybL2nz3RAgIV8/Faux8CAwEAAQJBAJLQYOjlcJm3GU3msG4z\r\nh8BuEK3qYivkhAvyXB8jlDTkQeHRGpoPnf56NAQ6MrJa5Rn+uf4cP6LWzOYgeJW+\r\nT9kCIQDtm6TucMXPHbr2/3hKxbTsePvZGgcIsIUEMpSoqDl7LQIhALrqWv/YW33z\r\n4kdNZatq7gTei0RAVolldvBG92DU3I77AiBGhjgB/b74pp5jyZfuuZflyFMYMT19\r\nOseAY3L0TFojUQIgCEPotjuJAC7SqLiBcG0QDWMR4Xi+2uCDu+hHdB61ihUCIFol\r\np5XgaVCoMaj9cME9e8fEaz3BraoXdNrBVauaffsD"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false
                };
            });
            services.AddScoped<TokenService>();

            return services;
        }
    }
}