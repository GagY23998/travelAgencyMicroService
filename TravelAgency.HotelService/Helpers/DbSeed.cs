using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain;
using TravelAgency.HotelService.Infrastructure.Data;

namespace TravelAgency.HotelService.Helpers
{
    public static class DbSeed
    {

        public static IHost SeedDB(this IHost host)
        {

            using(var scope = host.Services.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<HotelDbContext>();

                if (!_context.Hotels.Any())
                {

                    _context.AddRange(new List<Hotel>
                    {
                        new Hotel { Id=1,Name = "Hotel 1",CityId = 1,Description ="Really nice hotel mate",Rating=5.0f},
                        new Hotel { Id=2,Name = "Hotel 2",CityId = 3,Description ="Really nice hotel mate",Rating=4.2f},
                        new Hotel { Id=3,Name = "Hotel 3",CityId = 2,Description ="Really nice hotel mate",Rating=3.0f},
                        new Hotel { Id=4,Name = "Hotel 4",CityId = 4,Description ="Really nice hotel mate",Rating=3.8f}
                    });
                    _context.SaveChanges();
                    _context.AddRange(new List<RoomType>
                    {
                        new RoomType{Id=1,Type ="Low Level Room"},
                        new RoomType{Id=2,Type ="Mid Level Room"},
                        new RoomType{Id=3,Type ="High Level Room"}
                    });
                    _context.SaveChanges();
                    _context.AddRange(new List<HotelRoom>
                    {
                        new HotelRoom{Id=1,HotelId =1,RoomTypeId=1,Capacity=2},
                        new HotelRoom{Id=2,HotelId =2,RoomTypeId=2,Capacity=2},
                        new HotelRoom{Id=3,HotelId =3,RoomTypeId=3,Capacity=4},
                        new HotelRoom{Id=4,HotelId =4,RoomTypeId=3,Capacity=3},
                        new HotelRoom{Id=5,HotelId =2,RoomTypeId=2,Capacity=2},
                        new HotelRoom{Id=6,HotelId =1,RoomTypeId=1,Capacity=2},
                        new HotelRoom{Id=7,HotelId =3,RoomTypeId=3,Capacity=4},
                        new HotelRoom{Id=8,HotelId =2,RoomTypeId=1,Capacity=2},
                        new HotelRoom{Id=9,HotelId= 4,RoomTypeId=2,Capacity=3}
                    });
                    _context.SaveChanges();
                    _context.HotelReviews.AddRange(new List<HotelReview>{
                        new HotelReview{ Id=1, UserId= 1, HotelId = 1, Date =DateTime.Now.AddDays(4), Comment="Nice Hotel mate"},
                        new HotelReview{ Id=2, UserId= 2, HotelId = 1, Date =DateTime.Now.AddDays(4), Comment="Nice Hotel mate"},
                        new HotelReview{ Id=3, UserId= 3, HotelId = 1, Date =DateTime.Now.AddDays(4), Comment="Nice Hotel mate"},
                        new HotelReview{ Id=4, UserId= 4, HotelId = 2, Date =DateTime.Now.AddDays(4), Comment="Nice Hotel mate"},
                        new HotelReview{ Id=5, UserId= 5, HotelId = 2, Date =DateTime.Now.AddDays(4), Comment="Nice Hotel mate"},
                        new HotelReview{ Id=6, UserId= 2, HotelId = 2, Date =DateTime.Now.AddDays(4), Comment="Nice Hotel mate"}
                    });
                    
                    _context.SaveChanges();
                    _context.AddRange(new List<HotelOffer>
                    {
                        new HotelOffer{Id=Guid.NewGuid(),HotelId=4,HotelRoomId=1,StartDate=DateTime.Now,ExpirationDate=DateTime.Now.AddDays(2) ,Price=1240.22f},
                        new HotelOffer{Id=Guid.NewGuid(),HotelId=1,HotelRoomId=4,StartDate=DateTime.Now,ExpirationDate=DateTime.Now.AddDays(6) ,Price=1240.22f},
                        new HotelOffer{Id=Guid.NewGuid(),HotelId=2,HotelRoomId=3,StartDate=DateTime.Now,ExpirationDate=DateTime.Now.AddDays(7) ,Price=1240.22f},
                        new HotelOffer{Id=Guid.NewGuid(),HotelId=3,HotelRoomId=6,StartDate=DateTime.Now,ExpirationDate=DateTime.Now.AddDays(12),Price=1240.22f},
                        new HotelOffer{Id=Guid.NewGuid(),HotelId=4,HotelRoomId=8,StartDate=DateTime.Now,ExpirationDate=DateTime.Now.AddDays(4) ,Price=1240.22f},
                        new HotelOffer{Id=Guid.NewGuid(),HotelId=2,HotelRoomId=2,StartDate=DateTime.Now,ExpirationDate=DateTime.Now.AddDays(9) ,Price=1240.22f},
                        new HotelOffer{Id=Guid.NewGuid(),HotelId=1,HotelRoomId=9,StartDate=DateTime.Now,ExpirationDate=DateTime.Now.AddDays(20),Price=1240.22f}
                    });
                    _context.SaveChanges();
                }

                return host;
            }

        }
    }
}
