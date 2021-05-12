using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using MessageBroker.Consumers.Consumers;

namespace MessageBroker
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
                // Bus.Factory.CreateUsingRabbitMq(cfg=>{
                //     cfg.Host(Configuration["RabbitMQ:Configuration"]);
                // });
                cfg.AddConsumer<TransportOfferConsumer>().Endpoint(endp=>endp.Name="booking-toffer");
                cfg.AddConsumer<HotelOfferConsumer>().Endpoint(endp => endp.Name = "booking-hoffer");
                cfg.UsingRabbitMq((cxt,cfg)=>{
                    cfg.Host(new Uri("rabbitmq://192.168.43.142:5672"));
                    cfg.ConfigureEndpoints(cxt);
                });
            });
            services.AddMassTransitHostedService();
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
