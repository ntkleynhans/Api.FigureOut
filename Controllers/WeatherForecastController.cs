using Microsoft.AspNetCore.Mvc;

namespace Api.FigureOut.Controllers;

// TODO: Refactor code - split into different files/folders?

// How would we unit test the different endpoint?

public abstract class WeatherForecastController : ControllerBase
{
    [HttpGet("GetWeatherForecast")]
    public abstract IEnumerable<WeatherForecast> Get();
}

[ApiController]
[Route("WeatherForecastController/v1")]
public class WeatherForecastControllerV1 : WeatherForecastController
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastControllerV1> _logger;

    public WeatherForecastControllerV1(ILogger<WeatherForecastControllerV1> logger)
    {
        _logger = logger;
    }

    //[HttpGet(Name = "GetWeatherForecastV1")]
    public override IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 3).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

[ApiController]
[Route("WeatherForecastController/v2/")]
public class WeatherForecastControllerV2 : WeatherForecastControllerV1
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastControllerV2> _logger;

    public WeatherForecastControllerV2(ILogger<WeatherForecastControllerV2> logger) : base(logger)
    {
        _logger = logger;
    }

    //[HttpGet(Name = "GetWeatherForecast")]
    public override IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 7).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-60, 65),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

