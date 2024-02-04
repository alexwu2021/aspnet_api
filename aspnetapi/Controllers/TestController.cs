using Microsoft.AspNetCore.Mvc;


namespace aspnetapp.Controllers
{
    [ApiController]
    [Route("api/v1/test")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "This API is updated, up and running!" });
        }
    }


}