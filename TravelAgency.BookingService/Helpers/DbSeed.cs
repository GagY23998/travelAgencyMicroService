using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TravelAgency.BookingService.Infrastructure.Data;

namespace TravelAgency.BookingService.Helpers{


    public static class DbSeed
    {
        public static IHost SeedDB(this IHost host){
            try{
                using(var scope = host.Services.CreateScope()){
                    var context = scope.ServiceProvider.GetRequiredService<BookingDbContext>();
                
                    context.Database.Migrate();     
                
                    if (!context.Payments.Any())
                    {
                        Guid PaymentId =Guid.NewGuid();
                        System.Console.WriteLine("Adding payments");
                        context.Payments.Add(new Domain.BookingAggregate.Payment{Id = PaymentId,Price= 300.12f,Discount=0 ,PaymentDate=DateTime.Now});
                        context.SaveChanges();
                        System.Console.WriteLine("Adding Bookings");
                        context.Bookings.Add( new Domain.BookingAggregate.Booking{
                            Id = Guid.NewGuid(),
                            ReservationDate= DateTime.Now,
                            HotelOfferId = Guid.NewGuid(),
                            TransportOfferId = Guid.NewGuid(),
                            PaymentId = PaymentId,
                            CanceledStatus = false,
                            Completed = true
                        });
                        context.SaveChanges();
                    }
                    }
                return host;

            }catch(Exception e){
                System.Console.WriteLine(e.Message);
            };
            return host;
        }

    }


}