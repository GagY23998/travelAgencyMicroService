using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using MediatR;
using MessageBroker.Consumers.Consumers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TravelAgency.TravelService.Application.Queries;
using TravelAgency.TravelService.Application.Validators;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.Common;
using TravelAgency.TravelService.Domain.Common.Interfaces;
using TravelAgency.TravelService.Infrastructure.Data;
using TravelAgency.TravelService.Infrastructure.Repositories;

namespace TravelAgency.TravelService
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
                cfg.AddConsumer<TransportOfferConsumer>().Endpoint(cfgE => cfgE.Name = "booking-toffer");
                cfg.UsingRabbitMq((cxt, mcfg) => {
                    mcfg.Host(new Uri(Configuration["RabbitMQConfig:Configuration"]));
                    mcfg.ConfigureEndpoints(cxt);
                });
            });
            services.AddMassTransitHostedService();

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
            services.AddAutoMapper(typeof(TravelAgency.TravelService.Domain.Common.Mapper));
            services.AddScoped<IDbSession, DbSession>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<Tour>, Repository<Tour>>();
            services.AddScoped<IRepository<TransportCompany>, Repository<TransportCompany>>();
            services.AddScoped<IRepository<TransportReview>,Repository<TransportReview>>();
            services.AddScoped<IRepository<TransportOffer>, Repository<TransportOffer>>();
            services.AddScoped<IRepository<TransportType>, Repository<TransportType>>();
            services.AddScoped<IRepository<Attraction>, Repository<Attraction>>();
            services.AddScoped<IRepository<City>, Repository<City>>();
            services.AddScoped<IRepository<Country>,Repository<Country>>();
            services.AddMediatR(typeof(Startup));
            //         services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatePipelineBehaviour<,>));
            services.AddOptions();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

     //       app.UseHttpsRedirection();
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
