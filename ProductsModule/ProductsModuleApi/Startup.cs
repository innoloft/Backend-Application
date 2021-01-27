using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProductModuleDataAccess.Implementations;
using ProductModuleDataAccess.Interfaces;
using ProductModuleDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using AutoMapper;

namespace ProductsModuleApi
{
    public class Startup
    {
        private readonly string AllowedOrigin = "allowedOrigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();            

            services.AddDbContext<ProducrModuleDbContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("ProductModule")));

            services.AddCors(option =>
            {
                option.AddPolicy("allowedOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                    );
            });

            services.AddTransient<ITypesService, TypesService>();
            services.AddTransient<IContactsService, ContactsService>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IUserService, UserService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ProductModel API",
                    Version = "v1",
                    Description = "Minified version of the products module api",
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }         
            app.UseCors(AllowedOrigin);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductModel API"));
        }
    }
}
