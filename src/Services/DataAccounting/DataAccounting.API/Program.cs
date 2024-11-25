using DataAccounting.API;
using DataAccounting.Application;
using DataAccounting.Infrastructure;
using DataAccounting.Infrastructure.Data.Extensions;

const string _nameService = "User data accounting. API";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration, _nameService);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiServices(_nameService);

if (app.Environment.IsDevelopment())
{
      await app.InitialiseDatabaseAsync();
}

app.Run();
