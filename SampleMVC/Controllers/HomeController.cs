using Serilog;
using Serilog.Events;
using Serilog.Sinks.Graylog;
using Serilog.Sinks.Graylog.Core;
using Serilog.Sinks.Graylog.Core.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrayLogTest.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var loggerConfig = new LoggerConfiguration();

            loggerConfig.WriteTo.Graylog(new GraylogSinkOptions
            {
                ShortMessageMaxLength = 50,
                MinimumLogEventLevel = LogEventLevel.Fatal,
                Facility = "DotNetFramework.MVC.GrayLog",
                HostnameOrAddress = "csclogs.minhati.com.br",
                Port = 12201
            });

            var logger = loggerConfig.CreateLogger();

            logger.Error("Testando envio UDP", "Error");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}