using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Security
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenService, JwtTokenService>();
        

            return services;
        }

    }
}
