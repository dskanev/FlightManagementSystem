using FlightManagementSystem.Application.Configuration;
using FlightManagementSystem.Configuration;
using FlightManagementSystem.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApiServices()
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.ConfigureWebApplication();
