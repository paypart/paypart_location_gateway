﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace paypart_location_gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://0.0.0.0:9006")
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                   IHostingEnvironment env = builderContext.HostingEnvironment;
                    //config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    config.AddJsonFile("secrets/appsettings.locationgateway.json", optional: true, reloadOnChange: true);
                })
                .UseHealthChecks("/health")
                .Build();
    }
}
