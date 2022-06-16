using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForecastService _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }

        //  [HttpGet]
        //  public IEnumerable<WeatherForecast> Get()
        //  {
        //      var result = _service.Get();
        //      return result;
        //  }
        //  
        //  [HttpGet("currentDay/{max}")]
        // // [Route("currentDay")]
        //  public IEnumerable<WeatherForecast> Get2([FromQuery] int take, [FromRoute] int max)
        //  {
        //      var result = _service.Get();
        //      return result;
        //  }
        //
        // [HttpPost]
        // public ActionResult<string> Hello([FromBody] string name)
        // {
        //     //HttpContext.Response.StatusCode = 401;
        //     //return $"Hello {name}";
        //
        //    // return StatusCode(401, $"Hello {name}");
        //
        //    return NotFound($"Hello {name}");
        // }

        [HttpPost("generate")]
        public ActionResult<IEnumerable<WeatherForecast>> Generate([FromQuery] int count,
            [FromBody] TemperatureRequest request)
        {
            if (count < 0 || request.Max < request.Min)
            {
                return BadRequest();
            }

            var result = _service.Get(count, request.Min, request.Max);
            return Ok(result);
        }
    }
}