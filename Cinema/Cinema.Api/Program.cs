using Cinema.Api.Extensions;
using Cinema.Domain.Entities;
using Cinema.Application.Extensions;
using Cinema.Infrastructure.Extensions;
using Cinema.Infrastructure.Seeders;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ICinemaSeeder>();
await seeder.Seed();

// Configure the HTTP request pipeline.

app.UseSerilogRequestLogging();

app.MapGroup("api/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();