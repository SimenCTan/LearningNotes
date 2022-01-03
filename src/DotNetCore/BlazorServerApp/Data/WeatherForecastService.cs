using Microsoft.Extensions.Caching.Memory;

namespace BlazorServerApp.Data;

public class WeatherForecastService
{
    private readonly IMemoryCache _memoryCache;
    public WeatherForecastService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
        return _memoryCache.GetOrCreateAsync(startDate, async e =>
        {
            e.SetOptions(new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30) });
            var rng = new Random();
            await Task.Delay(TimeSpan.FromSeconds(1));
            return (Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray());

        });

    }
}
