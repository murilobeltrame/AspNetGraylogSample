using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Graylog;
using Serilog.Sinks.Graylog.Core;

namespace SampleMVCCore
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.RollingFile("log-{Date}.log")
                .WriteTo.Graylog(new GraylogSinkOptions{
                    HostnameOrAddress = "localhost",
                    Port = 12201
                })
                .CreateLogger();
            try {
                Log.Information("Starting web app");
                CreateWebHostBuilder(args).Build().Run();
                return 0;
            } catch (Exception ex) {
                Log.Fatal(ex, "Web app terminated unexpectedly");
                return 1;
            } finally {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog();
    }
}
