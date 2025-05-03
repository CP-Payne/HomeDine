using HomeDine.Api.Errors;
using HomeDine.Application;
using HomeDine.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, HomeDineProblemDetailsFactory>();

    builder.Services.AddOpenApi();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    // app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
