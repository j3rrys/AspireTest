namespace AspireTest.ApiService.Core.Models;

public class WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public DateOnly Date { get; set; } = Date;
    public string? Summary { get; set; } = Summary;
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
