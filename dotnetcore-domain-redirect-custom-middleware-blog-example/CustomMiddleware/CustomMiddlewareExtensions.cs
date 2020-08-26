using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcore_domain_redirect_custom_middleware_blog_example.CustomMiddleware
{
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseDomainRedirectMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DomainRedirectMiddleware>();
        }
    }
}
