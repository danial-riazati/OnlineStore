using System;
using AspNetCoreRateLimit;

namespace OnlineStore.Extensions
{
    public static class ApiRateLimitExtentions
    {
        public static void ConfigureApiRateLimit(this IServiceCollection services)
        {
            services.Configure<IpRateLimitOptions>(options =>
            {
                options.EnableEndpointRateLimiting = true;
                options.StackBlockedRequests = false;
                options.HttpStatusCode = 429;
                options.RealIpHeader = "X-Real-IP";
                options.ClientIdHeader = "X-ClientId";
                options.GeneralRules = new List<RateLimitRule>
        {
            new RateLimitRule
            {
                Endpoint ="*",
                Period = "5s",
                Limit = 2,
            }
        };
            });
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
            services.AddInMemoryRateLimiting();
        }
    }
}

