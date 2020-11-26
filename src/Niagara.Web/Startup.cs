using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Niagara.Data.Common.RepositoryInterfaces;
using Niagara.Data.InMemory.InMemoryStorage;
using Niagara.Data.InMemory.InMemoryStorage.Providers;
using Niagara.Data.InMemory.Repositories;
using Niagara.Domain.Services;
using Niagara.Domain.Services.Interfaces;

namespace Niagara.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            // In production, the Vue files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Niagara Web API", Version = "v1" });
            });

            services.AddSingleton<MaterialLogInMemoryProvider>();
            services.AddSingleton<MaterialLogTypeInMemoryProvider>();
            services.AddSingleton<PartNumberInMemoryProvider>();
            services.AddSingleton<ShapeInMemoryProvider>();
            services.AddSingleton<SupplierInMemoryProvider>();
            services.AddSingleton<UnitOfMeasureInMemoryProvider>();

            services.AddSingleton<InMemoryDataGenerator>();

            services.AddScoped<IMaterialLogRepository, MaterialLogInMemoryRepository>();
            services.AddScoped<IMaterialLogTypeRepository, MaterialLogTypeInMemoryRepository>();
            services.AddScoped<IPartNumberRepository, PartNumberInMemoryRepository>();
            services.AddScoped<IShapeRepository, ShapeInMemoryRepository>();
            services.AddScoped<ISupplierRepository, SupplierInMemoryRepository>();
            services.AddScoped<IUnitOfMeasureRepository, UnitOfMeasureInMemoryRepository>();

            services.AddScoped<IMaterialLogService, MaterialLogService>();
            services.AddScoped<ISelectableOptionService, SelectableOptionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, InMemoryDataGenerator inMemoryDataGenerator)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Niagara Web API v1");
            });

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:8080"); // Vue app port
                }
            });

            inMemoryDataGenerator.Generate();
        }
    }
}
