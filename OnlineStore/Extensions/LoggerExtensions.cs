using System;
using Serilog;

namespace OnlineStore.Extensions
{
    public static class LoggerExtensions
    {
        public static void ConfigureLogger(this WebApplicationBuilder builder)
        {
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);
        }
    }
}

