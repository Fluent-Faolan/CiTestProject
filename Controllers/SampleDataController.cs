using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CiTestProject.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private const int MinimumTemp = -20;
        private const int MaximumTemp = 55;
        private const int Range = MaximumTemp - MinimumTemp;

        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts(int startDateIndex)
        {
            var rng = new Random();

            return Enumerable.Range(1, 5).Select(index =>
            {
                var rand = rng.Next(-20, 55);
                return new WeatherForecast
                {
                    DateFormatted = DateTime.Now.AddDays(index + startDateIndex).ToString("d"),
                    TemperatureC = rand,
                    Summary = Summaries[RelativeTemp(rand)]
                };
            });
        }

        private static int RelativeTemp(int current)
        {
            return (int)Math.Floor( (float)( ( current - MinimumTemp ) / (double)Range ) * Summaries.Length);
            obvious compile error.
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);
        }
    }
}