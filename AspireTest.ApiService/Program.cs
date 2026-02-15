using AspireTest.ApiService.Controllers;
using AspireTestCore.Interfaces;
using AspireTestInfra.Services.Implementations;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddScoped<IFDTService>(provider => {
    string? excelPath = builder.Configuration.GetValue<string>("ExcelPath");
    return new FDTService(excelPath);
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapDefaultEndpoints()
   .MapWeatherForecastEndpoints();
  
app.MapFDTEndpoints();

app.Run();

