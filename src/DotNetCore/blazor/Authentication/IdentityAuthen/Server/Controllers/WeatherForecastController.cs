using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdentityAuthen.Shared;
using Microsoft.AspNetCore.Identity;
using IdentityAuthen.Server.Models;

namespace IdentityAuthen.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly UserManager<ApplicationUser> userManager;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        this.userManager = userManager;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        var user = await userManager.GetUserAsync(User);

        if (user != null)
        {
            _logger.LogInformation($"User.Identity.Name: {user.UserName}");
        }
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
