using HomeDine.Api.Errors;
using HomeDine.Api.Filters;
using HomeDine.Api.Middleware;
using HomeDine.Application;
using HomeDine.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
    // Add services to the container.
    // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, HomeDineProblemDetailsFactory>();

    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }
    // app.UseMiddleware<ErrorHandlingMiddleware>();

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
