using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarCatalog.Database;
using CarCatalog.Database.Entities;
using CarCatalog.Service.Repositories.Interfaces;
using CarCatalog.Service.Repositories.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Unity;

namespace CarCatalog.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
