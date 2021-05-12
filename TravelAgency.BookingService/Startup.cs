using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog.AspNetCore;
using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MassTransit.AspNetCoreIntegration;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TravelAgency.BookingService.Application.Validators;
using TravelAgency.BookingService.Domain.Common;
using TravelAgency.BookingService.Domain.Repositories;
using TravelAgency.BookingService.Infrastructure;
using TravelAgency.BookingService.Infrastructure.Data;
using TravelAgency.BookingService.Infrastructure.Services;
using Microsoft.Extensions.Options;
using TravelAgency.BookingService.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MessageBroker.Consumers;
using MessageBroker.Contracts;

namespace TravelAgency.BookingService
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

            services.AddMassTransit(cfg => {
                cfg.UsingRabbitMq((context,config)=>
                {
                    config.Host(new Uri(Configuration["RabbitMQConfig:Configuration"]));
                });
                cfg.AddRequestClient<VerifyTOffer>(new Uri(Configuration["RabbitMQConfig:Configuration"]));
                cfg.AddRequestClient<VerifyHOffer>(new Uri(Configuration["RabbitMQConfig:Configuration"]));
            });
            services.AddMassTransitHostedService();
            services.AddAuthentication(cfg=>
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
            services.Configure<BookingEventStoreSettings>(Configuration.GetSection(nameof(BookingEventStoreSettings)));
            services.AddSingleton<IBookingEventStoreSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<BookingEventStoreSettings>>().Value);
            services.AddScoped<IJsonSerializer, JsonSerializer>();
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();
            services.AddAutoMapper(typeof(TravelAgency.BookingService.Domain.Common.AutoMapper));
            services.AddDbContext<BookingDbContext>(_=>_.UseSqlServer(Configuration.GetConnectionString("ConnectionStringRB")));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatePipelineBehaviour<,>));
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddMediatR(typeof(Startup));
            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           // app.UseHttpsRedirection();
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
