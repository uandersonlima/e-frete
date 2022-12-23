using efrete.Addresses.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace efrete.WebApp.MVC.Controllers
{
    [Controller]
    public class AddressController : Controller
    {
        private readonly IAddressQueries _addressQueries;

        public AddressController(IAddressQueries addressQueries)
        {
            _addressQueries = addressQueries;
        }

        [HttpGet]
        [Route("search-address")]
        public IActionResult SearchAddress()
        {
            return View();
        }

        [HttpPost]
        [Route("search-address")]
        public IActionResult SearchAddress([FromForm] string zipCode)
        {

            return View();
        }


        [HttpGet]
        [Route("search-zip-code")]
        public IActionResult SearchZipCode()
        {

            return View();
        }

        [HttpPost]
        [Route("search-zip-code")]
        public IActionResult SearchZipCode([FromForm] string uF, [FromForm] string city, [FromForm] string street)
        {

            return View();
        }
    }
}
