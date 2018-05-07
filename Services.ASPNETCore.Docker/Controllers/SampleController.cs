using Microsoft.AspNetCore.Mvc;

namespace Services.ASPNETCore.Docker.Controllers
{
    [Produces("application/json")]
    [Route("api/Sample")]
    public class SampleController : Controller
    {

        [HttpGet()]
        public string Get()
        {
            return "Get value";
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"value: {id}";
        }
    }
}