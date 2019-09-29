using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net.Mime;

namespace boilerplate_netcore_api_mysql.Extensions
{
    /// <summary>
    /// Configure all 
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configure Database
        /// </summary>
        /// <param name="Services"></param>
        /// <param name="Config"></param>
        public static void ConfigureSqlServerContext(this IServiceCollection Services, IConfiguration Config)
        {
            Services.AddDbContext<boilerplate_netcore_api_mysql.Apps.Models.DataSource>(options =>
            {
                options.UseMySQL(connectionString: Config["ConnectionString"]);
                //comment 2 line code if prod env
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            });
        }

        /// <summary>
        /// Configure Dependency Injection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Config"></param>
        public static void ConfigureDi(this IServiceCollection services, IConfiguration Config)
        {
            services.AddScoped<boilerplate_netcore_api_mysql.Apps.Interfaces.IRepositoryWrapper, boilerplate_netcore_api_mysql.Apps.Repository.RepositoryWrapper>();
            var mappingConfig = new MapperConfiguration(mc =>
             {
                 mc.AddProfile(new Apps.Extensions.MappingProfile());
             });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddHttpContextAccessor();
        }

        /// <summary>
        /// Compression Service
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCompression(this IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                IEnumerable<string> MimeTypes = new[]
                                     {
                                         // General
                                         "text/plain",
                                         "image/jpg",
                                         "application/json",
                                         "text/json",
                                         "text/csv"
                };
                options.EnableForHttps = true;
                options.MimeTypes = MimeTypes;
                options.Providers.Add<GzipCompressionProvider>();
                options.Providers.Add<BrotliCompressionProvider>();
            });

            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });
        }

        /// <summary>
        /// UseCorsMiddleWare
        /// </summary>
        /// <param name="app"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCorsMiddleWare(this IApplicationBuilder app, IConfiguration config)
        {
            var accessOrigin = config.GetValue<string>("Access-Control-Allow-Origin", "https://*.unitedtractors.com");
            return app.UseCors(option => option.WithOrigins(accessOrigin)
                              .AllowAnyMethod()
                              .SetIsOriginAllowedToAllowWildcardSubdomains()
                              .SetPreflightMaxAge(TimeSpan.FromSeconds(5000))
                );
        }
    }

    /// <summary>
    /// CheckFile
    /// </summary>
    public class HelperInitClass<T> where T : class
    {
        /// <summary>
        /// Init
        /// </summary>
        /// <returns></returns>
        public List<T> Init()
        {
            IEnumerable<T> List = Enumerable.Empty<T>();
            return List.ToList();
        }

    }

}
