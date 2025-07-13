using Shop.Infrastructure.Extensions;
using Shop.Infrastructure.Seeders;
using Shop.Application.Extensions;
using Serilog;
using Shop.API.Middlewares;
using Shop.Domain.Entities;
using Shop.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);



var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IShopSeeder>();
await seeder.Seed();

// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestTimeLoggingMiddleware>();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("api/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
