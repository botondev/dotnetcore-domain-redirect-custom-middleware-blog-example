using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcore_domain_redirect_custom_middleware_blog_example.Configuration
{
    public class RedirectToPublicDomainConfiguration
    {
        public string RedirectFromHost { get; set; }

        public string RedirectToHost { get; set; }

        public bool IsPermanent { get; set; }
    }
}
