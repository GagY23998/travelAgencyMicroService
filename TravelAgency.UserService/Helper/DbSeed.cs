using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using TravelAgency.UserService.Infrastructure.Data;
using TravelAgency.UserService.Domain;
using System.Linq;
using Microsoft.Extensions.Hosting;

namespace TravelAgency.UserService.Helper
{
    public static class DbSeed
    {
        public static IHost SeedDb(this IHost host)
        {
            using(var scope = host.Services.CreateScope()){

            var context = scope.ServiceProvider.GetRequiredService<UserDbContext>();
            
                if(!context.Users.Any()){

                    context.Add<Role>(new Role{Id = 1, Name ="Admin"});
                    context.Add<Role>(new Role{Id = 2, Name ="User"});
                    context.SaveChanges();
                    context.Add<User>(new User{Id =1,FirstName = "Admin", LastName = "Admin", BirthDate = DateTime.Now, Age = 99, Address = "Admin House" });
                    context.Add<User>(new User{Id =2,FirstName="User2",LastName="User2",BirthDate=DateTime.Now, Age =99, Address="User2 House"});
                    context.Add<User>(new User{Id =3,FirstName="User3",LastName="User3",BirthDate=DateTime.Now, Age =99, Address="User3 House"});
                    context.Add<User>(new User{Id =4,FirstName="User4",LastName="User4",BirthDate=DateTime.Now, Age =99, Address="User4 House"});
                    context.Add<User>(new User{Id =5,FirstName="User5",LastName="User5",BirthDate=DateTime.Now, Age =99, Address="User5 House"});
                    context.SaveChanges();
                    context.Add<UserRole>(new UserRole{RoleId = 1,UserId= 1});
                    context.Add<UserRole>(new UserRole{RoleId = 2,UserId= 2});
                    context.Add<UserRole>(new UserRole{RoleId = 2,UserId= 3});
                    context.Add<UserRole>(new UserRole{RoleId = 2,UserId= 4});
                    context.Add<UserRole>(new UserRole{RoleId = 2,UserId= 5});
                    context.SaveChanges();
                }
            }
            return host;
        }
        
    }
    
}