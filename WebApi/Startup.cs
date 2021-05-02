using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.MyServices.Utils.Log;
using CC.MyServices.Utils.Log.Contracts;
using CC.MyServicesPortal.Repository;
using CC.MyServicesPortal.Repository.Contract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using WebApi.Interfaces;
using WebApi.Services;

namespace WebApi
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
            services.AddDbContextPool<MyServicesDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString(" ")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICustomeLogger, CustomeLogger>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.WithOrigins(new[] { "http://localhost:3000", "http://localhost:3001" }).AllowAnyMethod()
                 .AllowAnyHeader().AllowCredentials());
            });

            //JSON Serializer
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
                .Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver 
                = new DefaultContractResolver());

            services.AddControllers();
            //var tokenKey = Configuration.GetValue<string>("TokenKey");
            var tokenKey = "This is a testKey";
            var key = Encoding.ASCII.GetBytes(tokenKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                };
            });

            services.AddSingleton<ITokenRefresher>(x =>
                new TokenRefresher(key, x.GetService<IJwtAuthenticationManager>()));
            services.AddSingleton<IRefreshTokenGenerator, RefreshTokenGenerator>();
            services.AddSingleton<IJwtAuthenticationManager>(x =>
                new JwtAuthenticationManager(tokenKey, x.GetService<IRefreshTokenGenerator>()));
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
            app.UseCors(options => options.WithOrigins(new[] { "http://localhost:3000", "http://localhost:3001" }).AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
