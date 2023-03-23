using Microsoft.AspNetCore.Mvc;

namespace BlogList.Controller
{

    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok();
        }





    }
}
