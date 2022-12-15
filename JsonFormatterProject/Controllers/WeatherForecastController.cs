using JsonFormatterProject.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonFormatterProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IJsonFormatter json;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IJsonFormatter jsonFormatter)
        {
            _logger = logger;
            this.json = jsonFormatter;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
/*
        [HttpPost]
        public IActionResult Post(string data)
        {
            var result = json.formatJson(data);

            //string output = jsonconvert.serializeobject(result, newtonsoft.json.formatting.indented);

            string output = JToken.Parse(result).ToString();

            // string output = jsonconvert.serializeobject(tbl, newtonsoft.json.formatting.indented);
            return Ok(output);

        }

*/
    }
}