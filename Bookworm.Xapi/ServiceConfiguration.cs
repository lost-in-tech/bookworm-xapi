using Microsoft.Extensions.DependencyInjection;
using Bolt.IocScanner;
using Bolt.RequestBus;

namespace Bookworm.Xapi
{
    public static class ServiceConfiguration
    {
        public static void Configure(this IServiceCollection services)
        {
            services.Scan<Startup>(new IocScannerOptions { SkipWhenAutoBindMissing = true });
            services.AddRequestBus();
        }
    }
}
