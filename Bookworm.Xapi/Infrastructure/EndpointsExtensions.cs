using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Bookworm.Xapi.Infrastructure
{
    public static class EndpointsExtensions
    {
        public static void MapPing(this IEndpointRouteBuilder endpoints)
            => endpoints.Map("/ping", context => context.Response.WriteAsync("pong"));
    }
}
