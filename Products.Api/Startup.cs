using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Products.AutoMapper;
using Products.Business.Abstractions;
using Products.Business.Implementations;
using Products.DataAccess.Abstractions;
using Products.DataAccess.Implementations;
using Products.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Api
{
    public class Startup
    {
        readonly string AppOrigins = "ProductOrigins";
        string origins = null;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            origins = Configuration.GetValue<string>("AllowOrigins");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: AppOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin().WithOrigins("http://localhost:4200").AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
                //options.AddPolicy("AllowAnyOrigin",
                //    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());

                options.AddPolicy("AllowOrigins",
                    builder =>
                    {
                        builder.AllowAnyMethod().AllowAnyHeader();
                        builder.SetIsOriginAllowed(o => origins.Contains(";" + o + ";"));
                    }
                );
            }).AddAuthorization();
            services.AddTransient<IAddressBusinessModel, AddressBusinessModel>();
            services.AddTransient<ICompanyBusinessModel, CompanyBusinessModel>();
            services.AddTransient<IProductBusinessModel, ProductBusinessModel>();
            services.AddTransient<IUserBusinessModel, UserBusinessModel>();
            services.AddTransient<IAddressDataAccess, AddressDataAccess>();
            services.AddTransient<ICompanyDataAccess, CompanyDataAccess>();
            services.AddTransient<IProductDataAccess, ProductDataAccess>();
            services.AddTransient<IUserDataAccess, UserDataAccess>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddDbContextPool<ProductContext>(
                dbContextOptions => dbContextOptions
                    .UseMySQL(
                        // Replace with your connection string.
                        "server=productsapi.mysql.database.azure.com;user=productsadmin@productsapi;password=Sindhu*1989;database=productsapi"));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
