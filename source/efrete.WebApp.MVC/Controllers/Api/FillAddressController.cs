using Microsoft.AspNetCore.Mvc;

namespace efrete.WebApp.MVC.Controllers
{
    [ApiController]
    [Route("")]
    public class FillAddressController : ControllerBase
    {
        [Route("UF")]
        [HttpPost]
        public IActionResult FillUF([FromBody] string text)
        {
            return Ok();
        }

        [Route("Street")]
        [HttpPost]
        public IActionResult SearchAddress([FromBody] string text)
        {
            return Ok();
        }
    }
}
