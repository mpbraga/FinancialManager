using FinancialManager.API.Settings;
using FinancialManager.Data;
using FinancialManager.Data.Configuration;
using FinancialManager.Data.Interfaces;
using FinancialManager.Data.Repositories;
using FinancialManager.Data.Repositories.Interfaces;
using FinancialManager.Services;
using FinancialManager.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FinancialManager.API
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
            ConfigureDatabase(services);

            ConfigureRepositories(services);

            RegisterServices(services);

            services.AddControllers();

            services.AddSwaggerGen();
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            services.AddTransient<IFinancialManagerDbContext, FinancialManagerDbContext>();
            services.AddTransient<IContextFactory, FinancialManagerDbContextFactory>();
            services.AddTransient(ResolveRepositoryConfig());
            services.AddTransient(ResolveDbConfig());
            services.AddTransient(ResolveContext());
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            services.AddTransient<IBillRepository, BillRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<ISupplierFilePatternRepository, SupplierFilePatternRepository>();
        }

        private static Func<IServiceProvider, IRepositoryConfig> ResolveRepositoryConfig()
        {
            return (serviceProvider) =>
            {
                var settings = serviceProvider.GetService<AppSettings>();

                return new FinancialManagerRepositoryConfig
                {
                    ConnectionString = settings.Database.ConnectionString
                };
            };
        }

        private static Func<IServiceProvider, DbContextOptions<FinancialManagerDbContext>> ResolveDbConfig()
        {
            return (serviceProvider) =>
            {
                var repositoryConfig = serviceProvider.GetService<IRepositoryConfig>();
                var optionsBuilder = new DbContextOptionsBuilder<FinancialManagerDbContext>();

                var options = optionsBuilder
                    .UseMySql(repositoryConfig.ConnectionString, ServerVersion.AutoDetect(repositoryConfig.ConnectionString));

                return options.Options;
            };
        }

        private static Func<IServiceProvider, Func<IFinancialManagerDbContext>> ResolveContext()
        {
            return (serviceProvider) =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<FinancialManagerDbContext>();
                var repositoryConfig = serviceProvider.GetService<IRepositoryConfig>();

                optionsBuilder
                    .UseMySql(repositoryConfig.ConnectionString, ServerVersion.AutoDetect(repositoryConfig.ConnectionString));

                return () => new FinancialManagerDbContext(optionsBuilder.Options);
            };
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IBillService, BillService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<ISupplierFilePatternService, SupplierFilePatternService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Financial Manager API");
                options.RoutePrefix = string.Empty;
            });
        }
    }
}
