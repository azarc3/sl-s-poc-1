using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenWeather.Noaa.CurrentObservartions;
using OpenWeather.Noaa.Models;
using System;
using System.Threading.Tasks;

namespace Poc1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly ILogger<WeatherForecastController> _logger;

		private static OpenWeather.Noaa.Api _api;

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
			_api = new OpenWeather.Noaa.Api();
		}

		[HttpGet]
		public async Task<CurrentObservation> Get(string query)
		{
			_logger.LogInformation("executing query for {query} at {time}", query, new Lib1.Class1().GetUtcDateTime());
			var result = await _api.GetCurrentObservationsByStationAsync(new Station() { ICAO = string.IsNullOrWhiteSpace(query) ? "KTPA" : query });
			_logger.LogInformation("execution complete at {time}", new Lib2.Class1().GetUtcDateTime());
			return result;
		}

	}
}
