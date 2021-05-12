using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TravelAgency.UserService.Domain.Common.Interfaces;
using TravelAgency.UserService.Helper;
using TravelAgency.UserService.Infrastructure.Data;
using TravelAgency.UserService.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TravelAgency.UserService.Infrastructure.Consumers;

namespace TravelAgency.UserService
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
            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<GetUserConsumer>();
                cfg.UsingRabbitMq((cxt,cfg) =>
                {
                    cfg.Host(new Uri(Configuration["RabbitMQConfig:Configuration"]));
                    cfg.ConfigureEndpoints(cxt);
                    
                });
            }).AddMassTransitHostedService();
            services.AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.FromSeconds(10)
                };
            });
            services.AddAuthorization(cfg =>
            {
                cfg.AddPolicy("Bearer", new Microsoft.AspNetCore.
                                        Authorization.AuthorizationPolicyBuilder()
                                        .AddAuthenticationSchemes()
                                        .RequireAuthenticatedUser()
                                        .Build());
            });
            services.AddCors();
            services.AddDbContext<UserDbContext>(_=>_.UseNpgsql(Configuration.GetConnectionString("ConnectionStringRB")));
            services.AddAutoMapper(typeof(TravelAgency.UserService.Domain.Common.MyMapper));
            services.AddScoped<IRoleRepository,RoleRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IUserRoleRepository,UserRoleRepository>();
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddEntityFrameworkNpgsql();
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
            app.UseCors(_=>_.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
