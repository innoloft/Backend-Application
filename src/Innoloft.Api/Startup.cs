using AutoMapper;
using Innoloft.Api.Helpers;
using Innoloft.Interfaces.Services;
using Innoloft.Repositories;
using Innoloft.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using NLog;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Innoloft.Api
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
            services.AddCors();
            services.AddControllers().AddNewtonsoftJson();
            services.AddControllersWithViews();

            services.AddAutoMapper();

            #region -- Configure strongly typed settings objects --

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            #endregion

            #region -- Setup Database layer --

            // SQLite Connection
             services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            #endregion

            #region -- Configure jwt authentication --

            // var appSettings = appSettingsSection.Get<AppSettings>();
            // var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            // services.AddAuthentication(x =>
            // {
            //     x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //     x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            // })
            // .AddJwtBearer(x =>
            // {
            //     x.Events = new JwtBearerEvents
            //     {
            //         OnTokenValidated = context =>
            //         {
            //             try
            //             {
            //                 var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
            //                 var userId = int.Parse(context.Principal.Identity.Name);
            //                 var user = userService.GetUser(userId);
            //                 if (user == null)
            //                 {
            //                     // return unauthorized if user no longer exists
            //                     context.Fail("Unauthorized");
            //                 }
            //             }
            //             // catch (Ssats.Core.Utilities.SsatsCoreException ex)
            //             // {
            //             //     context.Fail("Unauthorized");
            //             // }
            //             // catch (RepositoryException ex)
            //             // {
            //             // }
            //             catch (System.Exception)
            //             {
            //                 context.Fail("Unauthorized");
            //                 // return StatusCode(500, ex.Message);
            //             }
            //             return Task.CompletedTask;
            //         }
            //     };
            //     x.RequireHttpsMetadata = false;
            //     x.SaveToken = true;
            //     x.TokenValidationParameters = new TokenValidationParameters
            //     {
            //         ValidateIssuerSigningKey = true,
            //         IssuerSigningKey = new SymmetricSecurityKey(key),
            //         ValidateIssuer = false,
            //         ValidateAudience = false
            //     };
            // });

            #endregion

            #region -- Register Swagger  Services --
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Innoloft API", Version = "v1" });
            });
            #endregion

            #region -- Configure DI for services --

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductTypeService, ProductTypeService>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext dataContext)
        {
            dataContext.Database.Migrate();
            
            LogManager.Configuration.Variables["logsDir"] = string.Format("{0}/Logs", env.ContentRootPath);
            
            #region -- Configure Swagger --
            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
            });
            #endregion

            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
                app.UseExceptionHandler(a => a.Run(async context =>
                {
                    var feature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = feature.Error;

                    var result = JsonConvert.SerializeObject(new { error = string.Format("Internal Server Error."), details = exception.Message, stackTrace = exception.StackTrace });
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(result);
                }));

            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseEndpoints(x => x.MapControllers());

        }
    }
}
