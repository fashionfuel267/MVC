using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceData.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EcommerceData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<EModel>();
                    DBInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }


    public class DBInitializer
    {
        public static void Initialize(EModel context)
        {

            context.Database.EnsureCreated();
            if (context.Units.Any())
            {
                return;
            }
            var units = new Unit[]
            {
                new Unit{ Name="Kilogram", Shortname="Kg"},
                new Unit{ Name
                ="Liter", Shortname="LT"},
                new Unit{ Name="Piece", Shortname="PC"},
                new Unit{ Name="Cartoon", Shortname="CT"},
                new Unit{ Name="Box", Shortname="BX"},
                new Unit{ Name="Square Feet", Shortname="SF"}
            };
            units.ToList().ForEach(u => context.Units.Add(u));
            context.SaveChanges();


            var district = new District[]
            {
                new District{ Name="Dhaka"},
                new District{ Name="Rangpur"},
                new District{ Name="Kurigram"},

            };
            district.ToList().ForEach(d => context.Districts.Add(d));
            context.SaveChanges();
            var thana = new Thana[]
            {
                new Thana{ Name="Mohammadpur",DistId=1},
                new Thana{ Name="Mirpur-2",DistId=1},
                new Thana{ Name="Dhanmondi",DistId=1},
                new Thana{ Name="Mirpur-1",DistId=1},
                   new Thana{ Name="Kafrul",DistId=1},
                      new Thana{ Name="Dhap",DistId=2},
                         new Thana{ Name="Dorshona",DistId=2},
                          new Thana{ Name="Kurigram Sadar",DistId=3},
                   new Thana{ Name="Ulipur",DistId=3},
                      new Thana{ Name="Rajibpur",DistId=3},
                         new Thana{ Name="Chilmari",DistId=3},
            };
            thana.ToList().ForEach(d => context.Thanas.Add(d));
            context.SaveChanges();

            var status = new OrderStatus[]
            {
                new OrderStatus{ Status="Pending"},
                new OrderStatus{ Status="Cancelled"},
                new OrderStatus{ Status="Delivered"},

            };
            status.ToList().ForEach(d => context.OrderStatus.Add(d));
            context.SaveChanges();

            var shipper = new Shipper[]
           {
                new Shipper{  Name="Sundarbon"},
                new Shipper{ Name="Continental"},
                new Shipper{ Name="UPS"},

           };
            shipper.ToList().ForEach(d => context.Shippers.Add(d));
            context.SaveChanges();

        }
    }
}
