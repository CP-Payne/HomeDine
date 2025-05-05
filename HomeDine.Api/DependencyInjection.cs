using HomeDine.Api.Common.Mapping;
using HomeDine.Api.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace HomeDine.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, HomeDineProblemDetailsFactory>();

            services.AddOpenApi();
            services.AddMappings();
            return services;
        }
    }
}
