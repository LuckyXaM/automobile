using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AutoRepository.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AutoRepository.Data.Repositories.Interfaces;
using AutoRepository.Data.Repositories.Logic;
using AutoRepository.Services.Services.Interfaces;
using AutoRepository.Services.Services.Logic;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using AutoRepository.Data.Storages.Logic;
using AutoRepository.Data.Storages.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace AutoRepository
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private IHostingEnvironment _env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = Configuration.GetValue<string>("RedisConnectionString");
                option.InstanceName = "auto";
            });

            var dbConnectionString = Configuration["DbConnectionString"] ?? Configuration.GetConnectionString("DefaultConnection");
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<AutoRepositoryContext>(options =>
                {
                    options.UseNpgsql(dbConnectionString,
                        sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                            sqlOptions.EnableRetryOnFailure(
                                maxRetryCount: 5,
                                maxRetryDelay: TimeSpan.FromSeconds(30),
                                errorCodesToAdd: null);
                        });
                }, ServiceLifetime.Scoped);
            
            services.AddScoped<IAutomobileRepository, AutomobileRepository>();
            services.AddScoped<IAutomobileHandler, AutomobileHandler>();
            services.AddScoped<IAutomobileStorage, AutomobileStorage>();

            services.AddMvcCore()
                .AddApiExplorer()
                .AddJsonFormatters();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("automobile", new Info { Title = "Работа с автомобилями", Version = "automobile" });

                var xmlPath = Path.Combine(_env.ContentRootPath, "AutoRepository.xml");
                c.IncludeXmlComments(xmlPath);
                c.IgnoreObsoleteProperties();
            });

            return services.BuildServiceProvider();
        }
        
        public void Configure(IApplicationBuilder app)
        {
            var dbContext = app.ApplicationServices.GetService<AutoRepositoryContext>();
            dbContext.Database.Migrate();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.ShowJsonEditor();
                c.RoutePrefix = "api-docs";
                c.SwaggerEndpoint("/swagger/automobile/swagger.json", "automobile");
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
