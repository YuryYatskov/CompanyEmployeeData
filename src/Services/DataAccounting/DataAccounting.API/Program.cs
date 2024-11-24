using BuildingBlocks.Builders;
using DataAccounting.API;
using DataAccounting.Application;
using DataAccounting.Infrastructure;

const string _nameService = "User data accounting. API";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwagger(_nameService);
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiServices(_nameService);

if (app.Environment.IsDevelopment())
{
    //await app.InitialiseDatabaseAsync();
}

app.Run();
