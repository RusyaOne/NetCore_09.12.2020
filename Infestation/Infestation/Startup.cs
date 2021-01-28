using Infestation.Configurations;
using Infestation.Models;
using Infestation.Models.Repositories;
using Infestation.Models.Repositories.Interfaces;
using Infestation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Infestation
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(configure => 
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                configure.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddScoped<IHumanRepository, HumanRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<INewsRepository, MockNewsRepository>();
            services.AddScoped<IMessageSender, SmsMessageSender>();

            services.AddSingleton<IRestApiExampleClient, RestApiExampleClient>();
            services.AddSingleton<ImageProcessingChannel>();            

            services.AddMemoryCache();

            services.AddHostedService<LoadFileHostedService>();
            services.AddHostedService<UploadFileHostedService>();

            services.AddDbContext<InfestationDbContext>();
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<InfestationDbContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            services.Configure<InfestationConfiguration>(_configuration.GetSection("Infestation"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseWriteToConsole("Custom parameter.");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}