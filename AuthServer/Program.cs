using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AuthServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                var user = new ApplicationUser
                {
                    Email = "testuser@gmail.com",
                    UserName = "testuser@gmail.com"
                };

                userManager.CreateAsync(user, "password123").GetAwaiter().GetResult();

                var adminRole = new ApplicationRole("Admin");
                var regularRole = new ApplicationRole("Regular");
                roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
                roleManager.CreateAsync(regularRole).GetAwaiter().GetResult();

                userManager.AddToRoleAsync(user, "Admin");

            }


            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("https://localhost:5000");
                });
    }
}