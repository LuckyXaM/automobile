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

namespace AutoRepository
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
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

            services.AddMvcCore()
                .AddApiExplorer()
                .AddJsonFormatters();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("automobile", new Info { Title = "Работа с автомобилями", Version = "automobile" });
                c.IgnoreObsoleteProperties();

                var xmlPath = Path.Combine("AutoRepository.xml");
                c.IncludeXmlComments(xmlPath);

                // Отображение перечисляемого типа в текстовом виде
                c.DescribeAllEnumsAsStrings();
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
