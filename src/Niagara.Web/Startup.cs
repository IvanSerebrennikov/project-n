using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Niagara.Data.Common.RepositoryInterfaces;
using Niagara.Data.Database.Repositories;
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

        private bool UseInMemoryData => Configuration.GetValue<bool>("UseInMemoryData");

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

            if (UseInMemoryData)
            {
                ConfigureInMemoryDataProviderServices(services);
                ConfigureInMemoryDataServices(services);
            }
            else
            {
                ConfigureDatabaseDataServices(services);
            }
            
            ConfigureDomainServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            if (!env.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }
            
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

            if (UseInMemoryData)
            {
                var inMemoryDataGenerator = app.ApplicationServices.GetService<InMemoryDataGenerator>();
                inMemoryDataGenerator.Generate();
            }
        }

        #region private

        private void ConfigureInMemoryDataProviderServices(IServiceCollection services)
        {
            services.AddSingleton<MaterialLogInMemoryProvider>();
            services.AddSingleton<MaterialLogTypeInMemoryProvider>();
            services.AddSingleton<PartNumberInMemoryProvider>();
            services.AddSingleton<ShapeInMemoryProvider>();
            services.AddSingleton<SupplierInMemoryProvider>();
            services.AddSingleton<UnitOfMeasureInMemoryProvider>();
            services.AddSingleton<MaterialLogNoteInMemoryProvider>();
            services.AddSingleton<InventoryMaterialTicketInMemoryProvider>();

            services.AddSingleton<InMemoryDataGenerator>();
        }

        private void ConfigureInMemoryDataServices(IServiceCollection services)
        {
            services.AddScoped<IMaterialLogRepository, MaterialLogInMemoryRepository>();
            services.AddScoped<IMaterialLogTypeRepository, MaterialLogTypeInMemoryRepository>();
            services.AddScoped<IPartNumberRepository, PartNumberInMemoryRepository>();
            services.AddScoped<IShapeRepository, ShapeInMemoryRepository>();
            services.AddScoped<ISupplierRepository, SupplierInMemoryRepository>();
            services.AddScoped<IUnitOfMeasureRepository, UnitOfMeasureInMemoryRepository>();
            services.AddScoped<IMaterialLogNoteRepository, MaterialLogNoteInMemoryRepository>();
            services.AddScoped<IInventoryMaterialTicketRepository, InventoryMaterialTicketInMemoryRepository>();
        }

        private void ConfigureDatabaseDataServices(IServiceCollection services)
        {
            services.AddScoped<IMaterialLogRepository, MaterialLogRepository>();
            services.AddScoped<IMaterialLogTypeRepository, MaterialLogTypeRepository>();
            services.AddScoped<IPartNumberRepository, PartNumberRepository>();
            services.AddScoped<IShapeRepository, ShapeRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IUnitOfMeasureRepository, UnitOfMeasureRepository>();
            services.AddScoped<IMaterialLogNoteRepository, MaterialLogNoteRepository>();
            services.AddScoped<IInventoryMaterialTicketRepository, InventoryMaterialTicketRepository>();
        }

        private void ConfigureDomainServices(IServiceCollection services)
        {
            services.AddScoped<IMaterialLogService, MaterialLogService>();
            services.AddScoped<ISelectableOptionService, SelectableOptionService>();
            services.AddScoped<IInventoryMaterialTicketService, InventoryMaterialTicketService>();
        }

        #endregion
    }
}
