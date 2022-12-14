using System.Buffers;
using System.Text;
using Core.Entities.Identity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
         public static IServiceCollection AddIdentityServices( this IServiceCollection services, 
         IConfiguration config)
         {
            var builder = services.AddIdentityCore<AppUser>();

            builder = new IdentityBuilder(builder.UserType, builder.Services);

            builder.AddEntityFrameworkStores<AppIdentityDbContext>();

            builder.AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(Options =>
            {
                   // Options.SaveToken = true;
                    //Options.RequireHttpsMetadata = false;
                Options.TokenValidationParameters = new TokenValidationParameters
                {
                    
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidIssuer = config["Token:Issuer"],
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config
                    //["Token:Key"])),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"]))
                    
                    
                };
            });

            return services;

         }
    }
}