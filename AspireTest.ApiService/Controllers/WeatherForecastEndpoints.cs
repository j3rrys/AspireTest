using AspireTestCore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;

namespace AspireTest.ApiService.Controllers;

public static class WeatherForecastEndpoints
{
    public static void MapWeatherForecastEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/WeatherForecast").WithTags(nameof(WeatherForecast));
        string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

        group.MapGet("/", () =>
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                                            new WeatherForecast
                                           (
                                               DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                                               Random.Shared.Next(-20, 55),
                                               summaries[Random.Shared.Next(summaries.Length)]
                                           ))
                                           .ToArray();
            return forecast;
        })
        .WithName("GetAllWeatherForecasts");
    }
}
