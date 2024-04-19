using Microsoft.AspNetCore.Mvc;

namespace AppServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BinaryService(ILogger<WeatherForecastController> logger) : ControllerBase
    {
        [HttpGet]
        public string Get() => "Binary Service is running";

        [HttpPost]
        public async Task<string> Post([FromQuery] string operation)
        {
            try
            {
                var buffer = new MemoryStream();
                await Request.Body.CopyToAsync(buffer);
                var data = buffer.ToArray();
                return $"{data.Length} bytes received for operation {operation}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }
    }
}
