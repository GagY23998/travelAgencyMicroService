using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgency.TravelService.Helpers
{
    public static class DbSeed
    {
        public static IHost SeedDb(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

                using(var conn = new NpgsqlConnection())
                {
                    conn.ConnectionString = configuration.GetConnectionString("TravelServiceDB");
                    conn.Open();
                    var numOfRows = conn.Query("select * from transporttype").Any();
                    // var numOfRows = conn.Query<bool>("SELECT 1 WHERE EXISTS (SELECT 1 FROM transporttype WHERE id = @id)", new { id=1 }).Any();
                    
                if(numOfRows == false){
                    string ttypequery = "insert into transporttype(name) values(@name)";
                    var transportTypes = new List<object>()
                    {
                        new {id=1,name="Plane"},
                        new {id=2,name="Bus"},
                        new {id=3,name="Ship"}
                    };
                    foreach (var item in transportTypes)
                    {
                        conn.Execute(ttypequery,item);
                    }
                }

                
                numOfRows = conn.Query<bool>("SELECT 1 WHERE EXISTS (SELECT 1 FROM country WHERE id = @id)", new { id=1 }).Any();
                if(!numOfRows){
                    string countryQuery = "insert into country(id,name,description) values(@id,@name,@description)";
                    var countries = new List<object>(){
                        new {id=1,name="Country 1",description="Really nice country 1 mate, really beautiful country, wirklich wunderschon "},
                        new {id=2,name="Country 2",description="Really nice country 2 mate, really beautiful country, wirklich wunderschon "},
                        new {id=3,name="Country 3",description="Really nice country 3 mate, really beautiful country, wirklich wunderschon "},
                        new {id=4,name="Country 4",description="Really nice country 4 mate, really beautiful country, wirklich wunderschon "}
                    };
                    foreach(var item in countries){
                        conn.Execute(countryQuery,item);
                    }
                }
                numOfRows = conn.Query<bool>("SELECT 1 WHERE EXISTS (SELECT 1 FROM city WHERE id = @id)", new { id=1 }).Any();
                if(numOfRows == false){

                    string cityquery = "insert into city(id,name,description,rating,countryid) values(@id,@name,@description,@rating,@countryid)";
                    var cities = new List<object>()
                    {
                        new {id=1,name="City1",description="Really nice city, no betta city than this city",Rating=0,countryid=1},
                        new {id=2,name="City2",description="Really beautiful city, no betta city than this city",Rating=0,countryid=1},
                        new {id=3,name="City3",description="Really ugly city, no betta city than this city",Rating=0,countryid=3},
                        new {id=4,name="City4",description="Really no comment city, no betta city than this city",Rating=0,countryid=4}
                    };
                    foreach(var item in cities){
                        conn.Execute(cityquery,item);
                    }
                }   

                numOfRows = conn.Query<bool>("SELECT 1 WHERE EXISTS (SELECT 1 FROM transportcompany WHERE id = @id)", new { id=1 }).Any();
                if(numOfRows == false){
                    
                    string tcompanyQuery = "insert into transportcompany(id,name,description,cityid,totalvisits,rating,transporttypeid) values(@id,@name,@description,@cityid,@totalvisits,@rating,@transporttypeid)";
                    var transportCompaines = new List<object>() {
                        new {id=1,name="TransportCompany1",description="Really nojs company to work with",cityid = 1,totalvisits= 0,rating = 0,transporttypeid = 1},
                        new {id=2,name="TransportCompany1",description="Really nojs company to work with",cityid = 2,totalvisits= 0,rating = 0,transporttypeid = 2},
                        new {id=3,name="TransportCompany1",description="Really nojs company to work with",cityid = 3,totalvisits= 0,rating = 0,transporttypeid = 3},
                        new {id=4,name="TransportCompany1",description="Really nojs company to work with",cityid = 1,totalvisits= 0,rating = 0,transporttypeid = 2},
                        new {id=5,name="TransportCompany1",description="Really nojs company to work with",cityid = 4,totalvisits= 0,rating = 0,transporttypeid = 1}
                    };
                    foreach (var item in transportCompaines)
                    {
                        conn.Execute(tcompanyQuery, item);
                    }
                }
                numOfRows = conn.Query<bool>("SELECT 1 WHERE EXISTS (SELECT 1 FROM attraction WHERE id = @id)", new { id=1 }).Any();
                if(numOfRows == false){
                    string attractionquery = "insert into attraction(id,name,description,cityid) values(@id,@name,@description,@cityid)";
                    var attractions = new List<object>() {
                        new {id=1,cityid=1,description="Really nojs luukin atrakesja man",name ="The Attraction 1"},
                        new {id=2,cityid=2,description="Really nojs luukin atrakesja man",name ="The Attraction 2"},
                        new {id=3,cityid=3,description="Really nojs luukin atrakesja man",name ="The Attraction 3"},
                        new {id=4,cityid=4,description="Really nojs luukin atrakesja man",name ="The Attraction 4"},
                        new {id=5,cityid=2,description="Really nojs luukin atrakesja man",name ="The Attraction 5"},
                        new {id=6,cityid=1,description="Really nojs luukin atrakesja man",name ="The Attraction 6"}
                    };

                    foreach (var item in attractions)
                    {
                        conn.Execute(attractionquery, item);
                    }
                }

                Guid id = Guid.Parse("fe19cbf8-5a06-4d7d-a3ae-6bc962f3a064");

                numOfRows = conn.Query<bool>("SELECT 1 WHERE EXISTS(SELECT 1 FROM tour WHERE id = @id)", new { id = @id }).Any();

                // if(numOfRows == false)
                // {
                //         string tourQuery = "insert into tour(id,cityid) values(@id,@cityid)";
                //         List<Tour> tours = new List<Tour>()
                //         {
                //             new Tour{Id = id,CityId = 1},
                //             new Tour{Id = Guid.Parse("2a50d6de-4cba-4238-8b95-60093d47b266"),CityId = 1},
                //             new Tour{Id = Guid.Parse("a81d90e7-1dc5-4378-a9e3-9a6e6f1c0167"),CityId = 2},
                //             new Tour{Id = Guid.Parse("dd15d86a-42e1-4c12-8c87-ae253fa684b5"),CityId = 3},
                //             new Tour{Id = Guid.Parse("0de9f0e2-31dc-4fc2-a86e-ec5f47a9df36"),CityId = 2},
                //             new Tour{Id = Guid.Parse("c2faad83-cf6e-4ee6-acd5-8c511f5629de"),CityId = 3}
                //         };
                //         foreach (var item in tours)
                //         {
                //             conn.Execute(tourQuery, item);
                //         }
                // }

                id = Guid.Parse("cf0d52ff-5c29-4c04-af4d-65b0d6469d76");
                numOfRows = conn.Query<bool>("SELECT 1 WHERE EXISTS (SELECT 1 FROM transportoffer WHERE id = @id)", new { id =id }).Any();
                if(numOfRows == false) 
                {
                    string tOfferQuery = "insert into transportoffer(id,transportcompanyid,cityid,totalreservation,currentreserved,startdate,finishdate,price) values(@id,@transportcompanyid,@cityid,@totalreservation,@currentreserved,@startdate,@finishdate,@price)";
                    var toffers = new List<object>()
                    {
                        new {id = Guid.Parse("cf0d52ff-5c29-4c04-af4d-65b0d6469d76"),transportcompanyId = 1,cityid = 1,startdate = DateTime.Now, finishdate = DateTime.Now.AddDays(7),currentreserved = 0,totalreservation = 10,price=250.2f},
                        new {id = Guid.NewGuid(),transportcompanyId = 2,cityid = 1,startdate = DateTime.Now.AddDays(-15), finishdate = DateTime.Now.AddDays(7),currentreserved = 0,totalreservation = 10,price=291.56f},
                        new {id = Guid.NewGuid(),transportcompanyId = 3,cityid = 2,startdate = DateTime.Now.AddDays(-15), finishdate = DateTime.Now.AddDays(7),currentreserved = 0,totalreservation = 10,price=910.13f},
                        new {id = Guid.NewGuid(),transportcompanyId = 2,cityid = 3,startdate = DateTime.Now.AddDays(-15), finishdate = DateTime.Now.AddDays(7),currentreserved = 0,totalreservation = 10,price=210.91f},
                        new {id = Guid.NewGuid(),transportcompanyId = 3,cityid = 1,startdate = DateTime.Now.AddDays(-15), finishdate = DateTime.Now.AddDays(7),currentreserved = 0,totalreservation = 10,price=140.93f},
                        new {id = Guid.NewGuid(),transportcompanyId = 1,cityid = 4,startdate = DateTime.Now.AddDays(-15), finishdate = DateTime.Now.AddDays(7),currentreserved = 0,totalreservation = 10,price=490.48f}
                    };
                    foreach (var item in toffers)
                    {
                        conn.Execute(tOfferQuery, item);
                    }
                }


                    conn.Close();
                }
            }
            return host;
        }
    }
}
