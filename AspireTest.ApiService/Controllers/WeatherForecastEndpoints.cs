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

        group.MapGet("/{id}", (int id) =>
        {
            //return new WeatherForecast { ID = id };
        })
        .WithName("GetWeatherForecastById");

        group.MapPut("/{id}", (int id, WeatherForecast input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateWeatherForecast");

        group.MapPost("/", (WeatherForecast model) =>
        {
            //return TypedResults.Created($"/api/WeatherForecasts/{model.ID}", model);
        })
        .WithName("CreateWeatherForecast");

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new WeatherForecast { ID = id });
        })
        .WithName("DeleteWeatherForecast");
    }
}
