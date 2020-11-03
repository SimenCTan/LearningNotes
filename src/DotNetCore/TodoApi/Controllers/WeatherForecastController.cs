using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoApi.Models;

namespace TodoApi.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// ddd
        /// </summary>
        /// <param name="strkey"></param>
        /// <returns></returns>
        [HttpGet("GetSummaries")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSummaries([FromQuery] string strkey)
        {
            var str = Summaries.Where(m => m == strkey);
            return Ok(str);
        }

        /// <summary>
        /// save test gogo
        /// </summary>
        /// <param name="todoItem1"></param>
        /// <param name="todoItem2"></param>
        /// <returns></returns>
        [HttpPost("SaveTodo")]
        public IActionResult SaveTodo(int todoItem1, [FromBody] TodoItem todoItem2)
        {
            return Ok();
        }

        [HttpPost("CreateProduct")]
        [Consumes("application/xml")]
        [Produces("application/json")]
        public IActionResult CreateProduct([FromBody]TodoItem product)
        {
            return Ok();
        }


    }
}
