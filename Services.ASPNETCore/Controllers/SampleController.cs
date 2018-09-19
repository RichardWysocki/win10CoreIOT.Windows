using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Services.ASPNETCore.Docker.Controllers
{
    [Produces("application/json")]
    [Route("api/Sample")]
    [Authorize]
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