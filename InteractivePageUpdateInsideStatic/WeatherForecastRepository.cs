using System.Collections.Generic;

namespace InteractivePageUpdateInsideStatic;

public class WeatherForecastRepository
{
    private List<WeatherForecast> forecasts;

    public WeatherForecastRepository()
    {
        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[Random.Shared.Next(summaries.Length)]
        }).ToList();
    }

    public IEnumerable<WeatherForecast> Forecasts => forecasts;

    public void RemoveLast()
    {
        forecasts.RemoveAt(forecasts.Count - 1);
    }
}

public class WeatherForecast
{
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
