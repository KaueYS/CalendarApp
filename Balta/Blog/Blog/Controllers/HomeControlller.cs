using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]

    public class HomeControlller : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
