using System;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Extensions
{
    public static class ApiVersioningExtension
    {
        public static void ConfigureApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });
        }
    }
}



