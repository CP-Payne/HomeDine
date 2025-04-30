using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeDine.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace HomeDine.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
