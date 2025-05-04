using HomeDine.Application.Services.Authentication;
using HomeDine.Application.Services.Authentication.Commands;
using HomeDine.Application.Services.Authentication.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace HomeDine.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();

            return services;
        }
    }
}
