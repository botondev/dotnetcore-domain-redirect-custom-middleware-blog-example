using dotnetcore_domain_redirect_custom_middleware_blog_example.Configuration;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcore_domain_redirect_custom_middleware_blog_example.CustomMiddleware
{
    public class DomainRedirectMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<DomainRedirectMiddleware> _logger;
        private readonly IOptions<RedirectToPublicDomainConfiguration> _configuration;

        public DomainRedirectMiddleware(RequestDelegate next, IOptions<RedirectToPublicDomainConfiguration> configuration, ILogger<DomainRedirectMiddleware> logger)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var redirected = false;
            if (_configuration.Value.RedirectFromHost != null && _configuration.Value.RedirectToHost != null)
            {
                var redirectFromHost = _configuration.Value.RedirectFromHost;
                if (context.Request.GetUri().Host.Contains(redirectFromHost))
                {
                    var redirectToHost = _configuration.Value.RedirectToHost;
                    var path = context.Request.Path.Value;
                    var isPermanent = _configuration.Value.IsPermanent;

                    context.Response.Redirect($"{redirectToHost}{path}", isPermanent);
                    redirected = true;
                }
            }

            if (redirected == false)
            {
                await _next(context);
            }
        }
    }
}
