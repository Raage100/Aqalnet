using Aqalnet.Api.Middleware;
using Aqalnet.Api.OpenApi;
using Aqalnet.Application;
using Aqalnet.Application.Abstractions.Data;
using Aqalnet.Infrastructure;
using Dapper;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();
        foreach (var description in descriptions)
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

//app.UseRequestContextLogging();
//app.UseSerilogRequestLogging();

app.UseCustomExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks(
    "health",
    new HealthCheckOptions { ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse }
);

app.Run();

public partial class Program;
