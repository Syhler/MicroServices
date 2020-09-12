using Auth.Infrastructure.ClientConfig;
using Auth.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddAuthInfrastructure(this IServiceCollection services, IConfiguration configuration )
        {
            
            services.AddDbContext<ApplicationDbContext>(builder =>
            {
                builder.UseMySql(configuration.GetConnectionString("Default"));
            });

            services.AddIdentity<ApplicationUser, ApplicationRole>(config =>
                {
                    config.Password.RequiredLength = 4;
                    config.Password.RequireDigit = true;
                    config.Password.RequireUppercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddIdentityServer()
                .AddAspNetIdentity<ApplicationUser>()
                .AddInMemoryApiScopes(Config.GetApiScopes())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddDeveloperSigningCredential();

        }
    }
}