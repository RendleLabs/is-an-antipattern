using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App.Metrics;
using App.Metrics.AspNetCore;
using App.Metrics.Formatters.InfluxDB;
using App.Metrics.Reporting.InfluxDB;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace IsAnAntipattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureMetricsWithDefaults(
                    (context, builder) =>
                    {
                        var influxOptions = new MetricsReportingInfluxDbOptions();
                        context.Configuration.GetSection("MetricsOptions").Bind(influxOptions);
                        influxOptions.MetricsOutputFormatter = new MetricsInfluxDbLineProtocolOutputFormatter();
                        builder.Report.ToInfluxDb(influxOptions);
                    })
                .UseMetrics()
                .UseStartup<Startup>();
    }
}
