using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using MediatR;
using MessageBroker.Consumers.Contracts;
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
using TravelAgency.HotelService.Application.Validators;
using TravelAgency.HotelService.Domain.Common;
using TravelAgency.HotelService.Domain.Common.Interfaces;
using TravelAgency.HotelService.Infrastructure.Data;
using TravelAgency.HotelService.Infrastructure.Repositories;

namespace TravelAgency.HotelService
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

            services.AddMassTransit(cfg=>
            {
                //cfg.AddRequestClient<GetUser>(new Uri(Configuration["RabbitMQConfig:Configuration"]+"/GetUser"));
                cfg.AddRequestClient<GetUser>(new Uri(Configuration["RabbitMQConfig:Configuration"] + "/GetUser"), TimeSpan.FromSeconds(10));
                cfg.UsingRabbitMq((context, config) =>
                {
                    config.Host(new Uri(Configuration["RabbitMQConfig:Configuration"]));
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
            services.AddDbContext<HotelDbContext>(_ => _.UseNpgsql(Configuration.GetConnectionString("ConnectionStringRB")));
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IHotelOfferRepository, HotelOfferRepository>();
            services.AddScoped<IHotelRoomRepository, HotelRoomRepository>();
            services.AddScoped<IHotelReviewRepository, HotelReviewRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
         //   services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidatePipelineBehaviour<,>));
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));
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
         //   app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(_=>_.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
